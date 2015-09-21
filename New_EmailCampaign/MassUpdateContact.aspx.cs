using System;
using BALayer;

namespace New_EmailCampaign
{
    public partial class MassUpdateContact : System.Web.UI.Page
    {
        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btngridsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objBL_Common = new BL_Common();
                string columnname = string.Empty;

                if (ddlcolumn.SelectedValue == "1")
                    columnname = "Designation";
                else if (ddlcolumn.SelectedValue == "2")
                    columnname = "City1";
                else if (ddlcolumn.SelectedValue == "3")
                    columnname = "State1";
                else if (ddlcolumn.SelectedValue == "4")
                    columnname = "Country1";
                else if (ddlcolumn.SelectedValue == "5")
                    columnname = "Addressline1";

                objBL_Common.AccessUpdateAllCampaign("EC_UserContacts", "" + columnname + " = '" + txtCampName.Value.Trim() + "' ", "PK_ContactID  in (" + Session["massupdatecontid"].ToString() + ")");
                lblcontact.Text = "Your contact details are updated successfully.";
                lblcontact.CssClass = "labelsuccess";
                ddlcolumn.SelectedValue = "0";
                txtCampName.Value = "";
                Session["massupdatecontid"] = null;
                Session.Remove("massupdatecontid");
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("MassUpdateContact.aspx:btngridsubmit_Click() - " + ex.Message);
            }
        }
    }
}