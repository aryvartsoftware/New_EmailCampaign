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
    public partial class ListView : System.Web.UI.Page
    {

        ListContacts objListContacts = new ListContacts();
        BL_ListContacts objBL_ListContacts = new BL_ListContacts();
        List<ListContacts> lstListContacts = new List<ListContacts>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindAddContactsControl()
        {
            try
            {
                objListContacts = new ListContacts();
                lstListContacts = new List<ListContacts>();
                objBL_ListContacts = new BL_ListContacts();
                lstListContacts = objBL_ListContacts.SelectListContactsListforgrid(Convert.ToInt32(ddlList.SelectedValue));
                gvlist.DataSource = lstListContacts;
                gvlist.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:BindSecurityData() - " + ex.Message);
            }
            finally
            {
                lstListContacts = null;
                objBL_ListContacts = null;
                objListContacts = null;
            }
        }


        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("ADD"))
                {
                    if (gvlist.FooterRow == null)
                    {
                        HtmlInputControl txtpasswordf = (((Control)e.CommandSource).NamingContainer).FindControl("txtpasswordf") as HtmlInputControl;
                        HtmlInputControl txtddescf = (((Control)e.CommandSource).NamingContainer).FindControl("txtddescf") as HtmlInputControl;
                        HtmlInputControl txtappnamef = (((Control)e.CommandSource).NamingContainer).FindControl("txtappnamef") as HtmlInputControl;
                        HtmlInputControl txtimpactf = (((Control)e.CommandSource).NamingContainer).FindControl("txtimpactf") as HtmlInputControl;
                        HtmlInputControl txtcriticf = (((Control)e.CommandSource).NamingContainer).FindControl("txtcriticf") as HtmlInputControl;
                        HtmlInputControl txtsernamef = (((Control)e.CommandSource).NamingContainer).FindControl("txtsernamef") as HtmlInputControl;
                        HtmlInputControl txtprevpassf = (((Control)e.CommandSource).NamingContainer).FindControl("txtprevpassf") as HtmlInputControl;
                        HtmlInputControl txtcntNof = (((Control)e.CommandSource).NamingContainer).FindControl("txtcntNof") as HtmlInputControl;

                        objListContacts = new ListContacts();
                        objListContacts.FK_UserID = Convert.ToInt32(Session["UserID"].ToString());
                        objListContacts.Designation = txtpasswordf.Value.ToString().Trim();
                        objListContacts.Email_id = txtddescf.Value.ToString().Trim();
                        objListContacts.ContactName = txtappnamef.Value.ToString().Trim();
                        objListContacts.Addressline1 = txtimpactf.Value.ToString().Trim();
                        objListContacts.City1 = txtcriticf.Value.ToString().Trim();
                        objListContacts.State1 = txtsernamef.Value.ToString().Trim();
                        objListContacts.Country1 = txtprevpassf.Value.ToString().Trim();
                        objListContacts.ContactNo = txtcntNof.Value.ToString().Trim();
                    }
                    else
                    {

                        HtmlInputControl txtappnamef = (HtmlInputControl)gvlist.FooterRow.FindControl("txtappnamef");
                        HtmlInputControl txtpasswordf = (HtmlInputControl)gvlist.FooterRow.FindControl("txtpasswordf");
                        HtmlInputControl txtddescf = (HtmlInputControl)gvlist.FooterRow.FindControl("txtddescf");
                        HtmlInputControl txtimpactf = (HtmlInputControl)gvlist.FooterRow.FindControl("txtimpactf");
                        HtmlInputControl txtcriticf = (HtmlInputControl)gvlist.FooterRow.FindControl("txtcriticf");
                        HtmlInputControl txtsernamef = (HtmlInputControl)gvlist.FooterRow.FindControl("txtsernamef");
                        HtmlInputControl txtprevpassf = (HtmlInputControl)gvlist.FooterRow.FindControl("txtprevpassf");
                        HtmlInputControl txtcntNof = (HtmlInputControl)gvlist.FooterRow.FindControl("txtcntNof");

                        objListContacts = new ListContacts();
                        objListContacts.FK_UserID = Convert.ToInt32(Session["UserID"].ToString());
                        objListContacts.Designation = txtpasswordf.Value.ToString().Trim();
                        objListContacts.Email_id = txtddescf.Value.ToString().Trim();
                        objListContacts.ContactName = txtappnamef.Value.ToString().Trim();
                        objListContacts.Addressline1 = txtimpactf.Value.ToString().Trim();
                        objListContacts.City1 = txtcriticf.Value.ToString().Trim();
                        objListContacts.State1 = txtsernamef.Value.ToString().Trim();
                        objListContacts.Country1 = txtprevpassf.Value.ToString().Trim();
                        objListContacts.ContactNo = txtcntNof.Value.ToString().Trim();
                    }

                    objListContacts.CreatedOn = DateTime.Now;
                    objListContacts.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    objListContacts.FK_ContListID = Convert.ToInt32(ddlList.SelectedValue);

                    if (objListContacts.ContactName == "" && objListContacts.Designation == "" && objListContacts.ContactName == "" && objListContacts.Addressline1 == "" && objListContacts.City1 == "" && objListContacts.State1 == "" && objListContacts.Country1 == "" && objListContacts.ContactNo == "")
                    {
                        objListContacts = null;
                        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Enter any value. Empty row cannot be added !');", true);
                    }
                    else
                    {
                        objBL_ListContacts.AccessInsertContacts(objListContacts);
                        objListContacts = null;
                        BindAddContactsControl();
                    }
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvlist_RowCommand() - " + ex.Message);
            }

        }
        protected void gvlist_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lblEmpID = (Label)gvlist.Rows[e.RowIndex].FindControl("lblEmpID");
                HtmlInputControl txtappnamee = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtappnamee");
                HtmlInputControl txtpassworde = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtpassworde");
                HtmlInputControl txtddesce = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtddesce");
                HtmlInputControl txtimpacte = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtimpacte");
                HtmlInputControl txtcritice = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtcritice");
                HtmlInputControl txtsernamee = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtsernamee");
                HtmlInputControl txtprevpasse = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtprevpasse");
                HtmlInputControl txtcntNoe = (HtmlInputControl)gvlist.Rows[e.RowIndex].FindControl("txtcntNoe");

                if (txtappnamee.Value.Trim() == "" && txtpassworde.Value.Trim() == "" && txtddesce.Value.Trim() == "" && txtimpacte.Value.Trim() == "" && txtcritice.Value.Trim() == "" && txtsernamee.Value.Trim() == "" && txtprevpasse.Value.Trim() == "" && txtcntNoe.Value.Trim() == "")
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('Enter any value. Empty row cannot be updated !');", true);
                else
                {
                    objListContacts = new ListContacts();
                    objBL_ListContacts = new BL_ListContacts();
                    lstListContacts = new List<ListContacts>();
                    lstListContacts = objBL_ListContacts.SelectListContactsListforid(Convert.ToInt16(lblEmpID.Text));

                    if (lstListContacts.Count > 0)
                    {
                        objListContacts.FK_UserID = Convert.ToInt32(Session["UserID"].ToString());
                        objListContacts.Designation = txtpassworde.Value.ToString().Trim();
                        objListContacts.Email_id = txtddesce.Value.ToString().Trim();
                        objListContacts.ContactName = txtappnamee.Value.ToString().Trim();
                        objListContacts.Addressline1 = txtimpacte.Value.ToString().Trim();
                        objListContacts.City1 = txtcritice.Value.ToString().Trim();
                        objListContacts.State1 = txtsernamee.Value.ToString().Trim();
                        objListContacts.Country1 = txtprevpasse.Value.ToString().Trim();
                        objListContacts.ContactNo = txtcntNoe.Value.ToString().Trim();
                        objListContacts.UpdatedOn = DateTime.Now;
                        objListContacts.UpdatedBy = Convert.ToInt32(Session["UserID"].ToString());
                        objListContacts.FK_ContListID = Convert.ToInt32(ddlList.SelectedValue);
                        objListContacts.PK_ContactID = Convert.ToInt16(lblEmpID.Text);
                        objListContacts.MailContent = lstListContacts[0].MailContent;
                        objListContacts.CreatedOn = lstListContacts[0].CreatedOn;
                        objListContacts.CreatedBy = lstListContacts[0].CreatedBy;

                    }
                    objBL_ListContacts.AccessUpdateContacts(objListContacts);
                    objListContacts = null;
                    objBL_ListContacts = null;
                    lstListContacts = null;
                    gvlist.EditIndex = -1;
                    BindAddContactsControl();

                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvlist_RowUpdating() - " + ex.Message);
            }
        }
        protected void gvlist_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvlist.EditIndex = e.NewEditIndex;
                BindAddContactsControl();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvlist_RowEditing() - " + ex.Message);
            }
        }
        protected void gvlist_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvlist.EditIndex = -1;
                BindAddContactsControl();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvlist_RowCancelingEdit() - " + ex.Message);
            }
        }
        protected void gvlist_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Label lblEmpID = (Label)gvlist.Rows[e.RowIndex].FindControl("lblEmpID");
                objBL_ListContacts.AccessDeleteContacts(Convert.ToInt32(lblEmpID.Text));
                BindAddContactsControl();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvlist_RowDeleting() - " + ex.Message);
            }
        }
        protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvlist.PageIndex = e.NewPageIndex;
                BindAddContactsControl();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvlist_PageIndexChanging() - " + ex.Message);
            }
        }

    }
}