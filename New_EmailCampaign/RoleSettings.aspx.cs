using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailCampaign
{
    public partial class RoleSettings : System.Web.UI.Page
    {
        Role objRole = new Role();
        BL_Role objBL_Role = new BL_Role();
        List<Role> lstRole = new List<Role>();

        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindRole();
        }

        #region Bind_ddlrole
        public void BindRole()
        {
            try
            {
                objRole = new Role();
                lstRole = new List<Role>();
                lstRole = objBL_Role.SelectRoleall(Convert.ToInt32(Session["CompanyID"].ToString()));

                if (lstRole.Count > 0)
                {

                    //ddlrole.DataBind();
                    foreach (var items in lstRole)
                    {
                        ddlrole.DataValueField = "PK_RoleID";
                        ddlrole.DataTextField = "RoleName";
                    }
                    ddlrole.DataSource = lstRole;
                    ddlrole.DataBind();
                }
                ddlrole.Items.Insert(0, "-- Select --");
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleSettings.aspx:BindRole() - " + ex.Message);
            }
        }
        #endregion

        protected void ddlrole_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Label1.Text = "";
                Label1.CssClass = "";
                if (Convert.ToInt32(ddlrole.SelectedValue) != 0)
                {
                    objRole = new Role();
                    lstRole = new List<Role>();
                    lstRole = objBL_Role.SelectRolealldropdownselection(Convert.ToInt32(ddlrole.SelectedValue), Convert.ToInt32(Session["CompanyID"].ToString()));
                    if (lstRole.Count > 0)
                    {

                        //ddlrole.DataBind();
                        foreach (var items in lstRole)
                        {
                            if (items.MailSend == true)
                                Chksendcmp.Checked = true;
                            else
                                Chksendcmp.Checked = false;

                            if (items.CreateUser == true)
                                Chkusr.Checked = true;
                            else
                                Chkusr.Checked = false;

                            if (items.CampaignDelete == true)
                                Chkcmpdelete.Checked = true;
                            else
                                Chkcmpdelete.Checked = false;

                            if (items.ViewingReports == true)
                                Chkvwreports.Checked = true;
                            else
                                Chkvwreports.Checked = false;

                            if (items.ListExports == true)
                                Chklstexports.Checked = true;
                            else
                                Chklstexports.Checked = false;

                            if (items.CampaignCreate == true)
                                Chkcmpcreate.Checked = true;
                            else
                                Chkcmpcreate.Checked = false;

                            //if (items.TemplateView == true)
                            //    Chkusr.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleSettings.aspx:BindRole() - " + ex.Message);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objRole = new Role();
                lstRole = new List<Role>();
                
                if(Chkcmpcreate.Checked == true)
                    objRole.CampaignCreate =  true;
                else
                    objRole.CampaignCreate =  false;

                if(Chksendcmp.Checked == true)
                    objRole.MailSend =  true;
                else
                    objRole.MailSend =  false;
                
                if(Chkusr.Checked == true)
                    objRole.CreateUser = true;
                else
                    objRole.CreateUser = false;

                if(Chkcmpdelete.Checked == true)
                    objRole.CampaignDelete = true;
                else
                    objRole.CampaignDelete = false;

                if(Chkvwreports.Checked == true)
                    objRole.ViewingReports = true;
                else
                    objRole.ViewingReports = false;

                //objRole.TemplateView
                if (Chklstexports.Checked == true)
                    objRole.ListExports = true;
                else
                    objRole.ListExports = false;

                objBL_Common.AccessUpdateAllCampaign("EC_Role", "CampaignCreate= '" + objRole.CampaignCreate + "', MailSend = '" + objRole.MailSend + "', CreateUser = '" + objRole.CreateUser + "', CampaignDelete = '" + objRole.CampaignDelete + "', ViewingReports = '" + objRole.ViewingReports + "',ListExports = '" + objRole.ListExports + "' ", "PK_RoleID =" + Convert.ToInt32(ddlrole.SelectedValue) + "");
                Label1.Text = "Information Successfully Saved.";
                Label1.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleSettings.aspx:btnSubmit_Click() - " + ex.Message);
                Label1.Text = "Failed while saving the information.";
                Label1.CssClass = "alert alert-danger";
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                ddlrole.SelectedValue = "-- Select --";
                Chkcmpcreate.Checked = false;
                Chksendcmp.Checked = false;
                Chkusr.Checked = false;
                Chkcmpdelete.Checked = false;
                Chkvwreports.Checked = false;
                Chklstexports.Checked = false;
                Chkselectall.Checked = false;
                Label1.Text = "";
                Label1.CssClass = "";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleSettings.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
    }
}