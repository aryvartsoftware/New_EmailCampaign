using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Data;
using System.Net.Mail;
using OpenPop.Pop3;
using BALayer;
using System.Data.SqlClient;
using OpenPop.Mime;
using System.Web.UI.WebControls;

namespace New_EmailCampaign
{
    public partial class CampaignReport : System.Web.UI.Page
    {
        BL_Common objBL_Common = new BL_Common();
        protected List<Email1> Emails
        {
            get { return (List<Email1>)ViewState["Emails"]; }
            set { ViewState["Emails"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    if (Request.QueryString["CamprptId"] != null)
                    {
                        //Chilkitmail();
                        GetReport();
                        //int unbnd = Convert.ToInt32(lblSent.Text) - (Convert.ToInt32(lblhardbounce.Text) + Convert.ToInt32(lblsoftbounce.Text));
                        //int hardbouncepercent = (Convert.ToInt32(lblhardbounce.Text) / Convert.ToInt32(lblSent.Text)) * 100;
                        //int softbouncepercent = (Convert.ToInt32(lblsoftbounce.Text) / Convert.ToInt32(lblSent.Text)) * 100;
                        //int unbouncepercent = (unbnd / Convert.ToInt32(lblSent.Text)) * 100;
                        //btn.Attributes.Add("onclick", "chartshow("+ hardbouncepercent +", "+ softbouncepercent +", "+ unbouncepercent +");");
                        ////btn.Attributes.Add("onclick", "chartshow();");
                    }
                }               

            }
        }

        //select *,(select COUNT(IsMailSent) from dbo.EC_CampaignQueue where FK_CampaignID =65 and IsMailSent = 1) as MailSent,(select count(isBounced) from dbo.EC_CampaignQueue where FK_CampaignID =65 and isBounced = 1) as softbounce, (select count(IsHardBounce) from dbo.EC_CampaignQueue where FK_CampaignID =65 and IsHardBounce = 1) as hardbounce, (select COUNT(IsRead) from dbo.EC_CampaignQueue where FK_CampaignID =65 and IsRead = 1) as IsRead, (select COUNT(ReadCount) from dbo.EC_CampaignQueue where FK_CampaignID =65 and ReadCount = 1) as ReadCount, (select sum(ReadCount) from dbo.EC_CampaignQueue where FK_CampaignID =65) as TotalReadCount,(select COUNT(PK_CampaignQueueID) from dbo.EC_CampaignQueue where FK_CampaignID =65) as Recipients from dbo.EC_Campaign where CampaignStatus = 1 and PK_CampaignID = 65
        private void Chilkitmail()
        {
             Chilkat.MailMan mailman = new Chilkat.MailMan();
            mailman.UnlockComponent("MailUnlockCode");
            mailman.MailHost = "pop.gmail.com";
            mailman.MailPort = 995;
            mailman.PopUsername = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailID"].ToString();
            mailman.PopPassword = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailPassword"].ToString();
            mailman.ConnectTimeout = 200000;
            mailman.ReadTimeout = 200000;
            Chilkat.Bounce bounce = new Chilkat.Bounce();
            bool success = bounce.UnlockComponent("MailUnlockCode");

            if (!success)
            {
                //TextBox1.Text = bounce.LastErrorText;
                return;
            }

            Chilkat.EmailBundle bundle;
            //object bndlmail;
            bundle = mailman.CopyMail();
            //int numBodyLines = 1;
            //bundle = mailman.GetAllHeaders(numBodyLines);

            if (bundle != null)
            {
                // Loop over each email...
                Chilkat.Email email;
                int i;
                bool success1;
                for (i = 0; i < bundle.MessageCount; i++)
                {
                    email = bundle.GetEmail(i);
                    string gmailuid = email.Uidl;
                    string content = "";
                    success1 = bounce.ExamineEmail(email);
                    string bouncecolumn = "";

                    //if (!success1)
                    //    listBox1.Items.Add("Failed to classify email");
                    if (bounce.BounceType == 1)
                    {
                        // Hard bounce, log the email address                        
                        content = pop3recievecontent(gmailuid);
                        bouncecolumn = "IsHardBounce";
                    }
                    else if (bounce.BounceType == 2)
                    {
                        // Soft bounce, log the email address
                        content = pop3recievecontent(gmailuid);
                        bouncecolumn = "isBounced";
                    }
                    else if (bounce.BounceType == 3)
                    {
                        // General bounce, no email address available.
                        content = pop3recievecontent(gmailuid);
                        bouncecolumn = "isBounced";
                    }
                    email = null;
                    if (content != "")
                    {
                        if (content.Contains("Disposition-Notification-To: <"))
                        {
                            string ll = "Disposition-Notification-To: <";
                            int posA = content.IndexOf("Disposition-Notification-To: <");
                            int posB = content.LastIndexOf(">");
                            int adjustedPosA = posA + ll.Length;
                            string uu = content.Substring(adjustedPosA, posB - adjustedPosA);
                            string isexist = objBL_Common.IsValidUser("MailFailedContent", "EC_CampaignQueue", "PK_CampaignQueueID =" + Convert.ToInt32(uu) + "");
                            
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@UserName";
                            param.Value = content;

                            if (isexist == "")
                                objBL_Common.AccessUpdatecampue("EC_CampaignQueue", "" + bouncecolumn + "= 'true', MailFailedContent = @UserName ", "PK_CampaignQueueID =" + Convert.ToInt32(uu) + "" ,content);
                        }
                    }
                }
                bundle = null;
            }
            mailman = null;
        }     
        private string pop3recievecontent(string gmailuid)
        {
            Pop3Client pop3Client = null;
            pop3Client = new Pop3Client();
            pop3Client.Connect("pop.gmail.com", 995, true);
            pop3Client.Authenticate("sakthivel@aryvart.com", "chp@2015", AuthenticationMethod.TryBoth);
            int count = pop3Client.GetMessageCount();
            this.Emails = new List<Email1>();
            int counter = 0;
            for (int j = count; j >= 1; j--)
            {
                Message message = pop3Client.GetMessage(j);
                string hh1 = pop3Client.GetMessageUid(j);

                if (gmailuid == hh1)
                {
                    Email1 email1 = new Email1()
                    {
                        MessageNumber = j,
                        Subject = message.Headers.Subject,
                        DateSent = message.Headers.DateSent,

                        From = string.Format("<a href = 'mailto:{1}'>{0}</a>", message.Headers.From.DisplayName, message.Headers.From.Address),
                    };

                    MessagePart body = message.FindFirstHtmlVersion();

                    if (body != null)
                    {
                        email1.Body = body.GetBodyAsText();
                        return email1.Body;
                    }
                    else
                    {
                        body = message.FindFirstPlainTextVersion();

                        if (body != null)
                        {
                            email1.Body = body.GetBodyAsText();
                            return email1.Body;
                        }
                    }

                    this.Emails.Add(email1);
                }
                counter++;
            }
            return "";
        }

