using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailCampaign
{
    public partial class createlist : System.Web.UI.Page
    {
        ListContacts objListContacts = new ListContacts();
        BL_ListContacts objBL_ListContacts = new BL_ListContacts();
        List<ListContacts> lstListContacts = new List<ListContacts>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = "";
                objListContacts = new ListContacts();
                objBL_ListContacts = new BL_ListContacts();
                objListContacts.Comments = txta11.Value;
                objListContacts.CreatedBy = Convert.ToInt16(Session["UserID"].ToString());
                objListContacts.CreatedOn = DateTime.Now;
                objListContacts.FK_CompanyID = Convert.ToInt16(Session["CompanyID"].ToString());
                objListContacts.ListName = txtUserName.Value;
                objBL_ListContacts.AccessInsertContacts(objListContacts);
                objListContacts = null;
                objBL_ListContacts = null;
                Label1.Text = "List Created Successfully.";
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey17", " $('input[type=text], textarea').each(function () {  $(this).val('');});", true);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("createlist.aspx:btnSubmit_Click() - " + ex.Message);
            }

        }
    }
}