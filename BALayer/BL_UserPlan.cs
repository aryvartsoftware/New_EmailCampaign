using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    public class BL_UserPlan
    {
        DL_UserPlan objDL_UserPlan = new DL_UserPlan();
        UserPlan objUserPlan1 = new UserPlan();
        List<UserPlan> lstUserPlan = new List<UserPlan>();

        public string AccessInsertUserPlan(UserPlan objUserPlan1)
        {
            string pkid = objDL_UserPlan.UserPlanInsert(objUserPlan1);
            return pkid;
        }

        public void AccessUpdateUserPlan(UserPlan objUserPlan1)
        {
            objDL_UserPlan.UserPlanUpdate(objUserPlan1);
        }

        public void AccessDeleteUserPlan(int UserPlanid)
        {
            objDL_UserPlan.UserPlanDelete(UserPlanid);
        }

        public List<UserPlan> GetUserPlanBasedonCompanyID(int UserPlanid1)
        {
            return objDL_UserPlan.GetUserPlan(UserPlanid1);
        }

        public List<UserPlan> SelectUserPlanforcampid(int campid)
        {
            return objDL_UserPlan.UserPlanSelect(campid);
        }

        public List<UserPlan> CheckDateUserPlan()
        {
            return objDL_UserPlan.UserPlanSelectAll();
        }
    }
}
