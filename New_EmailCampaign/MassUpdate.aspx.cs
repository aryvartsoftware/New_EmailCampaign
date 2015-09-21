using System;
using BALayer;

namespace New_EmailCampaign
{
    public partial class MassUpdate : System.Web.UI.Page
    {
        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    if(Session["massupdateid"] == null)

            //}
        }

        protected void btngridsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objBL_Common = new BL_Common();
                string columnname = string.Empty;

                if (ddlcolumn.SelectedValue == "1")
                    columnname = "CampaignName";
                else if (ddlcolumn.SelectedValue == "2")
                    columnname = "FromName";
                else if (ddlcolumn.SelectedValue == "3")
                    columnname = "Title";
                else if (ddlcolumn.SelectedValue == "4")
                    columnname = "Emailid";

                objBL_Common.AccessUpdateAllCampaign("EC_Campaign", "" + columnname + " = '" + txtCampName.Value.Trim() + "' ", "PK_CampaignID  in (" + Session["massupdateid"].ToString() + ")");
                lblcontact.Text = "Your campaign details are updated successfully.";
                lblcontact.CssClass = "labelsuccess";
                ddlcolumn.SelectedValue = "0";
                txtCampName.Value = "";
                Session["massupdateid"] = null;
                Session.Remove("massupdateid");
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("MassUpdate.aspx:btngridsubmit_Click() - " + ex.Message);
            }
        }

        
    }
}