using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web.UI;

namespace New_EmailCampaign
{
    public partial class UserSignup : System.Web.UI.Page
    {
        UserDetails objUserDetails = new UserDetails();
        BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();

        InviteUser objInviteUser = new InviteUser();
        BL_InviteUser objBL_InviteUser = new BL_InviteUser();
        List<InviteUser> lstInviteUser = new List<InviteUser>();

        Company objCompany = new Company();
        BL_CompanyDetails objBL_CompanyDetails = new BL_CompanyDetails();
        List<Company> lstCompany = new List<Company>();

        MailTemplate objMailTemplate = new MailTemplate();
        New_EmailCampaign.App_Code.CryptographicHashCode objCryptographicHashCode = new New_EmailCampaign.App_Code.CryptographicHashCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["signid"] != null)
                {
                    string DecryptQry = objCryptographicHashCode.DecryptCipherTextToPlainText(Request.QueryString["signid"].ToString());
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["signid"] != null)
                {
                    objUserDetails = new UserDetails();
                    string DecryptQry = objCryptographicHashCode.DecryptCipherTextToPlainText(Request.QueryString["signid"].ToString());

                    lstInviteUser = objBL_InviteUser.SelectInviteUserforcampid(Convert.ToInt32(DecryptQry));
                    string txtEmail = "";

                    if (lstInviteUser.Count > 0)
                    {
                        int CompanyID = lstInviteUser[0].FK_CompanyID;
                        objUserDetails.FK_CompanyID = CompanyID;
                        objUserDetails.Email_id = lstInviteUser[0].Emailid;
                        txtEmail = lstInviteUser[0].Emailid;

                        if (lstInviteUser[0].FK_RoleID != 0)
                            objUserDetails.FK_RoleID = lstInviteUser[0].FK_RoleID;
                    }

                    objUserDetails.UserName = txtUserName.Value.ToString().Trim();
                    objUserDetails.UserPassword = txtPassword.Value.ToString().Trim();
                    objUserDetails.FirstName = txtFirstName.Value.ToString().Trim();
                    objUserDetails.LastName = txtLastNam.Value.ToString().Trim();
                    objUserDetails.CreatedOn = DateTime.Now;
                    objUserDetails.MemberSince = DateTime.Now;
                    objUserDetails.AccountActivated = false;
                    objUserDetails.IsActive = true;
                    objUserDetails.UserType = 0;
                    objBL_UserLoginDetails.AccessInsertUserLogin(objUserDetails);
                    string sEmailId = "sakthivel@aryvart.com";
                    string sSubject = "Aryvart Email Campaign: Please verify your email address.";
                    string strReceiverName = "ADMIN";
                    string EncryptQry = "id=" + objCryptographicHashCode.EncryptPlainTextToCipherText(objBL_UserLoginDetails.ReturnUserLoginMaxID().ToString()) + "'";
                    string body = MailTemplate.MailAccountActivate(EncryptQry);
                    objMailTemplate.fnSendMailToClientForCoUpld(body, txtEmail, sSubject, sEmailId);
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey1", "Clearuserinput1();", true);

                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserSignup.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
    }
}