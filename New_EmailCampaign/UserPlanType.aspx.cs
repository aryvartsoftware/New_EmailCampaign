using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web;

namespace New_EmailCampaign
{
    public partial class UserPlanType : System.Web.UI.Page
    {
        Userplantype objUserplantype = new Userplantype();
        BL_PlanType objBL_PlanType = new BL_PlanType();
        List<Userplantype> lstUserplantype = new List<Userplantype>();

        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    if (Request.QueryString["PlantypId"] != null)
                        RetrieveUserplantype();

                }
            }
        }

        #region Retrieve_Records_Based_on_Userplantypeid
        public void RetrieveUserplantype()
        {
            try
            {
                objUserplantype = new Userplantype();
                objBL_PlanType = new BL_PlanType();
                lstUserplantype = new List<Userplantype>();
                lstUserplantype = objBL_PlanType.SelectUserplantypeforcampid(Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["PlantypId"]).ToString()));

                if (lstUserplantype.Count > 0)
                {
                    //txta1.Value = lstUserplantype[0].Message;
                    txtCampaignName.Value = lstUserplantype[0].PlanName;
                    
                    if (lstUserplantype[0].IsSingleUser == true)
                        rbuserselect.SelectedValue = "1";
                    else
                        rbuserselect.SelectedValue = "0";


                    txtPlanRate.Value = lstUserplantype[0].Planrate.ToString();
                    txtnosubscribers.Value = lstUserplantype[0].NOC.ToString();
                    txtnomails.Value = lstUserplantype[0].AllowedMails.ToString();
                    
                    if(lstUserplantype[0].IsActive == true)
                        chkactive.Checked = true;

                }
                lstUserplantype = null;
                objBL_PlanType = null;
                objUserplantype = null;
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanType.aspx:RetrieveUserplantype() - " + ex.Message);
            }
        }

        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objUserplantype = new Userplantype();
                lstUserplantype = new List<Userplantype>();

                if (Request.QueryString["PlantypId"] != null)
                {
                    objUserplantype = new Userplantype();
                    lstUserplantype = new List<Userplantype>();
                    objBL_PlanType = new BL_PlanType();
                    lstUserplantype = objBL_PlanType.SelectUserplantypeforcampid(Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["PlantypId"]).ToString()));

                    if (lstUserplantype.Count > 0)
                    {
                        objBL_Common.AccessUpdateAllCampaign("EC_PlanType", "PlanName= '" + txtCampaignName.Value + "', IsSingleUser= " + Convert.ToInt32(rbuserselect.SelectedValue) + ", Planrate= " + txtPlanRate.Value + ", NOC= " + txtnosubscribers.Value + ", AllowedMails = " + txtnomails.Value + ", UpdatedBy = " + Convert.ToInt32(Session["UserID"].ToString()) + ", UpdatedOn = '" + DateTime.Now + "' ", "PK_PlanID =" + Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["PlantypId"]).ToString()) + "");
                    }
                    lstUserplantype = null;
                    objUserplantype = null;
                    objBL_PlanType = null;
                    //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "Clearuserinput2();", true);
                }
                else
                {
                    objUserplantype.PlanName = txtCampaignName.Value;

                    if(Convert.ToInt32(rbuserselect.SelectedValue) == 1)
                        objUserplantype.IsSingleUser = true;
                    else
                        objUserplantype.IsSingleUser = false;

                    objUserplantype.Planrate = Convert.ToInt32(txtPlanRate.Value);
                    objUserplantype.NOC = Convert.ToInt32(txtnosubscribers.Value);
                    objUserplantype.AllowedMails = Convert.ToInt32(txtnomails.Value);
                    
                    if(chkactive.Checked == true)
                        objUserplantype.IsActive = true;
                    else
                        objUserplantype.IsActive = false;

                    objUserplantype.Plandate = DateTime.Now;
                    objUserplantype.CreatedOn = DateTime.Now;
                    objUserplantype.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    objBL_PlanType.AccessInsertUserplantype(objUserplantype);
                    
                    }
                   ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "Clearuserinput2();", true);
                }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanType.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
    }
}