        private void GetReport()
        {
            try
            {
                DataTable dtgetreport = new DataTable();
                dtgetreport = objBL_Common.campaignreport(Convert.ToInt32(Request.QueryString["CamprptId"].ToString()));

                if (dtgetreport.Rows.Count > 0)
                {
                    lblCampname.Text = dtgetreport.Rows[0].Field<string>("CampaignName").ToString();
                    lblRecipients.Text = dtgetreport.Rows[0].Field<int>("Recipients").ToString();
                    lblfromname.Text = dtgetreport.Rows[0].Field<string>("FromName").ToString();
                    lblSubject.Text = dtgetreport.Rows[0].Field<string>("Title").ToString();
                    lblDelivered.Text = dtgetreport.Rows[0].Field<DateTime>("SchduleDateTime").ToString();
                    lblSent.Text = dtgetreport.Rows[0].Field<int>("MailSent").ToString();
                    lblClick.Text = dtgetreport.Rows[0].Field<int>("IsRead").ToString();
                    lblbounced.Text = (dtgetreport.Rows[0].Field<int>("softbounce") + dtgetreport.Rows[0].Field<int>("hardbounce")).ToString();
                    lblsoftbounce.Text = dtgetreport.Rows[0].Field<int>("softbounce").ToString();
                    lblhardbounce.Text = dtgetreport.Rows[0].Field<int>("hardbounce").ToString();
                    lbltotalsentmail.Text = dtgetreport.Rows[0].Field<int>("MailSent").ToString();
                    int mailpercent = (((dtgetreport.Rows[0].Field<int>("MailSent") - Convert.ToInt32(lblbounced.Text)) / dtgetreport.Rows[0].Field<int>("MailSent")) * 100);
                    int openpercent = ((dtgetreport.Rows[0].Field<int>("IsRead") / dtgetreport.Rows[0].Field<int>("MailSent")) * 100);
                    lbltotalsentmailpercent.Text = mailpercent.ToString() + "%";
                    lblopenrate.Text = dtgetreport.Rows[0].Field<int>("IsRead").ToString();
                    lblopenratepercent.Text = openpercent.ToString() + "%";
                    lblsuccdeliver.Text = (dtgetreport.Rows[0].Field<int>("MailSent") - Convert.ToInt32(lblbounced.Text)).ToString();
                    lbltotopens.Text = dtgetreport.Rows[0].Field<int>("TotalReadCount").ToString();
                    lblnotopen.Text = ((dtgetreport.Rows[0].Field<int>("MailSent") - dtgetreport.Rows[0].Field<int>("IsRead")) - Convert.ToInt32(lblbounced.Text)).ToString();
                    lbltotclicks.Text = dtgetreport.Rows[0].Field<int>("IsRead").ToString();

                    spdelrate.Style["width"] = mailpercent + "%";
                    spopenrate.Style["width"] = openpercent + "%";

                    //ScriptManager.RegisterStartupScript(this, Page.GetType(), "mykey36", "chartmake();", true);//reportchart('35','35','30')
                }
                
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReport.aspx:GetReport() - " + ex.Message);
            }
        }

        
    }
}

[Serializable]
public class Email1
{
    public Email1()
    {
        this.Attachments = new List<Attachment1>();
    }
    public int MessageNumber { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }

    public string Header { get; set; }
    public string Body { get; set; }
    public DateTime DateSent { get; set; }
    public List<Attachment1> Attachments { get; set; }
}
[Serializable]
public class Attachment1
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] Content { get; set; }
}