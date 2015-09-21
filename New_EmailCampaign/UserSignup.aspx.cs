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

                    objUserDetails.UserType = 1;
                    objBL_UserLoginDetails.AccessInsertUserLogin(objUserDetails);
                    //------Sending confirmtion Email of account created to client.-----
                    string sEmailId = "sakthivel@aryvart.com";
                    //subject
                    string sSubject = "Aryvart Email Campaign: Please verify your email address.";

                    ////sending emails to client
                    string strReceiverName = "ADMIN";
                    string EncryptQry = "id=" + objCryptographicHashCode.EncryptPlainTextToCipherText(objBL_UserLoginDetails.ReturnUserLoginMaxID().ToString()) + "'";
                    //string EncryptQry = "id=" + objBL_UserLoginDetails.ReturnUserLoginMaxID().ToString() + "'";

                    //string strDetails = "<table border='1' cellspacing='0' cellpadding='0'><tr><td width='152' valign='middle'><span style='font-size:14px;color:#aa483c'>&nbsp;File Name:</span></td><td width='200' valign='middle'><span style='font-size:14px;color:#aa483c'>&nbsp;" + sFileName + ".</span></td></tr><tr><td width='152' valign='middle'><span style='font-size:14px;color:#aa483c'>&nbsp;Uploaded on:</span></td><td width='200' valign='middle'><span style='font-size:14px;color:#aa483c'>&nbsp;" + DateTime.Now.ToString() + "." + "</span></td></tr></table>";
                    //string body = MailTemplate.MailCoUpldHTML(MailTemplate.GetEmailTemplate("CoUpldEmail.html").Replace("<CompanyName>", sCompanyName).Replace("<Details>", strDetails).Replace("<ReceiverName>", strReceiverName).Replace("<ClientName>", sClientName));
                    //objMailTemplate.fnSendMailToClientForCoUpld(body, "sakthivel@aryvart.com", sSubject, sEmailId);
                    string body = MailTemplate.MailAccountActivate(EncryptQry);
                    objMailTemplate.fnSendMailToClientForCoUpld(body, txtEmail, sSubject, sEmailId);


                    //---------End---------------------
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey1", "Clearuserinput1();", true);

                    //lblerrormsg.Text = "<span style='color:#c85305;font-size:12px;'>Emailid already exist use some other emailid or </span> <a href='UserLogin.aspx' style='font-size:12px; color: #00acec;'>Log in using your credential</a>.";
                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserSignup.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
    }
}