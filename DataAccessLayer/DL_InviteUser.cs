using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DL_InviteUser
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        InviteUser objInviteUser = new InviteUser();
        List<InviteUser> lstInviteUser = new List<InviteUser>();
        int? val = 0;
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 25-6-2015
        /// Comments :: Insertion function of InviteUser details.
        /// </summary>
        #region Insert_InviteUserCreation
        public string InviteUserInsert(InviteUser objInviteUser)
        {
                objEmailCampDataContext = new EmailCampDataContext();
                int? totrow = 0;
                var Insert = (from cde in objEmailCampDataContext.spInviteUser_AllActions(objInviteUser.PK_Inviteid, objInviteUser.Emailid, objInviteUser.Invitedate, objInviteUser.FK_RoleID, objInviteUser.Message, objInviteUser.Mailsentstatus, objInviteUser.Expired, objInviteUser.ApproveStatus, objInviteUser.CreatedBy, objInviteUser.CreatedOn, objInviteUser.UpdatedBy, objInviteUser.UpdatedOn, objInviteUser.FK_CompanyID, ref totrow, "i")
                              select cde).ToList();

                Insert = null;
                
                objEmailCampDataContext = null;
                return totrow.ToString();
           
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-6-2015
        /// Comments :: Updation function of InviteUser details.
        /// </summary>
        #region Update_InviteUserCreation
        public void InviteUserUpdate(InviteUser objInviteUser)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spInviteUser_AllActions(objInviteUser.PK_Inviteid, objInviteUser.Emailid, objInviteUser.Invitedate, objInviteUser.FK_RoleID, objInviteUser.Message, objInviteUser.Mailsentstatus, objInviteUser.Expired, objInviteUser.ApproveStatus, objInviteUser.CreatedBy, objInviteUser.CreatedOn, objInviteUser.UpdatedBy, objInviteUser.UpdatedOn, objInviteUser.FK_CompanyID, ref val, "u")
                              select cde).ToList();

                Update = null;
                objInviteUser = null;
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
        /// Created On :: 28-4-2015
        /// Comments :: Updation function of InviteUser details.
        /// </summary>
        #region Delete_InviteUserCreation
        public void InviteUserDelete(int InviteUserid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spInviteUser_AllActions(InviteUserid, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "d")
                              select cde).ToList();

                Delete = null;
                objInviteUser = null;
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
        /// Created On :: 28-4-2015
        /// Comments :: Select all records for InviteUser details.
        /// </summary>
        #region Select_Records_CreateInviteUser
        public List<InviteUser> InviteUserSelect(int PK_InviteUserID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstInviteUser = new List<InviteUser>();

            var Select = (from cde in objEmailCampDataContext.spInviteUser_AllActions(PK_InviteUserID, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstInviteUser = new List<InviteUser>();
                foreach (var item in Select)
                {
                    objInviteUser = new InviteUser();
                    objInviteUser.PK_Inviteid = item.PK_Inviteid;
                    objInviteUser.Emailid = item.Emailid;
                    objInviteUser.Invitedate = item.invitedate;
                    objInviteUser.FK_RoleID = item.FK_RoleID;

                    if (item.FK_CompanyID != null)
                        objInviteUser.FK_CompanyID = Convert.ToInt32(item.FK_CompanyID);
                    objInviteUser.Message = item.Message;
                    objInviteUser.Mailsentstatus = item.mailsentstatus;
                    objInviteUser.Expired = item.expired;
                    objInviteUser.ApproveStatus = item.ApproveStatus;
                    objInviteUser.CreatedOn = item.CreatedOn;
                    objInviteUser.CreatedBy = item.CreatedBy;
                    objInviteUser.UpdatedBy = item.UpdatedBy;
                    objInviteUser.UpdatedOn = item.UpdatedOn;
                    lstInviteUser.Add(objInviteUser);
                }
            }
            objEmailCampDataContext = null;
            objInviteUser = null;
            return lstInviteUser;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-6-2015
        /// Comments :: Select all records for InviteUser details Basedonexpired.
        /// </summary>
        #region Select_Records_CreateInviteUser_Basedondropdownselection
        public List<InviteUser> checkexpired(int PK_InviteUserID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstInviteUser = new List<InviteUser>();

            var Select = (from cde in objEmailCampDataContext.spInviteUser_AllActions(PK_InviteUserID, null, null, null, null, null, true, null, null, null, null, null, null, ref val, "b")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstInviteUser = new List<InviteUser>();
                foreach (var item in Select)
                {
                    objInviteUser = new InviteUser();
                    objInviteUser.PK_Inviteid = item.PK_Inviteid;
                    objInviteUser.Emailid = item.Emailid;
                    objInviteUser.Invitedate = item.invitedate;

                    if (item.FK_CompanyID != null)
                        objInviteUser.FK_CompanyID = Convert.ToInt32(item.FK_CompanyID);
                    objInviteUser.FK_RoleID = item.FK_RoleID;
                    objInviteUser.Message = item.Message;
                    objInviteUser.Mailsentstatus = item.mailsentstatus;
                    objInviteUser.Expired = item.expired;
                    objInviteUser.ApproveStatus = item.ApproveStatus;
                    objInviteUser.CreatedOn = item.CreatedOn;
                    objInviteUser.CreatedBy = item.CreatedBy;
                    objInviteUser.UpdatedBy = item.UpdatedBy;
                    objInviteUser.UpdatedOn = item.UpdatedOn;
                    lstInviteUser.Add(objInviteUser);
                }
            }
            objEmailCampDataContext = null;
            objInviteUser = null;
            return lstInviteUser;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-6-2015
        /// Comments :: Select all records for InviteUser details.
        /// </summary>
        #region Select_All_Records_CheckDateInviteuser
        public List<InviteUser> CheckDateInviteuser(int cmpid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstInviteUser = new List<InviteUser>();

            var Select = (from cde in objEmailCampDataContext.spInviteUser_AllActions(cmpid, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "c")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstInviteUser = new List<InviteUser>();
                foreach (var item in Select)
                {
                    objInviteUser = new InviteUser();
                    objInviteUser.PK_Inviteid = item.PK_Inviteid;
                    objInviteUser.Emailid = item.Emailid;
                    
                    if(item.FK_CompanyID != null)
                        objInviteUser.FK_CompanyID = Convert.ToInt32(item.FK_CompanyID);
                    objInviteUser.Invitedate = item.invitedate;
                    objInviteUser.FK_RoleID = item.FK_RoleID;
                    objInviteUser.Message = item.Message;
                    objInviteUser.Mailsentstatus = item.mailsentstatus;
                    objInviteUser.Expired = item.expired;
                    objInviteUser.ApproveStatus = item.ApproveStatus;
                    objInviteUser.CreatedOn = item.CreatedOn;
                    objInviteUser.CreatedBy = item.CreatedBy;
                    objInviteUser.UpdatedBy = item.UpdatedBy;
                    objInviteUser.UpdatedOn = item.UpdatedOn;
                    lstInviteUser.Add(objInviteUser);
                }
            }
            objEmailCampDataContext = null;
            objInviteUser = null;
            return lstInviteUser;

        }

        #endregion


    }
}
