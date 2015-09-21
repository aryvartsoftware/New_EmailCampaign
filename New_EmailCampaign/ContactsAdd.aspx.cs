using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;
using System.Globalization;
using System.Web;

namespace New_EmailCampaign
{
    public partial class ContactsAdd : System.Web.UI.Page
    {
        UserContacts objUserContacts = new UserContacts();
        BL_UserContacts objBL_UserContacts = new BL_UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();

        ListContacts objListContacts = new ListContacts();
        BL_ListContacts objBL_ListContacts = new BL_ListContacts();
        List<ListContacts> lstListContacts = new List<ListContacts>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    if (Request.QueryString["CntId"] != null)
                        RetrieveContact();
                }
            }
        }

        #region Retrieve_Records_Based_on_Campaignid
        public void RetrieveContact()
        {
            try
            {
                objUserContacts = new UserContacts();
                objBL_UserContacts = new BL_UserContacts();
                lstUserContacts = objBL_UserContacts.SelectUserContactsListforgrid(Convert.ToInt16(HttpUtility.UrlDecode(Request.QueryString["CntId"]).ToString()));

                if (lstUserContacts.Count > 0)
                {
                    txtCampaignName.Value = lstUserContacts[0].ContactName;
                    EmailID.Value = lstUserContacts[0].Email_id;

                    if (lstUserContacts[0].DateofBirth != null)
                    {
                        DateTime dt = Convert.ToDateTime(lstUserContacts[0].DateofBirth.ToString());
                        ;
                        dtScheduledatetime.Value = String.Format("{0:dd/MM/yyyy}", dt);
                    }
                    if (lstUserContacts[0].Email_id != null)
                        EmailID.Value = lstUserContacts[0].Email_id;
                    if (lstUserContacts[0].City1 != null)
                        City.Value = lstUserContacts[0].City1;
                        if (lstUserContacts[0].Country1 != null)
                            Country.Value = lstUserContacts[0].City1;
                        if (lstUserContacts[0].Designation != null)
                            Designation.Value = lstUserContacts[0].Designation;
                            if (lstUserContacts[0].ContactNo != null)
                                ContactNo.Value = lstUserContacts[0].ContactNo;
                            if (lstUserContacts[0].Addressline1 != null)
                                Address.Value = lstUserContacts[0].Addressline1;
                                if (lstUserContacts[0].State1 != null)
                                    State.Value = lstUserContacts[0].State1;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsAdd.aspx:RetrieveContact() - " + ex.Message);
            }
        }

        #endregion

         /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 21-5-2015
        /// Comments :: Inserting all values of contact form.
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               objUserContacts = new UserContacts();
                lstListContacts = new List<ListContacts>();

                objUserContacts.FK_UserID = Convert.ToInt32(Session["UserID"].ToString());
                objUserContacts.Designation = Designation.Value.ToString().Trim();
                objUserContacts.Email_id = EmailID.Value.ToString().Trim();
                objUserContacts.ContactName = txtCampaignName.Value.ToString().Trim();
                objUserContacts.Addressline1 = Address.Value.ToString().Trim();
                objUserContacts.City1 = City.Value.ToString().Trim();
                objUserContacts.State1 = State.Value.ToString().Trim();
                objUserContacts.Country1 = Country.Value.ToString().Trim();
                objUserContacts.ContactNo = ContactNo.Value.ToString().Trim();

                if (dtScheduledatetime.Value != string.Empty)
                {
                    //DateTime dt = Convert.ToDateTime(dtScheduledatetime.Value.ToString());
                    //String.Format("{0:dd/MM/yyyy}", dt);
                    objUserContacts.DateofBirth = Convert.ToDateTime(dtScheduledatetime.Value);
                }
                if (Request.QueryString["CntId"] != null)
                {
                    objUserContacts.PK_ContactID = Convert.ToInt32(Request.QueryString["CntId"].ToString());
                    objUserContacts.UpdatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    objUserContacts.UpdatedOn = DateTime.Now;
                    lstUserContacts = objBL_UserContacts.SelectUserContactsListforgrid(Convert.ToInt16(HttpUtility.UrlDecode(Request.QueryString["CntId"]).ToString()));

                    if (lstUserContacts.Count > 0)
                    {
                        if(lstUserContacts[0].FK_UserID != null)
                            objUserContacts.FK_UserID = lstUserContacts[0].FK_UserID;
                        if (lstUserContacts[0].MailContent != null)
                            objUserContacts.MailContent = lstUserContacts[0].MailContent;

                        if (lstUserContacts[0].CreatedOn != null)
                            objUserContacts.CreatedOn = lstUserContacts[0].CreatedOn;
                        if (lstUserContacts[0].CreatedBy != null)
                            objUserContacts.CreatedBy = lstUserContacts[0].CreatedBy;
                    }
                    objBL_UserContacts.AccessUpdateContacts(objUserContacts);
                }
                else
                {
                     objUserContacts.CreatedOn = DateTime.Now;
                    objUserContacts.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    objBL_UserContacts.AccessInsertContacts(objUserContacts);
                       
                }
                 objUserContacts = null;

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "Clearuserinput1();", true);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsAdd.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }

    }
}
    