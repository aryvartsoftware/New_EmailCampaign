using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web.UI;
using System.Net.Mail;
using System.Net;

namespace New_EmailCampaign
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        UserDetails objUserDetails = new UserDetails();
        BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.SetFocus(txtEmail);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strNewPassword = "";
            string strName = "";
            string strUserName = "";
            string strBCCEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartBCCEmailID"].ToString();
            string strSystemName = System.Configuration.ConfigurationSettings.AppSettings["AryvartSystemName"].ToString();

            try
            {
                lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsforForgetPassword(txtEmail.Value.ToString());

                if (lstUserDetails.Count > 0)
                {
                    lblerrormsg.Visible = false;
                    string password = "";

                    password = lstUserDetails[0].UserPassword;
                    strUserName = lstUserDetails[0].UserName.ToString();
                    strNewPassword = password;

                    if (lstUserDetails[0].FirstName != null)
                        strName = lstUserDetails[0].FirstName;
                    else
                        strName = strUserName;

                    
                    string body = MailTemplate.MailHTML(MailTemplate.GetEmailTemplate("ForgotPassword.html").Replace("<systemname>", "Aryvart Email Campaign,").Replace("<receivername>", strName).Replace("<username>", strUserName).Replace("<password>", strNewPassword));
                    fnSendMail(body);
                    body = "";
                    lstUserDetails = null;
                    txtEmail.Value = string.Empty;
                    //ClientScript.RegisterStartupScript(Page.GetType(), "mykey12", "javascript:alert('Please check your email for login details.');", true);
                    lblerrormsg.Visible = true;
                    lblerrormsg.Text = "<span style='color:#c85305'>Please check your email for login details.</span>.";
                }
                else
                {
                    lblerrormsg.Visible = true;
                    lblerrormsg.Text = "<span style='color:#c85305'>Email id doesn't exists! Please try another</span>";
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ForgotPassword.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }

        public void fnSendMail(string Body)
        {
            MailMessage mmsgRegistration = new MailMessage();
            //string strSiteName = System.Configuration.ConfigurationSettings.AppSettings["AryvartSiteName"].ToString();
            //string strSiteURL = System.Configuration.ConfigurationSettings.AppSettings["AryvartSiteURL"].ToString();
            //string strSitePath = System.Configuration.ConfigurationSettings.AppSettings["AryvartSitePath"].ToString();127.0.0.1
            string strSMTPServer = "smtp.gmail.com";//smtp ip - "74.208.5.2";//"74.208.3.226";
            string strAdminEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailID"].ToString();
            string strBCCEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartBCCEmailID"].ToString();
            string strSystemName = System.Configuration.ConfigurationSettings.AppSettings["AryvartSystemName"].ToString();
            string fromPassword = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailPassword"].ToString();
            string strMailContent = "";
            try
            {
                mmsgRegistration.From = new MailAddress(strAdminEmailID);

                mmsgRegistration.To.Add(new MailAddress(txtEmail.Value.ToString()));
                mmsgRegistration.Bcc.Add("ganesamoorthy.p@aryvart.com," + strBCCEmailID);
                mmsgRegistration.Subject = "Welcome to " + strSystemName + " - Forgot Password";
                mmsgRegistration.IsBodyHtml = true;
                mmsgRegistration.Body = Body;
                //SmtpClient SmtpContactInfo = new SmtpClient(strSMTPServer.ToString());
                //SmtpContactInfo.Send(mmsgRegistration);

                
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(strAdminEmailID, fromPassword);
                    smtp.Timeout = 20000;

                }
                smtp.Send(mmsgRegistration);
                //smtp.Send(strAdminEmailID, txtEmail.Text, "Welcome to " + strSystemName + " - Forgot Password", Body);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ForgotPassword.aspx:fnSendMail() - " + ex.Message);
            }
        }
    }
}