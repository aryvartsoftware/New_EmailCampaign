using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using System.Data;
using BALayer;

namespace New_EmailCampaign
{
    public partial class ContactsView : System.Web.UI.Page
    {
        UserContacts objUserContacts = new UserContacts();
        BL_UserContacts objBL_UserContacts = new BL_UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();

        ListContacts objListContacts = new ListContacts();
        BL_ListContacts objBL_ListContacts = new BL_ListContacts();
        List<ListContacts> lstListContacts = new List<ListContacts>();

        BL_Common objBL_Common = new BL_Common();
        
        Image sortImage = new Image();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["CurrentAlphabet"] = "ALL";
                this.GenerateAlphabets();
                this.BindGrid();
                Session["massupdatecontid"] = null;
                Session.Remove("massupdatecontid");
            }
        }      

        protected void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string selectid = string.Empty;
                for (int i = 0; i < gvCampaign.Rows.Count; i++)
                {

                    if (gvCampaign.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)gvCampaign.Rows[i].Cells[0].FindControl("CheckBox1");
                        Label lblEmpID = (Label)gvCampaign.Rows[i].Cells[0].FindControl("lblEmpID");
                        
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
                    objBL_Common.AccessDeletAlleCampaign("EC_UserContacts", "PK_ContactID", selectid);
                    this.BindGrid();
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey21", "alert('Select at least one record !');", true);

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:btndelete_Click() - " + ex.Message);
            }
        }
        protected void ddPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvCampaignRow = gvCampaign.BottomPagerRow;               
                DropDownList ddpagesize = sender as DropDownList;
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                gvCampaign.DataSource = SortDataTable(myDataTable, true);
                gvCampaign.PageSize = Convert.ToInt32(ddpagesize.SelectedItem.Text);
                ViewState["PageSize"] = ddpagesize.SelectedItem.Text;
                gvCampaign.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:ddPageSize_SelectedIndexChanged() - " + ex.Message);
            }
        }

        protected void gvCampaign_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvCampaignRow = gvCampaign.BottomPagerRow;

                if (gvCampaignRow == null) return;

                DropDownList ddCurrentPage = (DropDownList)gvCampaign.BottomPagerRow.FindControl("ddpagesize");
                Label lblPageCount = (Label)gvCampaignRow.Cells[0].FindControl("lblPageCount");
                Label label1 = (Label)gvCampaignRow.Cells[0].FindControl("Label1");                

                if (gvCampaign.Rows.Count > 0)
                {
                    DropDownList ddPagesize = gvCampaign.BottomPagerRow.FindControl("ddPageSize") as DropDownList;
                    
                    if (ViewState["PageSize"] != null)                       
                        ddPagesize.Items.FindByText((ViewState["PageSize"].ToString())).Selected = true;                   

                    if (lblPageCount != null)
                        lblPageCount.Text = "<b>Page - </b>" + (gvCampaign.PageIndex + 1) + " of " + gvCampaign.PageCount.ToString();
                    
                }
               
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:gvCampaign_DataBound() - " + ex.Message);
            }
        }

        private void BindGrid()
        {
            try
            {
                DataSet dt = new DataSet();
                dt = objBL_UserContacts.SelectUserContactsListforid(Convert.ToInt32(Session["CompanyID"].ToString()), ViewState["CurrentAlphabet"].ToString());
                SetViewState(dt);

                if (dt.Tables[0].Rows.Count <= 0)
                {
                    gvCampaign.DataSource = GetViewState();
                    gvCampaign.DataBind();
                }
                else
                {
                    gvCampaign.DataSource = GetViewState();
                    gvCampaign.DataBind();
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    gvCampaign.HeaderRow.Cells[3].Controls.Add(sortImage);
                    ViewState["SortDirection"] = "DESC";
                }                
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:BindGrid() - " + ex.Message);
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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:GenerateAlphabets() - " + ex.Message);
            }
        }
        protected void Alphabet_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkAlphabet = (LinkButton)sender;
                ViewState["CurrentAlphabet"] = lnkAlphabet.Text;
                this.GenerateAlphabets();
                gvCampaign.PageIndex = 0;
                this.BindGrid();
                collapseExample.Attributes["class"] = "collapse";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:Alphabet_Click() - " + ex.Message);
            }
        }

        protected void gvCampaign_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                gvCampaign.DataSource = SortDataTable(myDataTable, true);
                gvCampaign.PageIndex = e.NewPageIndex;
                this.BindGrid();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:gvCampaign_PageIndexChanging() - " + ex.Message);
            }
        }

        protected void gvCampaign_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                GridViewSortExpression = e.SortExpression;
                int iPageIndex = gvCampaign.PageIndex;
                gvCampaign.DataSource = SortDataTable(myDataTable, false);
                gvCampaign.DataBind();
                gvCampaign.PageIndex = iPageIndex;
                int columnIndex = 0;

                foreach (DataControlFieldHeaderCell headerCell in gvCampaign.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvCampaign.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }
                gvCampaign.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:gvCampaign_Sorting() - " + ex.Message);
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
                        myDataView.Sort = string.Format("{0} {1}",
                        GridViewSortExpression, GridViewSortDirection);
                    
                    else                  
                        myDataView.Sort = string.Format("{0} {1}",
                        GridViewSortExpression, GetSortDirection());
                   
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
                int iCurrentIndex = gvCampaign.PageIndex;

                switch (e.CommandArgument.ToString().ToLower())
                {
                    case "first":
                        gvCampaign.PageIndex = 0;
                        break;
                    case "prev":
                        if (gvCampaign.PageIndex != 0)
                            gvCampaign.PageIndex = iCurrentIndex - 1;
                        
                        break;
                    case "next":
                        gvCampaign.PageIndex = iCurrentIndex + 1;
                        break;
                    case "last":
                        gvCampaign.PageIndex = gvCampaign.PageCount;
                        break;
                }

                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];

                gvCampaign.DataSource = SortDataTable(myDataTable, true);
                gvCampaign.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:Paginate() - " + ex.Message);
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

        protected void gvCampaign_PreRender(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvCampaign.BottomPagerRow;

            if (pagerRow != null && pagerRow.Visible == false)
                pagerRow.Visible = true;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.BindGrid();
                txtCampName.Value = "";
                txtStatus.Value = "";
                txtTitle.Value = "";
                collapseExample.Attributes["class"] = "collapse";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:Button2_Click() - " + ex.Message);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dt = new DataSet();
                dt = objBL_UserContacts.SelectUserContactsListforidforFilter(txtCampName.Value.Trim(), txtTitle.Value.Trim(), txtcity.Value.Trim(), txtState.Value.Trim(), txtCountry.Value.Trim(), txtemail.Value.Trim(), txtStatus.Value.Trim(), Convert.ToInt32(Session["CompanyID"].ToString()), ViewState["CurrentAlphabet"].ToString());
                SetViewState(dt);

                if (dt.Tables[0].Rows.Count <= 0)
                {
                    gvCampaign.DataSource = GetViewState();
                    gvCampaign.DataBind();
                }
                else
                {
                    gvCampaign.DataSource = GetViewState();
                    gvCampaign.DataBind();
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    gvCampaign.HeaderRow.Cells[6].Controls.Add(sortImage);
                    ViewState["SortDirection"] = "DESC";
                }
                collapseExample.Attributes["class"] = "collapse in";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:Button1_Click() - " + ex.Message);
            }
        }
        protected void btnreload_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string selectid = string.Empty;
                for (int i = 0; i < gvCampaign.Rows.Count; i++)
                {

                    if (gvCampaign.Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chk = (CheckBox)gvCampaign.Rows[i].Cells[0].FindControl("CheckBox1");
                        Label lblEmpID = (Label)gvCampaign.Rows[i].Cells[0].FindControl("lblEmpID");
                        
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
                    Session["massupdatecontid"] = selectid;
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey24", "ShowNewPage('MassUpdateContact.aspx');", true);
                }
                else
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey25", "alert('Select at least one record !');", true);                          
                
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:Button3_Click() - " + ex.Message);
            }
        }

        protected void btnnewcontact_Click(object sender, EventArgs e)
        {
            try
            {
                string[] UPtype = new string[3];

                if (Session["lstUserPlanType"] != null)
                {
                    UPtype = (string[])Session["lstUserPlanType"];

                    if (Convert.ToInt32(ViewState["ContactCount"]) < Convert.ToInt32(UPtype[1]))
                        Response.Redirect("ContactsAdd.aspx");
                    else
                        ClientScript.RegisterStartupScript(Page.GetType(), "mykey31", "alert('You cannot add more recipients beyond your plan !');", true);
                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ContactsView.aspx:Button3_Click() - " + ex.Message);
            }
        }
    }
}