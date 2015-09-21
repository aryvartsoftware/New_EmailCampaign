using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web.UI;

namespace New_EmailCampaign
{

    public partial class FreeAccountSignUp : System.Web.UI.Page
    {
        UserDetails objUserDetails = new UserDetails();
        BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();

        Company objCompany = new Company();
        BL_CompanyDetails objBL_CompanyDetails = new BL_CompanyDetails();
        List<Company> lstCompany = new List<Company>();

        MailTemplate objMailTemplate = new MailTemplate();
        New_EmailCampaign.App_Code.CryptographicHashCode objCryptographicHashCode = new New_EmailCampaign.App_Code.CryptographicHashCode();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int status = objBL_UserLoginDetails.AccessVerifyUserEmailidExist(txtEmail.Value.ToString().Trim());

                if (status == 0)
                {
                    objCompany = new Company();
                    objCompany.Email_id = txtEmail.Value.ToString().Trim();
                    objCompany.Company_Name = txtCompanyName.Value.ToString().Trim();
                    objCompany.ContactNo = txtContactNumber.Value.ToString().Trim();
                    objCompany.CreatedOn = DateTime.Now;
                    objBL_CompanyDetails.AccessInsertCompany(objCompany);

                    objUserDetails = new UserDetails();
                    int CompanyID = Convert.ToInt32(objBL_CompanyDetails.ReturnCompanyMaxID());

                    if (objUserDetails.FK_CompanyID != 0)
                        objUserDetails.FK_CompanyID = CompanyID;

                    objUserDetails.UserName = txtUserName.Value.ToString().Trim();
                    objUserDetails.UserPassword = txtPassword.Value.ToString().Trim();
                    objUserDetails.Email_id = txtEmail.Value.ToString().Trim();
                    objUserDetails.ContactNo = txtContactNumber.Value.ToString().Trim();
                    objUserDetails.CreatedOn = DateTime.Now;
                    objUserDetails.MemberSince = DateTime.Now;
                    objUserDetails.AccountActivated = false;

                    if (chkNewsLetter.Checked)
                        objUserDetails.SendNewsLetter = true;
                    else
                        objUserDetails.SendNewsLetter = false;

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
                    objMailTemplate.fnSendMailToClientForCoUpld(body, txtEmail.Value.ToString().Trim(), sSubject, sEmailId);


                    //---------End---------------------
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey1", "Clearuserinput1();", true);
                }
                else if (status == 1)
                {
                    lblerrormsg.Text = "<span style='color:#c85305;font-size:12px;'>Emailid already exist use some other emailid or </span> <a href='UserLogin.aspx' style='font-size:12px; color: #00acec;'>Log in using your credential</a>.";
                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("FreeAccountSignUp.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
    }
}