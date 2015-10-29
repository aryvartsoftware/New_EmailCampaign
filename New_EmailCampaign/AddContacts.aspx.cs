using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;


namespace New_EmailCampaign
{
    /// <summary>
    /// Created By :: Sakthivel.R
    /// Created On :: 27-4-2015
    /// Comments :: Add contacts for Email Campaign.
    /// </summary>
    public partial class AddContacts : System.Web.UI.Page
    {
        UserContacts objUserContacts = new UserContacts();
        BL_UserContacts objBL_UserContacts = new BL_UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();

        ListContacts objListContacts = new ListContacts();
        BL_ListContacts objBL_ListContacts = new BL_ListContacts();
        List<ListContacts> lstListContacts = new List<ListContacts>();

        string strConnString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        Image sortImage = new Image();
        static string selectid;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArrayList CheckBoxArray;

                if (ViewState["CheckBoxArray"] != null)
                    CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];                
                else
                 CheckBoxArray = new ArrayList();
          
                if (IsPostBack)
                {
                    int CheckBoxIndex;
                    bool CheckAllWasChecked = false;
                    CheckBox chkAll = (CheckBox)gvAddContacts.HeaderRow.Cells[0].FindControl("checkAll");
                    string checkAllIndex = "chkAll-" + gvAddContacts.PageIndex;

                    if (chkAll.Checked)
                    {
                        if (CheckBoxArray.IndexOf(checkAllIndex) == -1)
                        {
                            CheckBoxArray.Add(checkAllIndex);
                        }
                    }
                    else
                    {
                        if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                        {
                            CheckBoxArray.Remove(checkAllIndex);
                            CheckAllWasChecked = true;
                        }
                    }
                    
                    for (int i = 0; i < gvAddContacts.Rows.Count; i++)
                    {
                        if (gvAddContacts.Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chk = (CheckBox)gvAddContacts.Rows[i].Cells[0].FindControl("CheckBox1");
                            Label lblEmpID = (Label)gvAddContacts.Rows[i].Cells[0].FindControl("lblEmpID");
                            CheckBoxIndex = gvAddContacts.PageSize * gvAddContacts.PageIndex + (i + 1);

                            if (chk.Checked)
                            {
                                if (CheckBoxArray.IndexOf(CheckBoxIndex) == -1 && !CheckAllWasChecked)
                                {
                                    CheckBoxArray.Add(CheckBoxIndex);

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
                            else
                            {
                                if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1 || CheckAllWasChecked)
                                {
                                    CheckBoxArray.Remove(CheckBoxIndex);

                                    if(selectid.Contains("," + lblEmpID.Text.ToString()))
                                        selectid = selectid.Replace("," + lblEmpID.Text.ToString(), "");
                                    else if(selectid.Contains(lblEmpID.Text.ToString() + ","))
                                        selectid = selectid.Replace(lblEmpID.Text.ToString() + ",", " ");                                  
                                    else
                                        selectid = selectid.Replace(lblEmpID.Text.ToString(), "");
                                }
                            }
                        }
                    }
                }
                else if (!IsPostBack)
                {
                    selectid = string.Empty;
                    ViewState["CurrentAlphabet"] = "ALL";
                    this.GenerateAlphabets();
                    this.BindGrid();
                }
                ViewState["CheckBoxArray"] = CheckBoxArray;

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:BindSecurityData() - " + ex.Message);
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
                    gvAddContacts.DataSource = GetViewState();
                    gvAddContacts.DataBind();
                }
                else
                {
                    gvAddContacts.DataSource = GetViewState();
                    gvAddContacts.DataBind();
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    gvAddContacts.HeaderRow.Cells[2].Controls.Add(sortImage);
                    ViewState["SortDirection"] = "DESC";
                }                

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:BindGrid() - " + ex.Message);
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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:GenerateAlphabets() - " + ex.Message);
            }
        }
        protected void Alphabet_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkAlphabet = (LinkButton)sender;
                ViewState["CurrentAlphabet"] = lnkAlphabet.Text;
                this.GenerateAlphabets();
                gvAddContacts.PageIndex = 0;
                this.BindGrid();
                collapseExample.Attributes["class"] = "collapse";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:Alphabet_Click() - " + ex.Message);
            }
        }
        protected void gvAddContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                 DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                gvAddContacts.DataSource = SortDataTable(myDataTable, true);

                gvAddContacts.PageIndex = e.NewPageIndex;
                this.BindGrid();

                if (ViewState["CheckBoxArray"] != null)
                {
                    ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
                    string checkAllIndex = "chkAll-" + gvAddContacts.PageIndex;

                    if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                    {
                        CheckBox chkAll = (CheckBox)gvAddContacts.HeaderRow.Cells[0].FindControl("checkAll");
                        chkAll.Checked = true;
                    }
                    for (int i = 0; i < gvAddContacts.Rows.Count; i++)
                    {

                        if (gvAddContacts.Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                            {
                                CheckBox chk = (CheckBox)gvAddContacts.Rows[i].Cells[0].FindControl("CheckBox1");
                                Label lblEmpID = (Label)gvAddContacts.Rows[i].Cells[0].FindControl("lblEmpID");
                                chk.Checked = true;

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
                            else
                            {
                                int CheckBoxIndex = gvAddContacts.PageSize * (gvAddContacts.PageIndex) + (i + 1);
                                if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1)
                                {
                                    CheckBox chk = (CheckBox)gvAddContacts.Rows[i].Cells[0].FindControl("CheckBox1");
                                    Label lblEmpID = (Label)gvAddContacts.Rows[i].Cells[0].FindControl("lblEmpID");
                                    chk.Checked = true;

                                    if (selectid == "")
                                    {
                                        if (!selectid.Contains(lblEmpID.Text.ToString()))
                                           selectid = lblEmpID.Text;
                                    }
                                    else
                                        if (!selectid.Contains(lblEmpID.Text.ToString()))
                                            selectid = selectid + "," + lblEmpID.Text;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvAddContacts_PageIndexChanging() - " + ex.Message);
            }
        }

        protected void ddPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvAddContactsRow = gvAddContacts.BottomPagerRow;
                DropDownList ddpagesize = sender as DropDownList;
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                gvAddContacts.DataSource = SortDataTable(myDataTable, true);
                gvAddContacts.PageSize = Convert.ToInt32(ddpagesize.SelectedItem.Text);
                ViewState["PageSize"] = ddpagesize.SelectedItem.Text;
                gvAddContacts.DataBind();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:ddPageSize_SelectedIndexChanged() - " + ex.Message);
            }
        }

        protected void gvAddContacts_DataBound(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gvAddContactsRow = gvAddContacts.BottomPagerRow;

                if (gvAddContactsRow == null) return;

                DropDownList ddCurrentPage = (DropDownList)gvAddContacts.BottomPagerRow.FindControl("ddpagesize");
                Label lblPageCount = (Label)gvAddContactsRow.Cells[0].FindControl("lblPageCount");
                Label label1 = (Label)gvAddContactsRow.Cells[0].FindControl("Label1");
                
                if (gvAddContacts.Rows.Count > 0)
                {
                    DropDownList ddPagesize = gvAddContacts.BottomPagerRow.FindControl("ddPageSize") as DropDownList;

                    if (ViewState["PageSize"] != null)                    
                        ddPagesize.Items.FindByText((ViewState["PageSize"].ToString())).Selected = true;
                   

                    if (lblPageCount != null)
                        lblPageCount.Text = "<b>Page - </b>" + (gvAddContacts.PageIndex + 1) + " of " + gvAddContacts.PageCount.ToString();
                   
                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvAddContacts_DataBound() - " + ex.Message);
            }
        }

        protected void gvAddContacts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {              
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
                    e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvAddContacts_RowDataBound() - " + ex.Message);
            }
        }

        protected void btngridsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectid.ToString() != "")
                {
                    Session["SelectContactID"] = selectid.ToString();

                    for (int i = 0; i < gvAddContacts.Rows.Count; i++)
                    {
                        if (gvAddContacts.Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chk = (CheckBox)gvAddContacts.Rows[i].Cells[0].FindControl("CheckBox1");
                            if (chk.Checked)
                            {
                                chk.Checked = false;
                            }
                        }
                    }
                    CheckBox chkAll = (CheckBox)gvAddContacts.HeaderRow.Cells[0].FindControl("checkAll");

                    if (chkAll.Checked)
                        chkAll.Checked = false;

                    if (ViewState["CheckBoxArray"] != null)
                        ViewState["CheckBoxArray"] = null;

                    selectid = string.Empty;
                    lblcontact.Text = "Your selected recipients are successfully populated.";
                    lblcontact.CssClass = "alert alert-success";
                }
                else
                {
                    lblcontact.Text = "Choose recipients to send mail!";
                    lblcontact.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:btngridsubmit_Click() - " + ex.Message);
            }
        }

        protected void gvAddContacts_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];
                GridViewSortExpression = e.SortExpression;
                int iPageIndex = gvAddContacts.PageIndex;
                gvAddContacts.DataSource = SortDataTable(myDataTable, false);
                gvAddContacts.DataBind();
                gvAddContacts.PageIndex = iPageIndex;

                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvAddContacts.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvAddContacts.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }
                gvAddContacts.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:gvAddContacts_Sorting() - " + ex.Message);
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
                    sortImage.ImageUrl = "~/images/view_sort_ascending.png";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
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
             return new DataView();
           
        }

        protected void Paginate(object sender, CommandEventArgs e)
        {
            try
            {                
                int iCurrentIndex = gvAddContacts.PageIndex;

                switch (e.CommandArgument.ToString().ToLower())
                {
                    case "first":
                        gvAddContacts.PageIndex = 0;
                        break;
                    case "prev":
                        if (gvAddContacts.PageIndex != 0)
                        {
                            gvAddContacts.PageIndex = iCurrentIndex - 1;
                        }
                        break;
                    case "next":
                        gvAddContacts.PageIndex = iCurrentIndex + 1;
                        break;
                    case "last":
                        gvAddContacts.PageIndex = gvAddContacts.PageCount;
                        break;
                }
                
                DataSet myDataSet = GetViewState();
                DataTable myDataTable = myDataSet.Tables[0];

                gvAddContacts.DataSource = SortDataTable(myDataTable, true);
                gvAddContacts.DataBind();

                if (ViewState["CheckBoxArray"] != null)
                {
                    ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
                    string checkAllIndex = "chkAll-" + gvAddContacts.PageIndex;

                    if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                    {
                        CheckBox chkAll = (CheckBox)gvAddContacts.HeaderRow.Cells[0].FindControl("checkAll");
                        chkAll.Checked = true;
                    }
                    for (int i = 0; i < gvAddContacts.Rows.Count; i++)
                    {

                        if (gvAddContacts.Rows[i].RowType == DataControlRowType.DataRow)
                        {
                            if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                            {
                                CheckBox chk = (CheckBox)gvAddContacts.Rows[i].Cells[0].FindControl("CheckBox1");
                                Label lblEmpID = (Label)gvAddContacts.Rows[i].Cells[0].FindControl("lblEmpID");
                                chk.Checked = true;

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
                            else
                            {
                                int CheckBoxIndex = gvAddContacts.PageSize * (gvAddContacts.PageIndex) + (i + 1);
                                if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1)
                                {
                                    CheckBox chk = (CheckBox)gvAddContacts.Rows[i].Cells[0].FindControl("CheckBox1");
                                    Label lblEmpID = (Label)gvAddContacts.Rows[i].Cells[0].FindControl("lblEmpID");
                                    chk.Checked = true;

                                    if (selectid == "")
                                    {
                                        if (!selectid.Contains(lblEmpID.Text.ToString()))
                                            selectid = lblEmpID.Text;
                                    }
                                    else
                                        if (!selectid.Contains(lblEmpID.Text.ToString()))
                                            selectid = selectid + "," + lblEmpID.Text;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:Paginate() - " + ex.Message);
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

        protected void gvAddContacts_PreRender(object sender, EventArgs e)
        {
            GridViewRow pagerRow = gvAddContacts.BottomPagerRow;

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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:Button2_Click() - " + ex.Message);
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
                    gvAddContacts.DataSource = GetViewState();
                    gvAddContacts.DataBind();
                }
                else
                {
                    gvAddContacts.DataSource = GetViewState();
                    gvAddContacts.DataBind();
                    sortImage.ImageUrl = "~/images/view_sort_descending.png";
                    gvAddContacts.HeaderRow.Cells[6].Controls.Add(sortImage);
                    ViewState["SortDirection"] = "DESC";
                }
               
                collapseExample.Attributes["class"] = "collapse in";
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("AddContacts.aspx:Button1_Click() - " + ex.Message);
            }
        }
        protected void btnreload_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}