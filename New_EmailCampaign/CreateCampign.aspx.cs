using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using System.Web;
using BALayer;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;


namespace New_EmailCampaign
{
    /// <summary>
    /// Created By :: Sakthivel.R
    /// Created On :: 25-3-2015
    /// Comments :: Creating campaign for email.
    /// </summary>
    public partial class CreateCampign : System.Web.UI.Page
    {
        Campaign objCampaign = new Campaign();
        BL_CreateCampaign objBL_CreateCampaign = new BL_CreateCampaign();
        List<Campaign> lstCampaign = new List<Campaign>();

        UserContacts objUserContacts = new UserContacts();
        BL_UserContacts objBL_UserContacts = new BL_UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();

        CampaignQueue objCampaignQueue = new CampaignQueue();
        BL_CampaignQueue objBL_CampaignQueue = new BL_CampaignQueue();
        List<CampaignQueue> lstCampaignQueue = new List<CampaignQueue>();

        BL_ScheduleMailDetails objBL_ScheduleMailDetails = new BL_ScheduleMailDetails();
        ScheduleMailDetails objScheduleMailDetails = new ScheduleMailDetails();
        List<ScheduleMailDetails> lstScheduleMailDetails = new List<ScheduleMailDetails>();

        BL_Common objBL_Common = new BL_Common();
        //string strConnString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;

