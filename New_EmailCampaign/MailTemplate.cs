/*Copyright © 2009,2010 Web4Minds. All rights reserved.*/
using System;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Data;

/// <summary>
/// Summary description for MailTemplate
/// </summary>
public class MailTemplate
{
    public MailMessage mmsgRegistration = new MailMessage();
    public MailTemplate()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetEmailTemplate(string HTMLName)
    {
        try
        {
            string strSiteURL = System.Configuration.ConfigurationManager.AppSettings["AryvartSiteURL"].ToString();
            string url = HttpContext.Current.Request.Url.AbsoluteUri.ToString();
            url = url.Substring(0, url.LastIndexOf("/"));
            url = url.Substring(0, url.LastIndexOf("/"));
            url = strSiteURL + "/" + HTMLName; ;


            string html = "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }
            }

            return html;
        }
        catch (Exception ex)
        {
            //Response.Redirect("Error.aspx", false);
            string html = "";
            New_EmailCampaign.App_Code.GlobalFunction.StoreLog("App_Code/MailTemplate.cs:GetEmailTemplate() - " + ex.Message);
            //ABBA_GlobalFunction.ABBA_GlobalFunction.StoreLog("Sendmail.aspx:RadToolBar1_ButtonClick() -  " + ex.Message);
            return html;
        }
    }

    public static string MailCoUpldHTML(string strMessage)
    {

        string Body = "<html xmlns=\"http://www.w3.org/1999/xhtml\">"
                        + "<head>"
                        + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\" />"
                        + "<title></title>"
                        + "<style type=\"text/css\">body,td,th {font-family: Arial;font-size: 12px;color: #666666;}"
                        + "a {font-family: Arial;font-size: 12px;color:blue;}"
                        + "a:link {text-decoration: none; color:blue}"
                        + "a:visited {text-decoration: none;color: blue;}"
                        + "a:hover {text-decoration: underline;color: blue;}"
                        + "a:active {text-decoration: none;color: blue;}"
                        + "</style></head><body>"
                        + "<table style=\"width:95%; border: 2pt solid #E36C0A;\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">"
                           + "<tr>"

                               + "<td style='padding:5px;'>"
                               + "<img src='../images/Aryvart-logo.png'  />"
                               + "</td>"
                           + "</tr>"
                           + "<tr>"
                               + "<td style=\"height:20px\"></td>"
                           + "</tr>"
                           + "<tr>"

                               + "<td><span style='font-size:30px;font-weight:bold;color:#1F2D69'>"
                               + "Download Alert!"
                               + "</span></td>"
                           + "</tr>"
                           + "<tr>"
                               + "<td style=\"height:20px\"></td>"
                           + "</tr>"
                           + "<tr>"
                               + "<td>" + strMessage + "</td>"
                           + "</tr>"
                           + "<tr>"
                               + "<td style=\"height:20px\"></td></tr>"
                           + "</table>"
                       + "</body></html>";



        return Body;
    }

    public static string MailAccountActivate(string strMessage)
    {
        string Body = "<html xmlns='http://www.w3.org/1999/xhtml'>"
+ "<head runat='server'>"
+ "  <title>Welcome :: Aryvart Campaign</title>"
+ "</head>"
+ "<body  bgcolor='#e6e6e8'>"
+ ""
+ "	<table cellpadding='0' cellspacing='0' border='0' width='600' align='center'>"
+ "    	<tr>"
+ "        	<td align='center' style='padding:20px 0;'><img src='http://www.aryvartdev.com/images/new_logo.png' /></td>"
+ "        </tr>"
+ "        <tr>"
+ "        	<td style='background:#fff;border-radius:5px;padding:20px;'>"
+ "            	<table cellpadding='0' width='100%'>"
+ "                	<tr>"
+ "                    	<td>"
+ "                        	<h1 style='color: #424242;font-size:22px;text-align:center;font-weight:bold;font-family:Lato,Tahoma,Arial;'>Welcome to Aryvart Email Campaign</h1>"
+ "                            <p align='center' style='font-family:Lato,Tahoma,Arial;'>Thanks for signing up. Please verify your email address.</p>"
+ "                        </td>                        "
+ "                    </tr>"
+ "                    <tr>"
+ "                    	<td style='padding:20px 0;' align='center'>"
+ "<a  style='font-family:Lato,Tahoma,Arial;background:#00acec;cursor:pointer;text-decoration:none; color: #fff;border: 1px solid #00acec;padding:15px;width:95%;border-radius:5px;font-size:16px;' href='http://localhost:3735/ActivateSuccess.aspx?" + strMessage + ">Sign Up Now</a>"
+ "                        </td>"
+ "                    </tr>"
+ "                    <tr>"
+ "                    	<td align='right' style='padding:10px 30px;font-family:Lato,Tahoma,Arial;'>"
+ "                        	<p style='color:#0392DB'>Thanks"
+ "                            	<br><span style='color:#333;font-size:13px;'>Aryvart Team</span></p>"
+ ""
+ "                        </td>"
+ "                    </tr>"
+ "                </table>"
+ "            </td>"
+ "        </tr>"
+ "    </table>"
+ ""
+ "</body>"
+ "</html>";

        return Body;
    }

    public static string MailInviteUser(string cmpname, string cntmailid, string strMessage)
    {
        string Body = "<html xmlns='http://www.w3.org/1999/xhtml'>"
+ "	<head>"
+ "		<meta http-equiv='Content-type' content='text/html; charset=UTF-8' />"
+ "		<title>Invite to join Aryvart Email Campaign</title>"
+ "	</head>"
+ "	<body leftmargin='0' topmargin='0' marginwidth='0' marginheight='0' style='font-family:Arial, sans-serif;background-color:#E6E6E8'>"
+ "		<!-- wrapper -->"
+ "		<table width='100%' border='0' cellpadding='0' cellspacing='0' align='center'>"
+ "			<tr>"
+ "				<td width='100%' valign='top' background-color='#fff' style='padding-top:70px'>	"
+ "					<table width='600px' border='0' cellpadding='0' cellspacing='0' align='center' style='background-color:#fff;border-radius:3px;padding-bottom:25px;'>"
+ "						<tr><!-- header -->"
+ "							<td align='center' width='100%' style='padding:20px 0px;'>"
+ "								<a href=''><img src='http://www.aryvartdev.com/images/new_logo.png'></a>"
+ "							</td>"
+ "						</tr><!-- header -->"
+ "						<tr>"
+ "							<td align='center' width='100%'>"
+ "								<h2 style='font-size:21px;color: #525252;padding: 0 25px;'>You've been invited to join a Aryvart Email Campaign account.</h2>"
+ "								<p style='  font-size: 14px;color: #525252;line-height: 22px;padding-top:8px;border-bottom: 1px solid #E7E7E7;padding-bottom: 20px;8px;'>You're being given access to the account<br/> <b>" + cmpname + "</b></p>"
+ "							</td>"
+ "						</tr>"
+ "						<tr>"
+ "							<td align='center' width='100%'>"
+ "								<p style='font-size: 15px;color: #525252;line-height: 22px; padding: 10px 30px;text-align: left;'>Already a Aryvart user? You’ll be able to use your existing login to join this account, or you can create a new login to access the account. </p>"
+ "								<p style='font-size: 15px;color: #525252;line-height: 22px; padding: 0px 30px;text-align: left;'><b>This invitation expires after 7 days.</b> If you have any questions, contact " + cntmailid + ".</p>"
+ "							</td>"
+ "						</tr>"
+ "						<tr>"
+ "							<td style='padding:20px 0' align='center'><a style='font-family:Lato,Tahoma,Arial;background:#00acec;text-decoration:none;color:#fff;border:1px solid #00acec;padding:12px 15px;width:100%;border-radius:5px;font-size:16px' href='http://localhost:3735/UserSignup.aspx?" + strMessage + "' target='_blank'>Join this account now</a>                        "
+ "							</td>"
+ "						</tr>"
+ "					</table>					"
+ "				</td>"
+ "			</tr>"
+ "		</table>"
+ "	</body>"
+ "</html>";

        return Body;
    }

    public static string MailHTML(string strMessage)
    {

        string Body = "<html xmlns=\"http://www.w3.org/1999/xhtml\">"
                        + "<head>"
                        + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\" />"
                        + "<title></title>"
                        + "<style type=\"text/css\">body,td,th {font-family: Arial;font-size: 12px;color: #666666;}"
                        + "a {font-family: Arial;font-size: 12px;color:blue;}"
                        + "a:link {text-decoration: none; color:blue}"
                        + "a:visited {text-decoration: none;color: blue;}"
                        + "a:hover {text-decoration: underline;color: blue;}"
                        + "a:active {text-decoration: none;color: blue;}"
                        + "</style></head><body>"
                        + "<table style=\"width:95%\" align=\"center\">"
                           + "<tr>"

                               + "<td style='border-bottom:1px solid #cccccc;padding:5px;'>"
                               + "<img src='../images/Aryvart-logo.png'  />"
                               + "<td>"
                           + "</tr>"
                           + "<tr>"
                               + "<td style=\"height:20px\"></td>"
                           + "</tr>"
                        
                           + "<tr>"
                               + "<td style=\"height:20px\"></td>"
                           + "</tr>"
                           + "<tr>"
                               + "<td>" + strMessage + "</td>"
                           + "</tr>"
                           + "<tr>"
                               + "<td style=\"height:20px\"></td></tr>"
                           + "</table>"
                       + "</body></html>";


            
        return Body;
    }


    //public static string MailFeedBackHTML(string strMessage)
    //{

    //    string Body = "<html xmlns=\"http://www.w3.org/1999/xhtml\">"
    //                    + "<head>"
    //                    + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\" />"
    //                    + "<title></title>"
    //                    + "<style type=\"text/css\">body,td,th {font-family: Arial;font-size: 12px;color: #666666;}"
    //                    + "a {font-family: Arial;font-size: 12px;color:blue;}"
    //                    + "a:link {text-decoration: none; color:blue}"
    //                    + "a:visited {text-decoration: none;color: blue;}"
    //                    + "a:hover {text-decoration: underline;color: blue;}"
    //                    + "a:active {text-decoration: none;color: blue;}"
    //                    + "</style></head><body>"
    //                    + "<table border=\"1\" style=\"width:95%\" align=\"center\">"
    //                       + "<tr>"

    //                           + "<td style='border-bottom:1px solid #cccccc;padding:5px;'>"
    //                           + "<img src='../images/Aryvart-logo.png'  />"
    //                           + "<td>"
    //                       + "</tr>"
    //                       + "<tr>"
    //                           + "<td style=\"height:20px\"></td>"
    //                       + "</tr>"
    //                       + "<tr>"

    //                           + "<td><span style='font-size:30px;font-weight:bold;color:#1F2D69'>"
    //                           + "Client FeedBack!"
    //                           + "</span><td>"
    //                       + "</tr>"
    //                       + "<tr>"
    //                           + "<td style=\"height:20px\"></td>"
    //                       + "</tr>"
    //                       + "<tr>"
    //                           + "<td>" + strMessage + "</td>"
    //                       + "</tr>"
    //                       + "<tr>"
    //                           + "<td style=\"height:20px\"></td></tr>"
    //                       + "</table>"
    //                   + "</body></html>";



    //    return Body;
    //}

    /// <summary>
    /// Comments::Client upload mail functionality
    /// Created On :: 30-9-2014
    /// </summary>
    /// <param name="Body"></param>
    /// <param name="Todest"></param>
    /// <param name="Subject"></param>
    /// <param name="sClientEmailId"></param>
    //#region Client upload mail functionality
    //public void fnSendMail(string Body, string Todest, string Subject, int iClientId)
    //{


    //    string strSMTPServer = "smtp.gmail.com";//smtp ip - "74.208.5.2";//"74.208.3.226";
    //    string strAdminEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailID"].ToString();
    //    string strSystemName = System.Configuration.ConfigurationSettings.AppSettings["AryvartSystemName"].ToString();
    //    string strMailContent = "";
    //    try
    //    {
    //        mmsgRegistration.From = new MailAddress(strAdminEmailID);
    //        mmsgRegistration.Bcc.Add(new MailAddress(Todest.ToString()));
    //        //GetListOfPersonsForTo(iClientId);
    //        mmsgRegistration.Subject = Subject;
    //        mmsgRegistration.IsBodyHtml = true;
    //        mmsgRegistration.Body = Body;


    //        string fromPassword = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailPassword"].ToString();
    //        var smtp = new System.Net.Mail.SmtpClient();
    //        {
    //            smtp.Host = "smtp.gmail.com";

    //            smtp.Port = 587;
    //            smtp.EnableSsl = true;
    //            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    //            smtp.Credentials = new NetworkCredential(strAdminEmailID, fromPassword);
    //            smtp.Timeout = 200000;

    //        }
    //        smtp.Send(mmsgRegistration);
    //        //smtp.Send(strAdminEmailID, txtEmail.Text, "Welcome to " + strSystemName + " - Forgot Password", Body);
    //    }
    //    catch (Exception ex)
    //    {

    //        New_EmailCampaign.App_Code.GlobalFunction.StoreLog("App_Code/MailTemplate.cs:fnSendMail() - " + ex.Message);
    //    }
    //}
    //#endregion

    /// <summary>
    /// Comments::Company upload mail functionality
    /// Created On :: 27-5-2015
    /// </summary>
    /// <param name="Body"></param>
    /// <param name="Todest"></param>
    /// <param name="Subject"></param>
    /// <param name="sClientEmailId"></param>
    # region Company upload mail functionality
    public void fnSendMailToClientForCoUpld(string Body, string Todest, string Subject, string sClientEmailId)
    {


        string strSMTPServer = "smtp.1and1.com";//smtp ip - "74.208.5.2";//"74.208.3.226";
        string strAdminEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailID"].ToString();
        string strSystemName = System.Configuration.ConfigurationSettings.AppSettings["AryvartSystemName"].ToString();
        string strMailContent = "";
        try
        {
            mmsgRegistration.From = new MailAddress(strAdminEmailID);
            mmsgRegistration.Bcc.Add(new MailAddress(Todest.ToString()));
            mmsgRegistration.To.Clear();
            mmsgRegistration.To.Add(new MailAddress(sClientEmailId));
            mmsgRegistration.Subject = Subject;
            mmsgRegistration.IsBodyHtml = true;
            mmsgRegistration.Body = Body;


            string fromPassword = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailPassword"].ToString();
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(strAdminEmailID, fromPassword);
                smtp.Timeout = 200000;

            }
            smtp.Send(mmsgRegistration);
            //smtp.Send(strAdminEmailID, txtEmail.Text, "Welcome to " + strSystemName + " - Forgot Password", Body);

        }
        catch (Exception ex)
        {

            New_EmailCampaign.App_Code.GlobalFunction.StoreLog("App_Code/MailTemplate.cs:fnSendMailToClientForCoUpld() - " + ex.Message);
        }
    }
    # endregion


    /// <summary>
    /// Comments::Company upload mail functionality
    /// Created On :: 27-5-2015
    /// </summary>
    /// <param name="Body"></param>
    /// <param name="Todestcc"></param>
    /// <param name="Subject"></param>
    /// <param name="sClientEmailId"></param>
    # region MailSending functionality
    public void fnSendMailToRecipients(string strAdminEmailID, string fromPassword, string Body, string Todestcc, string Subject, string sClientEmailId, string Fromid, int campqid)
    {


        string strSMTPServer = "smtp.1and1.com";//smtp ip - "74.208.5.2";//"74.208.3.226";
        //string strAdminEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailID"].ToString();
        string strSystemName = System.Configuration.ConfigurationSettings.AppSettings["AryvartSystemName"].ToString();
        string strMailContent = "";
        try
        {
            mmsgRegistration.From = new MailAddress(Fromid);
            mmsgRegistration.Bcc.Add(new MailAddress(Todestcc.ToString()));
            mmsgRegistration.To.Clear();
            mmsgRegistration.To.Add(new MailAddress(sClientEmailId));
            mmsgRegistration.Subject = Subject;
            mmsgRegistration.IsBodyHtml = true;
            mmsgRegistration.Headers.Add("Disposition-Notification-To", "<" + campqid.ToString() + ">");
            mmsgRegistration.Headers.Add("X-Confirm-Reading-To", strAdminEmailID);
            mmsgRegistration.Headers.Add("Return-Receipt-To", strAdminEmailID);
            //mmsgRegistration.Headers.Add("X-Company", "My Company");
            mmsgRegistration.Body = Body;


            //string fromPassword = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailPassword"].ToString();
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";

                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(strAdminEmailID, fromPassword);
                smtp.Timeout = 200000;

            }
            smtp.Send(mmsgRegistration);
            //smtp.Send(strAdminEmailID, txtEmail.Text, "Welcome to " + strSystemName + " - Forgot Password", Body);

        }
        catch (Exception ex)
        {

            New_EmailCampaign.App_Code.GlobalFunction.StoreLog("App_Code/MailTemplate.cs:fnSendMailToClientForCoUpld() - " + ex.Message);
        }
    }
    # endregion




    //public void fnFeedBack(string Body, string Todest, string Subject)
    //{


    //    string strSMTPServer = "smtp.1and1.com";//smtp ip - "74.208.5.2";//"74.208.3.226";
    //    string strAdminEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailID"].ToString();
    //    string strSystemName = System.Configuration.ConfigurationSettings.AppSettings["AryvartSystemName"].ToString();
    //    string strMailContent = "";
    //    try
    //    {
    //        mmsgRegistration.From = new MailAddress(strAdminEmailID);
    //        mmsgRegistration.To.Add(new MailAddress("sakthivel@aryvart.com"));
    //        mmsgRegistration.Subject = Subject;
    //        mmsgRegistration.IsBodyHtml = true;
    //        mmsgRegistration.Body = Body;


    //        string fromPassword = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailPassword"].ToString();
    //        var smtp = new System.Net.Mail.SmtpClient();
    //        {
    //            smtp.Host = "smtp.1and1.com";// "smtp.gmail.com";

    //            smtp.Port = 25;//587
    //            smtp.EnableSsl = true;
    //            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    //            smtp.Credentials = new NetworkCredential(strAdminEmailID, fromPassword);
    //            smtp.Timeout = 200000;

    //        }
    //        smtp.Send(mmsgRegistration);
    //        //smtp.Send(strAdminEmailID, txtEmail.Text, "Welcome to " + strSystemName + " - Forgot Password", Body);
    //    }
    //    catch (Exception ex)
    //    {

    //        New_EmailCampaign.App_Code.GlobalFunction.StoreLog("App_Code/MailTemplate.cs:fnSendMail() - " + ex.Message);
    //    }
    //}



  



}
