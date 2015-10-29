using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailCampaign
{
    public partial class UserPlanView : System.Web.UI.Page
    {
        Userplantype objUserplantype = new Userplantype();
        BL_PlanType objBL_PlanType = new BL_PlanType();
        List<Userplantype> lstUserplantype = new List<Userplantype>();

        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.BindGrid();

        }
        private void BindGrid()
        {
            try
            {
                lstUserplantype = new List<Userplantype>();
                objBL_PlanType = new BL_PlanType();
                objUserplantype = new Userplantype();
                lstUserplantype = objBL_PlanType.SelectAllUserplantypebasedonisactive();
                string PlanName = "";
                string Planprice = "";
                int NoSubscribers = 0;
                int AllowdMails = 0;
                lblUsrPlan.Text = string.Empty;

                if (lstUserplantype.Count > 1)
                {
                    lblUsrPlan.Text = "<section id='pricePlans'><ul id='plans'>";
                    for (int i = 0; i < lstUserplantype.Count; i++)
                    {
                        PlanName = lstUserplantype[i].PlanName;

                        if (lstUserplantype[i].Planrate != null)
                            Planprice = lstUserplantype[i].Planrate.ToString();

                        NoSubscribers = lstUserplantype[i].NOC;
                        AllowdMails = lstUserplantype[i].AllowedMails;

                        if (i == 0)
                            lblUsrPlan.Text += "<li class='plan'> <ul class='planContainer'> <li class='title'><h2><span id='RepDetails_lblSubject_0'>";
                        else
                            lblUsrPlan.Text += "<li class='plan'> <ul class='planContainer'> <li class='title'><h2><span id='RepDetails_lblSubject_0'>";

                        lblUsrPlan.Text += PlanName + "</h2></li><li class='price'><h1 class='bestPlanPrice'><span>$";
                        lblUsrPlan.Text += Planprice + " / month</span> <small>No FREE trial</small> </h1></li><li><ul class='options'><li>Number of Subscribers:<span id='RepDetails_lblnos_0'>";
                        lblUsrPlan.Text += NoSubscribers + "</span> </li><li>Allowed Mails:<span id='RepDetails_lblComment_0'>";
                        lblUsrPlan.Text += AllowdMails + "</span> </li><li>Is Single User";

                        if (lstUserplantype[i].IsSingleUser == true)
                            lblUsrPlan.Text += "<img id='img" + lstUserplantype[i].PK_PlanID.ToString() + "'  src='images/Tick_inside_a_circle_24(1).png' border='0' style='width:30px;height:30px;'/>";

                        lblUsrPlan.Text += "</li><li> Is Multiple User";

                        if (lstUserplantype[i].IsSingleUser == false)
                            lblUsrPlan.Text += "<img id='img" + lstUserplantype[i].PK_PlanID.ToString() + "'  src='images/Tick_inside_a_circle_24(1).png' border='0' style='width:30px;height:30px;'/>";

                        lblUsrPlan.Text += "</li><li>Masss Email </li></ul></li><li class='button'><input name='btnCo" + i.ToString() + "' type='button' value='TRY THIS PLAN' ";
                        
                        if (Convert.ToInt64(Session["Usertype"]) != 10)
                            lblUsrPlan.Text += "onclick=location.href='UserPlanSuccess.aspx?PlanID=" + lstUserplantype[i].PK_PlanID + "'>";

                        lblUsrPlan.Text += " </li></ul>";//<a href='#' class='btn btn-success' role='button' name='RepDetails$ctl01$email' id='RepDetails_email_0' type='submit'>TRY THIS PLAN</a>

                        PlanName = "";
                        Planprice = "";
                        NoSubscribers = 0;
                        AllowdMails = 0;
                    }
                    lblUsrPlan.Text += "</ul></section>";
                }

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanView.aspx:BindGrid() - " + ex.Message);
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (sender as Button);
                string commandArgument = button.CommandArgument;
                RepeaterItem item = button.NamingContainer as RepeaterItem;
                int index = item.ItemIndex;
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanView.aspx:BindGrid() - " + ex.Message);
            }
        }
    }
}