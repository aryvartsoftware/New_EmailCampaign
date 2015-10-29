using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer.App_Code;
using System.Data;
using System.Configuration;
using BALayer;
using System.Globalization;

namespace New_EmailCampaign
{
    public partial class CampaignReportList : System.Web.UI.Page
    {
        Campaign objCampaign = new Campaign();
        BL_CreateCampaign objBL_CreateCampaign = new BL_CreateCampaign();
        List<Campaign> lstCampaign = new List<Campaign>();

        BL_Common objBL_Common = new BL_Common();
        string strConnString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        Image sortImage = new Image();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["CurrentAlphabet"] = "ALL";
                this.GenerateAlphabets();
                this.BindGrid();
                Session["massupdateid"] = null;
                Session.Remove("massupdateid");
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string selectid = string.Empty;
                for (int i = 0; i < gvcampaign.Rows.Count; i++)
                {

                    if (gvcampaign.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)gvcampaign.Rows[i].Cells[0].FindControl("CheckBox1");
                        Label lblEmpID = (Label)gvcampaign.Rows[i].Cells[0].FindControl("lblThirdPartyId");
                        
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
                    objBL_Common.AccessDeletAlleCampaign("EC_Campaign", "PK_CampaignID", selectid);
                    this.BindGrid();
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey21", "alert('Select at least one record !');", true);

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:btndelete_Click() - " + ex.Message);
            }
        }
        protected void ddPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvcampaignRow = gvcampaign.BottomPagerRow;
                DropDownList ddpagesize = sender as DropDownList;
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                gvcampaign.DataSource = SortDataTable(myDataTable, true);
                gvcampaign.PageSize = Convert.ToInt32(ddpagesize.SelectedItem.Text);
                ViewState["PageSize"] = ddpagesize.SelectedItem.Text;
                gvcampaign.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:ddPageSize_SelectedIndexChanged() - " + ex.Message);
            }

        }


        protected void gvcampaign_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvcampaignRow = gvcampaign.BottomPagerRow;

                if (gvcampaignRow == null) return;

                DropDownList ddCurrentPage = (DropDownList)gvcampaign.BottomPagerRow.FindControl("ddpagesize");
                Label lblPageCount = (Label)gvcampaignRow.Cells[0].FindControl("lblPageCount");
                Label label1 = (Label)gvcampaignRow.Cells[0].FindControl("Label1");

                if (gvcampaign.Rows.Count > 0)
                {
                    DropDownList ddPagesize = gvcampaign.BottomPagerRow.FindControl("ddPageSize") as DropDownList;
                    
                    if (ViewState["PageSize"] != null)                   
                        ddPagesize.Items.FindByText((ViewState["PageSize"].ToString())).Selected = true;                    
                   
                    if (lblPageCount != null)
                        lblPageCount.Text = "<b>Page - </b>" + (gvcampaign.PageIndex + 1) + " of " + gvcampaign.PageCount.ToString();
                }
               
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:gvcampaign_DataBound() - " + ex.Message);
            }
        }
        private void BindGrid()
        {
            try
            {
                objBL_CreateCampaign = new BL_CreateCampaign();
                string uertype = string.Empty;
                int Userid = 0;

                if (Convert.ToInt16(Session["Usertype"].ToString()) == 1)
                {
                    uertype = "r";
                    Userid = Convert.ToInt32(Session["CompanyID"].ToString());
                }
                else
                {
                    uertype = "t";
                    Userid = Convert.ToInt32(Session["UserID"].ToString());
                }

                DataSet dt = new DataSet();
                dt = objBL_CreateCampaign.SelectCampaignreportListforgrid(uertype, Userid, ViewState["CurrentAlphabet"].ToString());
                SetViewState(dt);

                if (dt.Tables[0].Rows.Count <= 0)
                {
                    gvcampaign.DataSource = GetViewState();
                    gvcampaign.DataBind();
                }
                else
                {
                    gvcampaign.DataSource = GetViewState();
                    gvcampaign.DataBind();
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    gvcampaign.HeaderRow.Cells[5].Controls.Add(sortImage);
                    ViewState["SortDirection"] = "DESC";
                }
               
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:BindGrid() - " + ex.Message);
            }
        }
        private DataSet GetViewState()
        {
            return (DataSet)ViewState["myDataSet"];
        }
        private void SetViewState(DataSet myDataSet)
        {
            ViewState["myDataSet"] = myDataSet;
        }
        private void GenerateAlphabets()
        {
            try
            {
                List<ListItem> alphabets = new List<ListItem>();
                ListItem alphabet = new ListItem();
                alphabet.Value = "ALL";
                alphabet.Selected = alphabet.Value.Equals(ViewState["CurrentAlphabet"]);
                alphabets.Add(alphabet);
                for (int i = 65; i <= 90; i++)
                {
                    alphabet = new ListItem();
                    alphabet.Value = Char.ConvertFromUtf32(i);
                    alphabet.Selected = alphabet.Value.Equals(ViewState["CurrentAlphabet"]);
                    alphabets.Add(alphabet);
                }
                rptAlphabets.DataSource = alphabets;
                rptAlphabets.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:GenerateAlphabets() - " + ex.Message);
            }
        }
        protected void Alphabet_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkAlphabet = (LinkButton)sender;
                ViewState["CurrentAlphabet"] = lnkAlphabet.Text;
                this.GenerateAlphabets();
                gvcampaign.PageIndex = 0;
                this.BindGrid();
                collapseExample.Attributes["class"] = "collapse";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:Alphabet_Click() - " + ex.Message);
            }
        }

        protected void gvcampaign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                gvcampaign.DataSource = SortDataTable(myDataTable, true);

                gvcampaign.PageIndex = e.NewPageIndex;
                this.BindGrid();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:gvcampaign_PageIndexChanging() - " + ex.Message);
            }
        }

        protected void gvcampaign_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                GridViewSortExpression = e.SortExpression;
                int iPageIndex = gvcampaign.PageIndex;
                gvcampaign.DataSource = SortDataTable(myDataTable, false);
                gvcampaign.DataBind();
                gvcampaign.PageIndex = iPageIndex;

                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvcampaign.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvcampaign.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }
                gvcampaign.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:gvcampaign_Sorting() - " + ex.Message);
            }
        }
        private string GridViewSortDirection
        {
            get
            {
                return ViewState["SortDirection"] as string ?? "ASC";
            }
            set
            {
                ViewState["SortDirection"] = value;
            }
        }
        private string GridViewSortExpression
        {
            get
            {
                return ViewState["SortExpression"] as string ?? string.Empty;
            }
            set
            {
                ViewState["SortExpression"] = value;
            }
        }
        private string GetSortDirection()
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    sortImage.ImageUrl = "~/images/view_sort_ascending.png";
                    break;
            }
            return GridViewSortDirection;
        }
        protected DataView SortDataTable(DataTable myDataTable, bool isPageIndexChanging)
        {
            if (myDataTable != null)
            {
                DataView myDataView = new DataView(myDataTable);
                if (GridViewSortExpression != string.Empty)
                {
                    if (isPageIndexChanging)
                    {
                        myDataView.Sort = string.Format("{0} {1}",
                        GridViewSortExpression, GridViewSortDirection);
                    }
                    else
                    {
                        myDataView.Sort = string.Format("{0} {1}",
                        GridViewSortExpression, GetSortDirection());
                    }
                }
                return myDataView;
            }
            else
            {

                return new DataView();
            }
        }

        protected void Paginate(object sender, CommandEventArgs e)
        {
            try
            {
                int iCurrentIndex = gvcampaign.PageIndex;

                switch (e.CommandArgument.ToString().ToLower())
                {
                    case "first":
                        gvcampaign.PageIndex = 0;
                        break;
                    case "prev":
                        if (gvcampaign.PageIndex != 0)
                            gvcampaign.PageIndex = iCurrentIndex - 1;                       
                        break;
                    case "next":
                        gvcampaign.PageIndex = iCurrentIndex + 1;
                        break;
                    case "last":
                        gvcampaign.PageIndex = gvcampaign.PageCount;
                        break;
                }
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];

                gvcampaign.DataSource = SortDataTable(myDataTable, true);
                gvcampaign.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:Paginate() - " + ex.Message);
            }
        }

        protected void imgPageFirst_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }
        protected void imgPagePrevious_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }
        protected void imgPageNext_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }
        protected void imgPageLast_Command(object sender, CommandEventArgs e)
        {
            Paginate(sender, e);
        }

        protected void gvcampaign_PreRender(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvcampaign.BottomPagerRow;

            if (pagerRow != null && pagerRow.Visible == false)
                pagerRow.Visible = true;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.BindGrid();
                txtCampName.Value = "";
                txtTitle.Value = "";
                collapseExample.Attributes["class"] = "collapse";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:Button2_Click() - " + ex.Message);
            }
        }
        protected void btnreload_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                objBL_CreateCampaign = new BL_CreateCampaign();
                string uertype = string.Empty;
                int compid = 0;
                Nullable<DateTime> CreatedOn = null;
                string alphabet = ViewState["CurrentAlphabet"].ToString();

                if (Convert.ToInt16(Session["Usertype"].ToString()) == 1)
                {
                    uertype = "v";
                    compid = Convert.ToInt32(Session["CompanyID"].ToString());

                    if (dtScheduledatetime.Value != "")
                        CreatedOn = DateTime.ParseExact(dtScheduledatetime.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    uertype = "w";
                    compid = Convert.ToInt32(Session["UserID"].ToString());

                    if (dtScheduledatetime.Value != "")
                        CreatedOn = DateTime.ParseExact(dtScheduledatetime.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                DataSet dt = new DataSet();
                dt = objBL_CreateCampaign.SelectCampaignreportListforgridBasedonfilter(uertype, compid, txtCampName.Value.Trim(), txtTitle.Value.Trim(), CreatedOn, alphabet);
                SetViewState(dt);

                if (dt.Tables[0].Rows.Count <= 0)
                {
                    gvcampaign.DataSource = GetViewState();
                    gvcampaign.DataBind();
                }
                else
                {
                    gvcampaign.DataSource = GetViewState();
                    gvcampaign.DataBind();
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    gvcampaign.HeaderRow.Cells[5].Controls.Add(sortImage);
                    ViewState["SortDirection"] = "DESC";
                }
                collapseExample.Attributes["class"] = "collapse in";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:Button1_Click() - " + ex.Message);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string selectid = string.Empty;
                for (int i = 0; i < gvcampaign.Rows.Count; i++)
                {

                    if (gvcampaign.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)gvcampaign.Rows[i].Cells[0].FindControl("CheckBox1");
                        Label lblEmpID = (Label)gvcampaign.Rows[i].Cells[0].FindControl("lblThirdPartyId");
                        
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
                    Session["massupdateid"] = selectid;
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey21", "ShowNewPage('MassUpdate.aspx');", true);
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey22", "alert('Select at least one record !');", true);         
                
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CampaignReportList.aspx:Button3_Click() - " + ex.Message);
            }
        }
    }
}