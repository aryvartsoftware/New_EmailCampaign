using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DL_UserPlan
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        UserPlan objUserPlan = new UserPlan();
        List<UserPlan> lstUserPlan = new List<UserPlan>();
        int? val = 0;
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 15-9-2015
        /// Comments :: Insertion function of UserPlan details.
        /// </summary>
        #region Insert_UserPlanCreation
        public string UserPlanInsert(UserPlan objUserPlan)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            int? totrow = 0;
            var Insert = (from cde in objEmailCampDataContext.spUserPlan_AllActions(objUserPlan.PK_UserPlanID, objUserPlan.FK_UserID, objUserPlan.FK_PlanID, objUserPlan.ActiveFrom, objUserPlan.ActiveTo, objUserPlan.IsActive, objUserPlan.CreatedBy, objUserPlan.CreatedOn, objUserPlan.UpdatedBy, objUserPlan.UpdatedOn, "i")
                          select cde).ToList();

            Insert = null;

            objEmailCampDataContext = null;
            return totrow.ToString();

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 15-9-2015
        /// Comments :: Updation function of UserPlan details.
        /// </summary>
        #region Update_UserPlanCreation
        public void UserPlanUpdate(UserPlan objUserPlan)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spUserPlan_AllActions(objUserPlan.PK_UserPlanID, objUserPlan.FK_UserID, objUserPlan.FK_PlanID, objUserPlan.ActiveFrom, objUserPlan.ActiveTo, objUserPlan.IsActive, objUserPlan.CreatedBy, objUserPlan.CreatedOn, objUserPlan.UpdatedBy, objUserPlan.UpdatedOn, "u")
                              select cde).ToList();

                Update = null;
                objUserPlan = null;
                objEmailCampDataContext = null;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 15-9-2015
        /// Comments :: Updation function of UserPlan details.
        /// </summary>
        #region Delete_UserPlanCreation
        public void UserPlanDelete(int UserPlanid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spUserPlan_AllActions(UserPlanid, null, null, null, null, null, null, null, null, null,"d")
                              select cde).ToList();

                Delete = null;
                objUserPlan = null;
                objEmailCampDataContext = null;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion


        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 15-9-2015
        /// Comments :: Select all records for UserPlan details.
        /// </summary>
        #region Select_Records_CreateUserPlan
        public List<UserPlan> UserPlanSelect(int PK_UserPlanID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserPlan = new List<UserPlan>();

            var Select = (from cde in objEmailCampDataContext.spUserPlan_AllActions(PK_UserPlanID, null, null, null, null, true, null, null, null, null, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserPlan = new List<UserPlan>();
                foreach (var item in Select)
                {
                    objUserPlan = new UserPlan();
                    objUserPlan.ActiveFrom = item.ActiveFrom;
                    objUserPlan.ActiveTo = item.ActiveTo;

                    if (item.FK_PlanID != null)
                        objUserPlan.FK_PlanID = Convert.ToInt32(item.FK_PlanID);

                    objUserPlan.FK_UserID = item.FK_UserID;
                    objUserPlan.IsActive = item.IsActive;
                    objUserPlan.PK_UserPlanID = item.PK_UserPlanID;
                    objUserPlan.CreatedOn = item.CreatedOn;
                    objUserPlan.CreatedBy = item.CreatedBy;
                    objUserPlan.UpdatedBy = item.UpdatedBy;
                    objUserPlan.UpdatedOn = item.UpdatedOn;
                    lstUserPlan.Add(objUserPlan);
                }
            }
            objEmailCampDataContext = null;
            objUserPlan = null;
            return lstUserPlan;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 15-9-2015
        /// Comments :: Select all records for UserPlan details.
        /// </summary>
        #region Get_UserPlan
        public List<UserPlan> GetUserPlan(int PK_UserPlanID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserPlan = new List<UserPlan>();

            var Select = (from cde in objEmailCampDataContext.spUserPlan_AllActions(null, null, PK_UserPlanID, null, null, true, null, null, null, null, "b")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserPlan = new List<UserPlan>();
                foreach (var item in Select)
                {
                    objUserPlan = new UserPlan();
                    objUserPlan.ActiveFrom = item.ActiveFrom;
                    objUserPlan.ActiveTo = item.ActiveTo;

                    if (item.FK_PlanID != null)
                        objUserPlan.FK_PlanID = Convert.ToInt32(item.FK_PlanID);

                    objUserPlan.FK_UserID = item.FK_UserID;
                    objUserPlan.IsActive = item.IsActive;
                    objUserPlan.PK_UserPlanID = item.PK_UserPlanID;
                    objUserPlan.CreatedOn = item.CreatedOn;
                    objUserPlan.CreatedBy = item.CreatedBy;
                    objUserPlan.UpdatedBy = item.UpdatedBy;
                    objUserPlan.UpdatedOn = item.UpdatedOn;
                    lstUserPlan.Add(objUserPlan);
                }
            }
            objEmailCampDataContext = null;
            objUserPlan = null;
            return lstUserPlan;

        }

        #endregion
        
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 15-9-2015
        /// Comments :: Select all records for UserPlan details.
        /// </summary>
        #region Select_All_Records_UserPlan
        public List<UserPlan> UserPlanSelectAll()
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserPlan = new List<UserPlan>();

            var Select = (from cde in objEmailCampDataContext.spUserPlan_AllActions(null, null, null, null, null, true, null, null, null, null, "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserPlan = new List<UserPlan>();
                foreach (var item in Select)
                {
                    objUserPlan = new UserPlan();
                    objUserPlan.ActiveFrom = item.ActiveFrom;
                    objUserPlan.ActiveTo = item.ActiveTo;

                    if (item.FK_PlanID != null)
                        objUserPlan.FK_PlanID = Convert.ToInt32(item.FK_PlanID);

                    objUserPlan.FK_UserID = item.FK_UserID;
                    objUserPlan.IsActive = item.IsActive;
                    objUserPlan.PK_UserPlanID = item.PK_UserPlanID;
                    objUserPlan.CreatedOn = item.CreatedOn;
                    objUserPlan.CreatedBy = item.CreatedBy;
                    objUserPlan.UpdatedBy = item.UpdatedBy;
                    objUserPlan.UpdatedOn = item.UpdatedOn;
                    lstUserPlan.Add(objUserPlan);
                }
            }
            objEmailCampDataContext = null;
            objUserPlan = null;
            return lstUserPlan;

        }

        #endregion

    }
}
