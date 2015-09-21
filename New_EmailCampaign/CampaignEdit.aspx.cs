using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web.UI.WebControls;
using System.Web;

namespace New_EmailCampaign
{
    public partial class CampaignEdit : System.Web.UI.Page
    {
        Campaign objCampaign = new Campaign();
        BL_CreateCampaign objBL_CreateCampaign = new BL_CreateCampaign();
        List<Campaign> lstCampaign = new List<Campaign>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    if (Request.QueryString["CampId"] != null)
                        RetrieveCampaign();
                }
            }
        }

        #region Retrieve_Records_Based_on_Campaignid
        public void RetrieveCampaign()
        {
            try
            {
                objCampaign = new Campaign();
                objBL_CreateCampaign = new BL_CreateCampaign();
                lstCampaign = objBL_CreateCampaign.SelectCampaignListbasedonid(Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["CampId"]).ToString()));
                
                if (lstCampaign.Count > 0)
                {
                    txtCampaignName.Value = lstCampaign[0].CampaignName;
                    txtTitle.Value = lstCampaign[0].Title;

                    if(lstCampaign[0].FromName != null)
                        FromName.Value = lstCampaign[0].FromName;
                    if (lstCampaign[0].Emailid != null)
                        EmailID.Value = lstCampaign[0].Emailid;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignEdit.aspx:RetrieveCampaign() - " + ex.Message);
            }
        }

        #endregion
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 20-5-2015
        /// Comments :: Inserting all values of campaign form.
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objCampaign = new Campaign();
                lstCampaign = new List<Campaign>();
                objCampaign.FK_UserID = Convert.ToInt32(Session["UserID"].ToString());
                objCampaign.CampaignName = txtCampaignName.Value.ToString().Trim();
                objCampaign.Title = txtTitle.Value.ToString().Trim();

                //string dttime = dtScheduledatetime.Value;
                //string[] dateString = dttime.Split('/');
                //DateTime enter_date = Convert.ToDateTime(dateString[1] + "/" + dateString[0] + "/" + dateString[2]);
                //DateTime utcTime = enter_date.ToUniversalTime();
                //objCampaign.Utctime = utcTime;

                //objCampaign.SchduleDateTime = enter_date;
                objCampaign.FromName = FromName.Value.ToString();
                objCampaign.Emailid = EmailID.Value.ToString();
                
                //objCampaign.CampTimezone = ddlTimeZone.SelectedValue;
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
                if (Request.QueryString["CampId"] != null)
                {
                    objCampaign.PK_CampaignID = Convert.ToInt32(Request.QueryString["CampId"].ToString());
                    objCampaign.UpdatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    objCampaign.UpdatedOn = DateTime.Now;
                    lstCampaign = objBL_CreateCampaign.SelectCampaignListbasedonid(Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["CampId"]).ToString()));

                    if (lstCampaign.Count > 0)
                    {
                        //if(lstCampaign[0].FK_UserID != null)
                            objCampaign.FK_UserID = lstCampaign[0].FK_UserID;
                        if (lstCampaign[0].SchduleDateTime != null)
                            objCampaign.SchduleDateTime = lstCampaign[0].SchduleDateTime;
                        if (lstCampaign[0].CampTimezone != null)
                            objCampaign.CampTimezone = lstCampaign[0].CampTimezone;
                        if (lstCampaign[0].Utctime != null)
                            objCampaign.Utctime = lstCampaign[0].Utctime;
                        if (lstCampaign[0].CampaignStatus != null)
                            objCampaign.CampaignStatus = lstCampaign[0].CampaignStatus;

                        if (lstCampaign[0].CreatedOn != null)
                            objCampaign.CreatedOn = lstCampaign[0].CreatedOn;
                        if (lstCampaign[0].CreatedBy != null)
                            objCampaign.CreatedBy = lstCampaign[0].CreatedBy;
                    }
                    objBL_CreateCampaign.AccessUpdateCampign(objCampaign);
                }
                else
                {
                    objCampaign.CreatedOn = DateTime.Now;
                    objCampaign.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    objBL_CreateCampaign.AccessInsertCampign(objCampaign);
                }

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "Clearuserinput1();", true);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignEdit.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }

    }
}