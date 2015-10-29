using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DL_Role
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        Role objRole = new Role();
        List<Role> lstRole = new List<Role>();
        int? val = 0;
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 23-3-2015
        /// Comments :: Insertion function of Role details.
        /// </summary>
        #region Insert_RoleCreation
        public string RoleInsert(Role objRole)
        {           
                objEmailCampDataContext = new EmailCampDataContext();
                int? totrow = 0;
                var Insert = (from cde in objEmailCampDataContext.spRole_AllActions(objRole.PK_RoleID, objRole.FK_CompanyID, objRole.RoleName, objRole.CampaignCreate, objRole.MailSend, objRole.CreateUser, objRole.CampaignDelete, objRole.ViewingReports, objRole.TemplateView, objRole.CreatedBy, objRole.CreatedOn, objRole.UpdatedBy, objRole.UpdatedOn, objRole.ListExports, ref totrow, "i")
                              select cde).ToList();

                Insert = null;
                objRole = null;
                objEmailCampDataContext = null;
                return totrow.ToString();
          
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-4-2015
        /// Comments :: Updation function of Role details.
        /// </summary>
        #region Update_RoleCreation
        public void RoleUpdate(Role objRole)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spRole_AllActions(objRole.PK_RoleID, objRole.FK_CompanyID, objRole.RoleName, objRole.CampaignCreate, objRole.MailSend, objRole.CreateUser, objRole.CampaignDelete, objRole.ViewingReports, objRole.TemplateView, objRole.CreatedBy, objRole.CreatedOn, objRole.UpdatedBy, objRole.UpdatedOn, objRole.ListExports, ref val, "u")
                              select cde).ToList();

                Update = null;
                objRole = null;
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
        /// Comments :: Updation function of Role details.
        /// </summary>
        #region Delete_RoleCreation
        public void RoleDelete(int Roleid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spRole_AllActions(Roleid, null, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "d")
                              select cde).ToList();

                Delete = null;
                objRole = null;
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
        /// Comments :: Select all records for Role details.
        /// </summary>
        #region Select_Records_CreateRole
        public List<Role> RoleSelect(int PK_RoleID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstRole = new List<Role>();

            var Select = (from cde in objEmailCampDataContext.spRole_AllActions(PK_RoleID, null, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstRole = new List<Role>();
                foreach (var item in Select)
                {
                    objRole = new Role();
                    objRole.PK_RoleID = item.PK_RoleID;
                    
                    if (item.FK_CompanyID != null)
                        objRole.FK_CompanyID = Convert.ToInt32(item.FK_CompanyID);

                    objRole.RoleName = item.RoleName;
                    objRole.CampaignCreate = item.CampaignCreate;
                    objRole.MailSend = item.MailSend;
                    objRole.CreateUser = item.CreateUser;
                    objRole.CampaignDelete = item.CampaignDelete;
                    objRole.ViewingReports = item.ViewingReports;
                    objRole.TemplateView = item.TemplateView;
                    objRole.CreatedOn = item.CreatedOn;
                    objRole.CreatedBy = item.CreatedBy;
                    objRole.UpdatedBy = item.UpdatedBy;
                    objRole.UpdatedOn = item.UpdatedOn;
                    objRole.ListExports = item.ListExports;
                    lstRole.Add(objRole);
                }
            }
            objEmailCampDataContext = null;
            objRole = null;
            return lstRole;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-6-2015
        /// Comments :: Select all records for Role details Basedondropdownselection.
        /// </summary>
        #region Select_Records_CreateRole_Basedondropdownselection
        public List<Role> RoleSelectBasedondropdownselection(int PK_RoleID, int FK_CompanyID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstRole = new List<Role>();

            var Select = (from cde in objEmailCampDataContext.spRole_AllActions(PK_RoleID, FK_CompanyID, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "b")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstRole = new List<Role>();
                foreach (var item in Select)
                {
                    objRole = new Role();
                    objRole.PK_RoleID = item.PK_RoleID;

                    if (item.FK_CompanyID != null)
                        objRole.FK_CompanyID = Convert.ToInt32(item.FK_CompanyID);

                    objRole.RoleName = item.RoleName;
                    objRole.CampaignCreate = item.CampaignCreate;
                    objRole.MailSend = item.MailSend;
                    objRole.CreateUser = item.CreateUser;
                    objRole.CampaignDelete = item.CampaignDelete;
                    objRole.ViewingReports = item.ViewingReports;
                    objRole.TemplateView = item.TemplateView;
                    objRole.CreatedOn = item.CreatedOn;
                    objRole.CreatedBy = item.CreatedBy;
                    objRole.UpdatedBy = item.UpdatedBy;
                    objRole.UpdatedOn = item.UpdatedOn;
                    objRole.ListExports = item.ListExports;
                    lstRole.Add(objRole);
                }
            }
            objEmailCampDataContext = null;
            objRole = null;
            return lstRole;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-4-2015
        /// Comments :: Select all records for Role details.
        /// </summary>
        #region Select_All_Records_CreateRole
        public List<Role> RoleSelectall(int cmpid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstRole = new List<Role>();

            var Select = (from cde in objEmailCampDataContext.spRole_AllActions(null, cmpid, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstRole = new List<Role>();
                foreach (var item in Select)
                {
                    objRole = new Role();
                    objRole.PK_RoleID = item.PK_RoleID;

                    if (item.FK_CompanyID != null)
                        objRole.FK_CompanyID = Convert.ToInt32(item.FK_CompanyID);

                    objRole.RoleName = item.RoleName;
                    objRole.CampaignCreate = item.CampaignCreate;
                    objRole.MailSend = item.MailSend;
                    objRole.CreateUser = item.CreateUser;
                    objRole.CampaignDelete = item.CampaignDelete;
                    objRole.ViewingReports = item.ViewingReports;
                    objRole.TemplateView = item.TemplateView;
                    objRole.CreatedOn = item.CreatedOn;
                    objRole.CreatedBy = item.CreatedBy;
                    objRole.UpdatedBy = item.UpdatedBy;
                    objRole.UpdatedOn = item.UpdatedOn;
                    lstRole.Add(objRole);
                }
            }
            objEmailCampDataContext = null;
            objRole = null;
            return lstRole;

        }

        #endregion

        
    }
}
