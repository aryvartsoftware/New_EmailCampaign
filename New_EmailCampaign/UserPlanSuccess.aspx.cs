using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailCampaign
{
    public partial class UserPlanSuccess : System.Web.UI.Page
    {
        UserPlan objUserPlan = new UserPlan();
        BL_UserPlan objBL_UserPlan = new BL_UserPlan();
        List<UserPlan> lstUserPlan = new List<UserPlan>();

        Userplantype objUserplantype = new Userplantype();
        BL_PlanType objBL_PlanType = new BL_PlanType();
        List<Userplantype> lstUserPlanType = new List<Userplantype>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void InsertUserPlan()
        {
            objUserPlan = new UserPlan();
            objBL_UserPlan = new BL_UserPlan();
            objUserPlan.FK_UserID = Convert.ToInt32(Session["UserID"].ToString());
            objUserPlan.FK_PlanID = Convert.ToInt32(Request.QueryString["PlanID"].ToString());
            objUserPlan.ActiveFrom = DateTime.Now;
            objUserPlan.ActiveTo = DateTime.Now.AddMonths(1);
            objUserPlan.IsActive = true;
            objUserPlan.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
            objUserPlan.CreatedOn = DateTime.Now;
            objBL_UserPlan.AccessInsertUserPlan(objUserPlan);
            objUserPlan = null;
            objBL_UserPlan = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            InsertUserPlan();
            SessionSaving();
        }

        public void SessionSaving()
        {
            try
            {
                objUserplantype = new Userplantype();
                objBL_PlanType = new BL_PlanType();
                lstUserPlanType = new List<Userplantype>();

                int PlanID = Convert.ToInt32(Request.QueryString["PlanID"].ToString());
                lstUserPlanType = objBL_PlanType.SelectUserplantypeforcampid(PlanID);

                if (lstUserPlanType.Count > 0)
                {
                    string[] UPtype = new string[3];
                    UPtype[0] = Convert.ToString(lstUserPlanType[0].IsSingleUser);
                    UPtype[1] = Convert.ToString(lstUserPlanType[0].NOC);
                    UPtype[2] = Convert.ToString(lstUserPlanType[0].AllowedMails);
                    Session["lstUserPlanType"] = UPtype;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanSuccess.aspx:SessionSaving() - " + ex.Message);
            }
        }
    }
}