using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DL_PlanType
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        Userplantype objUserplantype = new Userplantype();
        List<Userplantype> lstUserplantype = new List<Userplantype>();

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 29-6-2015
        /// Comments :: Insertion function of Userplantype details.
        /// </summary>
        #region Insert_UserplantypeCreation
        public void UserplantypeInsert(Userplantype objUserplantype)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            var Insert = (from cde in objEmailCampDataContext.spPlanType_AllActions(objUserplantype.PK_PlanID, objUserplantype.PlanName, objUserplantype.IsSingleUser, objUserplantype.Planrate, objUserplantype.NOC, objUserplantype.AllowedMails, objUserplantype.IsActive, objUserplantype.CreatedBy, objUserplantype.CreatedOn, objUserplantype.UpdatedBy, objUserplantype.UpdatedOn, objUserplantype.Plandate, "i")
                          select cde).ToList();

            Insert = null;

            objEmailCampDataContext = null;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 29-6-2015
        /// Comments :: Updation function of Userplantype details.
        /// </summary>
        #region Update_UserplantypeCreation
        public void UserplantypeUpdate(Userplantype objUserplantype)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spPlanType_AllActions(objUserplantype.PK_PlanID, objUserplantype.PlanName, objUserplantype.IsSingleUser, objUserplantype.Planrate, objUserplantype.NOC, objUserplantype.AllowedMails, objUserplantype.IsActive, objUserplantype.CreatedBy, objUserplantype.CreatedOn, objUserplantype.UpdatedBy, objUserplantype.UpdatedOn, objUserplantype.Plandate, "u")
                              select cde).ToList();

                Update = null;
                objUserplantype = null;
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
        /// Created On :: 29-6-2015
        /// Comments :: Updation function of Userplantype details.
        /// </summary>
        #region Delete_UserplantypeCreation
        public void UserplantypeDelete(int Userplantypeid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spPlanType_AllActions(Userplantypeid, null, null, null, null, null, null, null, null, null, null, null, "d")
                              select cde).ToList();

                Delete = null;
                objUserplantype = null;
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
        /// Created On :: 29-6-2015
        /// Comments :: Select all records for Userplantype details.
        /// </summary>
        #region Select_Records_CreateUserplantype
        public List<Userplantype> UserplantypeSelect(int PK_UserplantypeID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserplantype = new List<Userplantype>();

            var Select = (from cde in objEmailCampDataContext.spPlanType_AllActions(PK_UserplantypeID, null, null, null, null, null, null, null, null, null, null, null, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserplantype = new List<Userplantype>();
                foreach (var item in Select)
                {
                    objUserplantype = new Userplantype();
                    objUserplantype.PK_PlanID = item.PK_PlanID;
                    objUserplantype.PlanName = item.PlanName;
                    objUserplantype.IsSingleUser = item.IsSingleUser;
                    objUserplantype.Planrate = item.Planrate;
                    
                    if(item.NOC != null)
                        objUserplantype.NOC = Convert.ToInt32(item.NOC);

                    objUserplantype.AllowedMails = Convert.ToInt32(item.AllowedMails);
                    objUserplantype.IsActive = item.IsActive;
                    objUserplantype.Plandate = item.plandate;
                    objUserplantype.CreatedOn = item.CreatedOn;
                    objUserplantype.CreatedBy = item.CreatedBy;
                    objUserplantype.UpdatedBy = item.UpdatedBy;
                    objUserplantype.UpdatedOn = item.UpdatedOn;
                    lstUserplantype.Add(objUserplantype);
                }
            }
            objEmailCampDataContext = null;
            objUserplantype = null;
            return lstUserplantype;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 29-6-2015
        /// Comments :: Select all records for Userplantype details Basedonexpired.
        /// </summary>
        //#region Select_Records_CreateUserplantype_Basedondropdownselection
        public List<Userplantype> UserplantypeSelectall()
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserplantype = new List<Userplantype>();

            var Select = (from cde in objEmailCampDataContext.spPlanType_AllActions(null, null, null, null, null, null, true, null, null, null, null, null, "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                 lstUserplantype = new List<Userplantype>();
                 foreach (var item in Select)
                 {
                     objUserplantype = new Userplantype();
                     objUserplantype.PK_PlanID = item.PK_PlanID;
                     objUserplantype.PlanName = item.PlanName;
                     objUserplantype.IsSingleUser = item.IsSingleUser;
                     objUserplantype.Planrate = item.Planrate;

                     if (item.NOC != null)
                         objUserplantype.NOC = Convert.ToInt32(item.NOC);

                     objUserplantype.AllowedMails = Convert.ToInt32(item.AllowedMails);
                     objUserplantype.IsActive = item.IsActive;
                     objUserplantype.Plandate = item.plandate;
                     objUserplantype.CreatedOn = item.CreatedOn;
                     objUserplantype.CreatedBy = item.CreatedBy;
                     objUserplantype.UpdatedBy = item.UpdatedBy;
                     objUserplantype.UpdatedOn = item.UpdatedOn;
                     lstUserplantype.Add(objUserplantype);
                 }
            }
            objEmailCampDataContext = null;
            objUserplantype = null;
            return lstUserplantype;

        }
        public List<Userplantype> UserplantypeSelectallbasedonisactive()
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserplantype = new List<Userplantype>();

            var Select = (from cde in objEmailCampDataContext.spPlanType_AllActions(null, null, null, null, null, null, true, null, null, null, null, null, "b")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserplantype = new List<Userplantype>();
                foreach (var item in Select)
                {
                    objUserplantype = new Userplantype();
                    objUserplantype.PK_PlanID = item.PK_PlanID;
                    objUserplantype.PlanName = item.PlanName;
                    objUserplantype.IsSingleUser = item.IsSingleUser;
                    objUserplantype.Planrate = item.Planrate;

                    if (item.NOC != null)
                        objUserplantype.NOC = Convert.ToInt32(item.NOC);

                    objUserplantype.AllowedMails = Convert.ToInt32(item.AllowedMails);
                    objUserplantype.IsActive = item.IsActive;
                    objUserplantype.Plandate = item.plandate;
                    objUserplantype.CreatedOn = item.CreatedOn;
                    objUserplantype.CreatedBy = item.CreatedBy;
                    objUserplantype.UpdatedBy = item.UpdatedBy;
                    objUserplantype.UpdatedOn = item.UpdatedOn;
                    lstUserplantype.Add(objUserplantype);
                }
            }
            objEmailCampDataContext = null;
            objUserplantype = null;
            return lstUserplantype;

        }

        //#endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 29-6-2015
        /// Comments :: Select all records for Userplantype details.
        /// </summary>
        //#region Select_All_Records_CheckDateUserplantype
        //public List<Userplantype> CheckDateUserplantype(int cmpid)
        //{
        //    objEmailCampDataContext = new EmailCampDataContext();
        //    lstUserplantype = new List<Userplantype>();

        //    var Select = (from cde in objEmailCampDataContext.spUserplantype_AllActions(cmpid, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "c")
        //                  select cde).ToList();

        //    if (Select.Count > 0)
        //    {
        //        lstUserplantype = new List<Userplantype>();
        //        foreach (var item in Select)
        //        {
        //            objUserplantype = new Userplantype();
        //            objUserplantype.PK_Inviteid = item.PK_Inviteid;
        //            objUserplantype.Emailid = item.Emailid;

        //            if (item.FK_CompanyID != null)
        //                objUserplantype.FK_CompanyID = Convert.ToInt32(item.FK_CompanyID);
        //            objUserplantype.Invitedate = item.invitedate;
        //            objUserplantype.FK_RoleID = item.FK_RoleID;
        //            objUserplantype.Message = item.Message;
        //            objUserplantype.Mailsentstatus = item.mailsentstatus;
        //            objUserplantype.Expired = item.expired;
        //            objUserplantype.ApproveStatus = item.ApproveStatus;
        //            objUserplantype.CreatedOn = item.CreatedOn;
        //            objUserplantype.CreatedBy = item.CreatedBy;
        //            objUserplantype.UpdatedBy = item.UpdatedBy;
        //            objUserplantype.UpdatedOn = item.UpdatedOn;
        //            lstUserplantype.Add(objUserplantype);
        //        }
        //    }
        //    objEmailCampDataContext = null;
        //    objUserplantype = null;
        //    return lstUserplantype;

        //}

        //#endregion

    }
}