        MailTemplate objMailTemplate = new MailTemplate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    if (Request.QueryString["CampgnID"] != null)
                    {
                        Session["CampgnID"] = HttpUtility.UrlDecode(Request.QueryString["CampgnID"]).ToString();
                    }
                    if (Session["CampgnID"] != null)
                        RetrieveCampaigndetails();
                    if (Session["SelectContactID"] != null)
                    {
                        gridcontactsbind();
                        Collapse2.Attributes["class"] = "akordeon-item expanded";
                        Collapse1.Attributes["class"] = "akordeon-item collapsed";
                    }
                    BindAllTimeZones();

                }
            }
        }

        private void RetrieveCampaigndetails()
        {
            try
            {
                objCampaign = new Campaign();
                objBL_CreateCampaign = new BL_CreateCampaign();
                lstCampaign = objBL_CreateCampaign.SelectCampaignListbasedonid(Convert.ToInt32(Session["CampgnID"].ToString()));

                if (lstCampaign.Count > 0)
                {
                    txtCampaignName.Value = lstCampaign[0].CampaignName;
                    txtTitle.Value = lstCampaign[0].Title;

                    if (lstCampaign[0].FromName != null)
                        FromName.Value = lstCampaign[0].FromName;
                    if (lstCampaign[0].FromName != null)
                        EmailID.Value = lstCampaign[0].Emailid;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:RetrieveCampaigndetails() - " + ex.Message);
            }

        }

        private void gridcontactsbind()
        {
            try
            {
                objUserContacts = new UserContacts();
                lstUserContacts = new List<UserContacts>();
                objBL_UserContacts = new BL_UserContacts();
                lstUserContacts = objBL_UserContacts.SelectContactsonSelectedID(Convert.ToInt32(Session["CompanyID"].ToString()), Session["SelectContactID"].ToString());
                gvAddContacts.DataSource = lstUserContacts;
                gvAddContacts.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:gridcontactsbind() - " + ex.Message);
            }
        }



        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 27-3-2015
        /// Comments :: Populating all time zone in a Drop Down List.
        /// </summary>
        public void BindAllTimeZones()
        {
            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                ddlTimeZone.Items.Add(new ListItem(timeZone.DisplayName, timeZone.Id));
            }

            ddlTimeZone.Items.Insert(0, "-- Select --");
        }

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 27-3-2015
        /// Comments :: Inserting all values of campaign form.
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objCampaign = new Campaign();
                objCampaign.FK_UserID = Convert.ToInt32(Session["UserID"].ToString());
                objCampaign.CampaignName = txtCampaignName.Value.ToString().Trim();
                objCampaign.Title = txtTitle.Value.ToString().Trim();

                string dttime = dtScheduledatetime.Value;
                string[] dateString = dttime.Split('/');
                DateTime enter_date = Convert.ToDateTime(dateString[1] + "/" + dateString[0] + "/" + dateString[2]);
                DateTime utcTime = enter_date.ToUniversalTime();
                objCampaign.Utctime = utcTime;

                objCampaign.SchduleDateTime = enter_date;
                objCampaign.FromName = FromName.Value.ToString();
                objCampaign.Emailid = EmailID.Value.ToString();
                objCampaign.CampTimezone = ddlTimeZone.SelectedValue;
                objCampaign.CampaignStatus = false;
                //if (Editstatus == 1)
                //{
                //    objCampaign.UpdatedBy = Convert.ToInt32(Session["UserID"].ToString());
                //    objCampaign.UpdatedOn = DateTime.Now;
                //    objBL_CreateCampaign.AccessInsertCampign(objCampaign);
                //}
                //else
                //{
                //    objCampaign.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                objCampaign.CreatedOn = DateTime.Now;
                objBL_CreateCampaign.AccessInsertCampign(objCampaign);
                //}

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "Clearuserinput1();", true);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }




        protected void gvAddContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvAddContacts.PageIndex = e.NewPageIndex;
                gridcontactsbind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:gvAddContacts_PageIndexChanging() - " + ex.Message);
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.PostedFile != null)
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath(@"HTMLUploadFile\" + Path.GetFileName(FileUpload1.Value)));
                    StringBuilder sbcontent = new System.Text.StringBuilder();
                    sbcontent.Append("<html xmlns=\'http://www.w3.org/1999/xhtml\'>'<head>'<meta http-equiv=\'Content-Type\' content=\'text/html; charset=iso-8859-1\' />'<title></title>'</head><body>");
                    sbcontent.Append(ReadHtmlFile(Server.MapPath(@"HTMLUploadFile\" + Path.GetFileName(FileUpload1.Value))) + "</body></html>");
                    txta9.Value = sbcontent.ToString();
                }

                //string htmlFileNameWithPath = Server.MapPath(FileUpload1.Value); Path.GetDirectoryName(FileUpload1.Value);//FileUpload1.PostedFile.ToString() + FileUpload1.Value;

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:btnupload_Click() - " + ex.Message);
            }
        }
        public static System.Text.StringBuilder ReadHtmlFile(string htmlFileNameWithPath)
        {
            StringBuilder storeContent = new System.Text.StringBuilder();

            try
            {
                using (System.IO.StreamReader htmlReader = new System.IO.StreamReader(htmlFileNameWithPath))
                {
                    string lineStr;
                    while ((lineStr = htmlReader.ReadLine()) != null)
                    {
                        storeContent.Append(lineStr);
                    }
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:ReadHtmlFile() - " + ex.Message);
            }
            return storeContent;
        }

        protected void btngridsubmit_Click(object sender, EventArgs e)
        {
            string CampTimezone = ddlTimeZone.SelectedValue;
            string dttime = dtScheduledatetime.Value;
            string[] dateString = dttime.Split('/');
            DateTime enter_date = Convert.ToDateTime
            (dateString[1] + "/" + dateString[0] + "/" + dateString[2]);
            DateTime indtime;
            DateTime utcTime = enter_date.ToUniversalTime();

            if (ddlTimeZone.SelectedIndex > 0)
            {
                indtime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(enter_date.ToString()), ddlTimeZone.SelectedValue, TimeZoneInfo.Local.Id);
                utcTime = new DateTime();
                utcTime = indtime.ToUniversalTime();
                objCampaign.Utctime = utcTime;
            }
            //else
            //    objCampaign.Utctime = utcTime;


            //objCampaign.SchduleDateTime = enter_date;
            string body = txta9.Value;

            if (body != "" && gvAddContacts.Rows.Count > 0)
            {
                objBL_Common = new BL_Common();

                objBL_Common.AccessUpdateAllCampaign("EC_Campaign", "Utctime = '" + utcTime + "', CampTimezone = '" + ddlTimeZone.SelectedValue + "', mailcontent = '" + body + "', CampaignStatus = " + 0 + ", SchduleDateTime = '" + enter_date + "' ", "PK_CampaignID =" + Convert.ToInt32(Session["CampgnID"].ToString()) + "");

                for (int i = 0; i < gvAddContacts.Rows.Count; i++)
                {
                    string tomailid = gvAddContacts.Rows[i].Cells[5].Text.ToString();
                    int contactid = 0;
                    Label lblEmpID = (Label)gvAddContacts.Rows[i].Cells[0].FindControl("lblThirdPartyId");

                    if (gvAddContacts.Rows[i].Cells[0].Text.ToString() != null)
                        contactid = Convert.ToInt32(lblEmpID.Text.ToString());
                    CampaignQueueInsert(false, contactid);
                }
                //objBL_Common = new BL_Common();
                //objBL_Common.AccessUpdateAllCampaign("EC_Campaign", "CampaignStatus = " + 0 + "", "PK_CampaignID =" + Convert.ToInt32(Session["CampgnID"].ToString()) + "");
                objBL_ScheduleMailDetails = new BL_ScheduleMailDetails();
                objScheduleMailDetails = new ScheduleMailDetails();
                Label lblEmpID1 = (Label)gvAddContacts.Rows[0].Cells[0].FindControl("lblThirdPartyId");
                objScheduleMailDetails.FK_ContactID = Convert.ToInt32(lblEmpID1.Text.ToString());
                objScheduleMailDetails.Scheduledatetime = utcTime;
                objScheduleMailDetails.FK_Scheduleby = Convert.ToInt32(Session["UserID"].ToString());
                objScheduleMailDetails.QueueStatus = false;
                objScheduleMailDetails.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                objScheduleMailDetails.CreatedOn = DateTime.Now;
                objScheduleMailDetails.FK_CampaignID = Convert.ToInt32(Session["CampgnID"].ToString());
                objBL_ScheduleMailDetails.AccessInsertScheduleMailDetails(objScheduleMailDetails);
                objScheduleMailDetails = null;
                objBL_ScheduleMailDetails = null;
                Session["SelectContactID"] = null;
                Session.Remove("SelectContactID");
                Session["CampgnID"] = null;
                Session.Remove("CampgnID");
                //ClientScript.RegisterStartupScript(Page.GetType(), "mykey26", "alert('Your schedule mail content text message or Choose Recipients to send a mail!');", true);
                Response.Redirect("MailScheduleSuccess.aspx", false);
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey25", "alert('Enter your mail content text message or Choose time zone and Recipients to send a mail!');", true);
            }

        }

        private string CampaignQueueInsert(bool status, int contactid)
        {
            objCampaignQueue = new CampaignQueue();
            objBL_CampaignQueue = new BL_CampaignQueue();
            objCampaignQueue.FK_CampaignID = Convert.ToInt32(Session["CampgnID"].ToString());

            if (status == true)
                objCampaignQueue.SentOn = DateTime.Now;

            objCampaignQueue.IsMailSent = status;
            objCampaignQueue.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
            objCampaignQueue.CreatedOn = DateTime.Now;

            if (contactid != 0)
                objCampaignQueue.FK_ContactID = contactid;

            string pkcqid = objBL_CampaignQueue.AccessInsertCampignQueue(objCampaignQueue);
            objCampaignQueue = null;
            objBL_CampaignQueue = null;
            return pkcqid;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string body = txta9.Value;
                if (body != "")
                {
                    objBL_Common.AccessUpdateAllCampaign("EC_Campaign", "mailcontent = '" + body + "'", "PK_CampaignID =" + Convert.ToInt32(Session["CampgnID"].ToString()) + "");
                    string destcc = "sakthivel@aryvart.com";
                    string fromEmailID = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailID"].ToString();
                    string fromPassword = System.Configuration.ConfigurationSettings.AppSettings["AryvartAdminEmailPassword"].ToString();

                    for (int i = 0; i < gvAddContacts.Rows.Count; i++)
                    {
                        string tomailid = gvAddContacts.Rows[i].Cells[5].Text.ToString();
                        int contactid = 0;
                        Label lblEmpID = (Label)gvAddContacts.Rows[i].Cells[0].FindControl("lblThirdPartyId");

                        if (gvAddContacts.Rows[i].Cells[0].Text.ToString() != null)
                            contactid = Convert.ToInt32(lblEmpID.Text.ToString());

                        string CQIID = CampaignQueueInsert(false, contactid);
                        int PKID = 0;

                        if (CQIID != null)
                        {
                            PKID = Convert.ToInt32(CQIID);
                            var deliveryProcessor = "http://localhost:3735/checkmailreadcount.aspx";
                            var imgTag = string.Format(@"<img src=""{0}?msg_id={1}""  width=""0"" height=""0"" 
                           style=""width: 0px; height: 0px; border:0px;"" alt=""""/>",
                                       deliveryProcessor, PKID);
                            body += imgTag;
                        }

                        objMailTemplate.fnSendMailToRecipients(fromEmailID, fromPassword, body, destcc, txtTitle.Value.ToString(), tomailid, EmailID.Value.ToString().Trim(), PKID);
                        objBL_Common.AccessUpdateAllCampaign("EC_CampaignQueue", "IsMailSent = " + 1 + ", SentOn = '" + DateTime.Now + "'", "PK_CampaignQueueID =" + Convert.ToInt32(PKID) + "");
                    }

                    objBL_Common = new BL_Common();
                    objBL_Common.AccessUpdateAllCampaign("EC_Campaign", "CampaignStatus = " + 1 + ", SchduleDateTime='" + DateTime.Now + "'", "PK_CampaignID =" + Convert.ToInt32(Session["CampgnID"].ToString()) + "");
                    //ClientScript.RegisterStartupScript(Page.GetType(), "mykey32", "alert('Mail sent successfully to all the recepients.');", true);
                    Session["SelectContactID"] = null;
                    Session.Remove("SelectContactID");
                    Session["CampgnID"] = null;
                    Session.Remove("CampgnID");
                    Response.Redirect("MailSentSuccess.aspx", false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey25", "alert('Enter your mail content text message to send a mail!');", true);
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:Button1_Click() - " + ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //btngridsubmit_Click(sender, e);

        }

        protected void ddlTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime indtime;
            //indtime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "New Zealand Standard Time", "UTC");
            //indtime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(dtScheduledatetime.Value.ToString()), ddlTimeZone.SelectedValue, "UTC");
            ////DateTime dt = DateTime.Now;
            ////string hh = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dt,TimeZoneInfo.Local.Id, ddlTimeZone.SelectedValue).ToString();
            ////DateTime indtime;
            //indtime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "New Zealand Standard Time", "UTC");
            if (ddlTimeZone.SelectedIndex > 0)
            {
                indtime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(Convert.ToDateTime(dtScheduledatetime.Value.ToString()), ddlTimeZone.SelectedValue, TimeZoneInfo.Local.Id);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                //    Imap client = new Imap();
                //// connect to server

                //client.Connect("imap.gmail.com", 993, SslMode.Implicit);

                //// authenticate
                //client.Login("username", "password");

                //// select folder
                //client.SelectFolder("Inbox");

                //int NoOfEmailsPerPage = 10;
                //int totalEmails = client.CurrentFolder.TotalMessageCount;
                //// get message list - envelope headers
                //ImapMessageCollection messages = client.GetMessageList(ImapListFields.Envelope);

                //// display info about each message


                //foreach (ImapMessageInfo message in messages)
                //{

                //    TableCell noCell = new TableCell();

                //    noCell.CssClass = "emails-table-cell";

                //    noCell.Text = Convert.ToString(message.To);
                //    TableCell fromCell = new TableCell();
                //    fromCell.CssClass = "emails-table-cell";
                //    fromCell.Text = Convert.ToString(message.From);
                //    TableCell subjectCell = new TableCell();
                //    subjectCell.CssClass = "emails-table-cell";
                //    subjectCell.Style["width"] = "300px";
                //    subjectCell.Text = Convert.ToString(message.Subject);
                //    TableCell dateCell = new TableCell();
                //    dateCell.CssClass = "emails-table-cell";
                //    if (message.Date.OriginalTime != DateTime.MinValue)
                //        dateCell.Text = message.Date.OriginalTime.ToString();
                //    TableRow emailRow = new TableRow();
                //    emailRow.Cells.Add(noCell);
                //    emailRow.Cells.Add(fromCell);
                //    emailRow.Cells.Add(subjectCell);
                //    emailRow.Cells.Add(dateCell);
                //    EmailsTable.Rows.AddAt(2 + 0, emailRow);

                //}
                //int totalPages;
                //int mod = totalEmails % NoOfEmailsPerPage;
                //if (mod == 0)
                //    totalPages = totalEmails / NoOfEmailsPerPage;
                //else
                //    totalPages = ((totalEmails - mod) / NoOfEmailsPerPage) + 1;

               
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateCampign.aspx:Button1_Click() - " + ex.Message);
            }
        }
    }
}

    
