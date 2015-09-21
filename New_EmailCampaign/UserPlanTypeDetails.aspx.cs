using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BALayer;

namespace New_EmailCampaign
{
    public partial class UserPlanTypeDetails : System.Web.UI.Page
    {
        Userplantype objUserplantype = new Userplantype();
        BL_PlanType objBL_PlanType = new BL_PlanType();
        List<Userplantype> lstUserplantype = new List<Userplantype>();

        BL_Common objBL_Common = new BL_Common();
        string strConnString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        Image sortImage = new Image();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindCampaignListGrid();
                ViewState["CurrentAlphabet"] = "ALL";
                this.GenerateAlphabets();
                this.BindGrid();
                Session["massupdateid"] = null;
                Session.Remove("massupdateid");
            }
        }

        #region Binding all campaign creation list in the grid
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 20-5-2015
        /// Comments :: Populating all campaign creation list in the grid.
        /// </summary>
        public void BindCampaignListGrid()
        {
            try
            {
                objUserplantype = new Userplantype();
                lstUserplantype = objBL_PlanType.SelectAllUserplantype();

                gvcampaign.DataSource = lstUserplantype;
                gvcampaign.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:BindCampaignListGrid() - " + ex.Message);
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
                for (int i = 0; i < gvcampaign.Rows.Count; i++)
                {

                    if (gvcampaign.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)gvcampaign.Rows[i].Cells[0].FindControl("CheckBox1");
                        Label lblEmpID = (Label)gvcampaign.Rows[i].Cells[0].FindControl("lblThirdPartyId");
                        //chk.Checked = true;
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
                                //gvcampaign.Rows[i].Attributes.Add("style", "background-color:aqua");
                            }
                        }
                    }
                }

                if (selectid != "")
                {
                    objBL_Common.AccessDeletAlleCampaign("EC_PlanType", "PK_PlanID", selectid);
                    this.BindGrid();
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey21", "alert('Select at least one record !');", true);

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:btndelete_Click() - " + ex.Message);
            }
        }
        protected void ddPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // handle event
                //DropDownList ddpagesize = sender as DropDownList;
                //gvcampaign.PageSize = Convert.ToInt32(ddpagesize.SelectedItem.Text);
                //ViewState["PageSize"] = ddpagesize.SelectedItem.Text;
                //gvcampaign.DataBind();

                GridViewRow gvcampaignRow = gvcampaign.BottomPagerRow;
                //    DropDownList ddPageSize =
                //(DropDownList)gvcampaignRow.Cells[0].FindControl("ddPageSize");
                DropDownList ddpagesize = sender as DropDownList;
                //gvcampaign.PageIndex = Convert.ToInt32(ddpagesize.SelectedItem.Text);

                //Popultate the GridView Control
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];

                gvcampaign.DataSource = SortDataTable(myDataTable, true);
                //gvcampaign.PageCount = Convert.ToInt32(ddpagesize.SelectedItem.Text);

                gvcampaign.PageSize = Convert.ToInt32(ddpagesize.SelectedItem.Text);
                ViewState["PageSize"] = ddpagesize.SelectedItem.Text;

                gvcampaign.DataBind();



            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:ddPageSize_SelectedIndexChanged() - " + ex.Message);
            }

        }


        protected void gvcampaign_DataBound(object sender, EventArgs e)
        {
            try
            {
                ////Custom Paging
                GridViewRow gvcampaignRow = gvcampaign.BottomPagerRow;

                if (gvcampaignRow == null) return;

                DropDownList ddCurrentPage = (DropDownList)gvcampaign.BottomPagerRow.FindControl("ddpagesize");

                Label lblPageCount = (Label)gvcampaignRow.Cells[0].FindControl("lblPageCount");
                Label label1 = (Label)gvcampaignRow.Cells[0].FindControl("Label1");

                //if (ddCurrentPage != null)
                //{
                //    //Populate Pager
                //    for (int i = 0; i < gvcampaign.PageCount; i++)
                //    {
                //        int iPageNumber = i + 1;
                //        ListItem myListItem = new ListItem(iPageNumber.ToString());

                //        if (i == gvcampaign.PageIndex)
                //            myListItem.Selected = true;

                //        ddCurrentPage.Items.Add(myListItem);
                //    }
                //}
                //int totRecords = (gvcampaign.PageIndex * gvcampaign.PageSize) + gvcampaign.PageSize;
                // Populate the Page Count


                if (gvcampaign.Rows.Count > 0)
                {
                    DropDownList ddPagesize = gvcampaign.BottomPagerRow.FindControl("ddPageSize") as DropDownList;
                    if (ViewState["PageSize"] != null)
                    {

                        ddPagesize.Items.FindByText((ViewState["PageSize"].ToString())).Selected = true;
                    }
                    //    pager.Visible = true;
                    //    DropDownList ddPagesize = gvcampaign.BottomPagerRow.FindControl("ddPageSize") as DropDownList;

                    //    if (ViewState["PageSize"] != null)
                    //    {

                    //        ddPagesize.Items.FindByText((ViewState["PageSize"].ToString())).Selected = true;
                    //    }
                    if (lblPageCount != null)
                    {
                        lblPageCount.Text = "<b>Page - </b>" + (gvcampaign.PageIndex + 1) + " of " + gvcampaign.PageCount.ToString();

                        //label1.Text = gvcampaign.PageIndex.ToString();
                    }
                    //Label lblCount = gvcampaign.BottomPagerRow.FindControl("Label1") as Label;
                    //int totRecords = (gvcampaign.PageIndex * gvcampaign.PageSize) + gvcampaign.PageSize;
                    ////int totCustomerCount = Convert.ToInt16(ddPagesize.SelectedItem.Text);
                    //int totCustomerCount = Convert.ToInt16(xx);

                    //totRecords = totRecords > totCustomerCount ? totCustomerCount : totRecords;
                    //lblCount.Text = ((gvcampaign.PageIndex * gvcampaign.PageSize) + 1).ToString() + " to " + Convert.ToString(totRecords) + " of " + totCustomerCount.ToString();
                    ////    gvcampaign.BottomPagerRow.Visible = true;

                }
                //else
                //{
                //    pager.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:gvcampaign_DataBound() - " + ex.Message);
            }
        }

        private void BindGrid()
        {
            try
            {
                string qrycmd = string.Empty;
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    qrycmd = "SELECT * from EC_PlanType where (PlanName LIKE @Alphabet + '%' OR @Alphabet = 'ALL')";

                    using (SqlCommand cmd = new SqlCommand(qrycmd))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Alphabet", ViewState["CurrentAlphabet"]);
                            sda.SelectCommand = cmd;
                            using (DataSet dt = new DataSet())
                            {
                                //dt = null;


                                sda.Fill(dt);
                                //myDataSet.Tables.Add(dt);
                                SetViewState(dt);
                                gvcampaign.DataSource = GetViewState();
                                gvcampaign.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:BindGrid() - " + ex.Message);
            }
        }

        private DataSet GetViewState()
        {
            //Gets the ViewState
            return (DataSet)ViewState["myDataSet"];
        }
        private void SetViewState(DataSet myDataSet)
        {
            //Sets the ViewState
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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:GenerateAlphabets() - " + ex.Message);
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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:Alphabet_Click() - " + ex.Message);
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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:gvcampaign_PageIndexChanging() - " + ex.Message);
            }
        }

        protected void gvcampaign_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                GridViewSortExpression = e.SortExpression;

                //Gets the Pageindex of the GridView.
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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:gvcampaign_Sorting() - " + ex.Message);
            }
        }

        //Gets or Sets the GridView SortDirection Property
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
        //Gets or Sets the GridView SortExpression Property
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

        //Toggles between the Direction of the Sorting        
        private string GetSortDirection()
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    sortImage.ImageUrl = "~/images/view_sort_ascending.png";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    break;
            }
            return GridViewSortDirection;
        }

        //Sorts the ResultSet based on the SortExpression and the Selected Column.
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
                // Get the Current Page Selected
                int iCurrentIndex = gvcampaign.PageIndex;

                switch (e.CommandArgument.ToString().ToLower())
                {
                    case "first":
                        gvcampaign.PageIndex = 0;
                        break;
                    case "prev":
                        if (gvcampaign.PageIndex != 0)
                        {
                            gvcampaign.PageIndex = iCurrentIndex - 1;
                        }
                        break;
                    case "next":
                        gvcampaign.PageIndex = iCurrentIndex + 1;
                        break;
                    case "last":
                        gvcampaign.PageIndex = gvcampaign.PageCount;
                        break;
                }

                //Populate the GridView Control
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];

                gvcampaign.DataSource = SortDataTable(myDataTable, true);
                gvcampaign.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:Paginate() - " + ex.Message);
            }
        }

        //Images for |<, <<, >>, and >|
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
                collapseExample.Attributes["class"] = "collapse";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:Button2_Click() - " + ex.Message);
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
                string qrycmd = string.Empty;
                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    string filter = string.Empty;
                    qrycmd = "SELECT * from EC_PlanType where (PlanName LIKE @Alphabet + '%' OR @Alphabet = 'ALL') and PlanName like '%' + @txtCampName + '%'";

                    using (SqlCommand cmd = new SqlCommand(qrycmd))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@Alphabet", ViewState["CurrentAlphabet"]);
                            cmd.Parameters.AddWithValue("@txtCampName", txtCampName.Value.Trim());
                            sda.SelectCommand = cmd;
                            using (DataSet dt = new DataSet())
                            {
                                //dt = null;


                                sda.Fill(dt);
                                //myDataSet.Tables.Add(dt);
                                SetViewState(dt);
                                gvcampaign.DataSource = GetViewState();
                                gvcampaign.DataBind();
                            }
                        }
                    }
                }
                collapseExample.Attributes["class"] = "collapse in";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:Button1_Click() - " + ex.Message);
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
                        //chk.Checked = true;
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
                                //gvcampaign.Rows[i].Attributes.Add("style", "background-color:aqua");
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

                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>$( document ).ready(function() { $('#target').modal('show')});</script>", false);


            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanTypeDetails.aspx:Button3_Click() - " + ex.Message);
            }
        }
    }
}