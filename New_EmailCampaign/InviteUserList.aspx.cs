using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace New_EmailCampaign
{
    public partial class InviteUserList : System.Web.UI.Page
    {
        InviteUser objInviteUser = new InviteUser();
        BL_InviteUser objBL_InviteUser = new BL_InviteUser();
        List<InviteUser> lstInviteUser = new List<InviteUser>();

        Company objCompany = new Company();
        BL_CompanyDetails objBL_CompanyDetails = new BL_CompanyDetails();
        List<Company> lstCompany = new List<Company>();

        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    lstCompany = objBL_CompanyDetails.SelectCompanyListbasedonid(Convert.ToInt32(Session["CompanyID"].ToString()));

                    if (lstCompany.Count > 0)
                    {
                        if (lstCompany[0].Company_Name != null)
                            lblcompanyname.Text = lstCompany[0].Company_Name;
                    }

                    Bindrolegrid();
                }
            }
        }

        #region Bindrolegrid
        public void Bindrolegrid()
        {
            DataTable dtgetreport = new DataTable();
            dtgetreport = objBL_Common.Inviteuserlist(Convert.ToInt32(Session["CompanyID"].ToString()));

            if (dtgetreport.Rows.Count > 0)
            {
                gvcampaign.DataSource = dtgetreport;
                gvcampaign.DataBind();
            }
        }

        #endregion

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {

                //CheckBox chkAll = (CheckBox)gvcampaign.HeaderRow.Cells[0].FindControl("checkAll");
                //chkAll.Checked = true;
                string selectid = string.Empty;
                Boolean deletestatus = false;
                for (int i = 0; i < gvcampaign.Rows.Count; i++)
                {

                    if (gvcampaign.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)gvcampaign.Rows[i].Cells[0].FindControl("CheckBox1");
                        Label lblEmpID = (Label)gvcampaign.Rows[i].Cells[0].FindControl("lblEmpID");
                        //chk.Checked = true;
                        if (chk.Checked)
                        {
                            DataTable dtplantype = new DataTable();
                            
                            if (selectid == "")
                            {
                                if (!selectid.Contains(lblEmpID.Text.ToString()))
                                {
                                    selectid = lblEmpID.Text;
                                    dtplantype = objBL_Common.plantypedetails("PK_CampaignID", "EC_Campaign", "FK_UserID in (" + lblEmpID.Text + ")");

                                    if (dtplantype.Rows.Count > 0)
                                        deletestatus = true;
                                    else
                                    {
                                        objBL_Common = new BL_Common();
                                        string emailid = "'" + gvcampaign.Rows[i].Cells[5].Text + "'";
                                        objBL_Common.AccessDeletAlleCampaign("EC_InviteUser", "Emailid", emailid);
                                        objBL_Common = new BL_Common();
                                        objBL_Common.AccessDeletAlleCampaign("EC_UserLogin", "PK_UserID", lblEmpID.Text);
                                    }
                                }
                            }
                            else
                            {
                                if (!selectid.Contains(lblEmpID.Text.ToString()))
                                {
                                    selectid = selectid + "," + lblEmpID.Text;
                                    dtplantype = objBL_Common.plantypedetails("PK_CampaignID", "EC_Campaign", "FK_UserID in (" + lblEmpID.Text + ")");

                                    if (dtplantype.Rows.Count > 0)
                                        deletestatus = true;                                        
                                    else
                                    {
                                        objBL_Common = new BL_Common();
                                        string emailid = "'" + gvcampaign.Rows[i].Cells[5].Text + "'";
                                        objBL_Common.AccessDeletAlleCampaign("EC_InviteUser", "Emailid", emailid);
                                        objBL_Common = new BL_Common();
                                        objBL_Common.AccessDeletAlleCampaign("EC_UserLogin", "PK_UserID", lblEmpID.Text);
                                    }
                                }
                                //gvcampaign.Rows[i].Attributes.Add("style", "background-color:aqua");
                            }
                        }
                    }
                }

                if (selectid == "")
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey28", "alert('Select at least one record !');", true);
                else
                {
                    if (deletestatus == true)
                        ClientScript.RegisterStartupScript(Page.GetType(), "mykey29", "alert('You cannot delete these user, Since it is referred by campaign!');", true);
                    this.Bindrolegrid();
                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("InviteUserList.aspx:btndelete_Click() - " + ex.Message);
            }
        }
        protected void gvcampaign_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            try
            {
                gvcampaign.PageIndex = e.NewPageIndex;
                this.Bindrolegrid();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("InviteUserList.aspx:gvcampaign_PageIndexChanging() - " + ex.Message);
            }
        }

        //protected void gvcampaign_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    string id;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        id = e.Row.Cells[0].Text;
        //        (e.Row.Cells[4].FindControl("imgEmployeeImage") as Image).ImageUrl = "photos/" + id + ".jpg";
        //    }
        //}

    }
}