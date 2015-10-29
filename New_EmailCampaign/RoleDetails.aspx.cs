using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailCampaign
{
    public partial class RoleDetails : System.Web.UI.Page
    {
        Role objRole = new Role();
        BL_Role objBL_Role = new BL_Role();
        List<Role> lstRole = new List<Role>();
        BL_Common objBL_Common = new BL_Common();

        public static string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    if (Request.QueryString["roleId"] != null)
                        RetrieveRole();
                    Bindrolegrid();

                    if (msg != "")
                    {
                        Label1.Text = "Information Successfully Saved.";
                        Label1.CssClass = "alert alert-success";
                        msg = "";
                    }
                }
            }
        }

        #region Retrieve_Records_Based_on_Roleid
        public void RetrieveRole()
        {
            try
            {
                msg = "";
                objRole = new Role();
                objBL_Role = new BL_Role();
                lstRole = objBL_Role.SelectRoleforcampid(Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["roleId"]).ToString()));

                if (lstRole.Count > 0)
                    txtRoleName.Value = lstRole[0].RoleName;
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleDetails.aspx:RetrieveRole() - " + ex.Message);
            }
        }

        #endregion

        #region Bindrolegrid
        public void Bindrolegrid()
        {
            objRole = new Role();
            if (Convert.ToInt16(Session["Usertype"].ToString()) == 1)
            {
                lstRole = objBL_Role.SelectRoleall(Convert.ToInt32(Session["CompanyID"].ToString()));
                gvcampaign.DataSource = lstRole;
                gvcampaign.DataBind();
            }
        }

        #endregion

        #region clear_Click
        protected void clear_Click(object sender, EventArgs e)
        {
            Label1.CssClass = "";
            Label1.Text = "";
            Response.Redirect("RoleDetails.aspx");
        }
        #endregion

        #region Button1_Click
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRoleName.Value != string.Empty)
                {
                    objRole = new Role();
                    lstRole = new List<Role>();
                    objRole.RoleName = txtRoleName.Value.ToString().Trim();
                    objRole.FK_CompanyID = Convert.ToInt32(Session["CompanyID"].ToString());

                    if (Request.QueryString["roleId"] != null)
                    {
                        objRole.PK_RoleID = Convert.ToInt32(Request.QueryString["roleId"].ToString());
                        objRole.UpdatedBy = Convert.ToInt32(Session["UserID"].ToString());
                        objRole.UpdatedOn = DateTime.Now;
                        lstRole = objBL_Role.SelectRoleforcampid(Convert.ToInt32(Request.QueryString["roleId"].ToString()));

                        if (lstRole.Count > 0)
                        {
                            
                            objRole.FK_CompanyID = lstRole[0].FK_CompanyID;
                            objRole.CampaignCreate = lstRole[0].CampaignCreate;
                            objRole.MailSend = lstRole[0].MailSend;
                            objRole.CreateUser = lstRole[0].CreateUser;
                            objRole.CampaignDelete = lstRole[0].CampaignDelete;
                            objRole.ViewingReports = lstRole[0].ViewingReports;
                            objRole.TemplateView = lstRole[0].TemplateView;

                            if (lstRole[0].CreatedOn != null)
                                objRole.CreatedOn = lstRole[0].CreatedOn;
                            if (lstRole[0].CreatedBy != null)
                                objRole.CreatedBy = lstRole[0].CreatedBy;
                        }
                        objBL_Role.AccessUpdateRole(objRole);
                        txtRoleName.Value = string.Empty;
                    }
                    else
                    {
                        objRole.CreatedOn = DateTime.Now;
                        objRole.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                        objBL_Role.AccessInsertRole(objRole);
                        txtRoleName.Value = string.Empty;

                    }
                    Bindrolegrid();                   
                    msg = "1";
                    Response.Redirect("RoleDetails.aspx");
                }
                else
                {
                    msg = "";
                    Label1.Text = "The role name should not be empty!";
                    Label1.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleDetails.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
        #endregion


        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                msg = "";
                string selectid = string.Empty;

                for (int i = 0; i < gvcampaign.Rows.Count; i++)
                {

                    if (gvcampaign.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)gvcampaign.Rows[i].Cells[0].FindControl("CheckBox1");
                        Label lblEmpID = (Label)gvcampaign.Rows[i].Cells[0].FindControl("lblEmpID");

                        if (chk.Checked)
                        {
                            if (selectid == "")
                            {
                                if (!selectid.Contains(lblEmpID.Text.ToString()))
                                    selectid = lblEmpID.Text;
                            }
                            else
                            {
                                if (!selectid.Contains(lblEmpID.Text.ToString()))
                                    selectid = selectid + "," + lblEmpID.Text;
                            }
                        }
                    }
                }

                if (selectid != "")
                {
                    objBL_Common.AccessDeletAlleCampaign("EC_Role", "PK_RoleID", selectid);
                    this.Bindrolegrid();
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey21", "alert('Select at least one record !');", true);

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleDetails.aspx:btndelete_Click() - " + ex.Message);
            }
        }

        protected void gvcampaign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvcampaign.PageIndex = e.NewPageIndex;
                this.Bindrolegrid();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("RoleDetails.aspx:gvcampaign_PageIndexChanging() - " + ex.Message);
            }
        }
    }
}