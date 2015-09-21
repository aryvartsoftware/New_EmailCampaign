using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DL_ListContacts
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        ListContacts objListContacts = new ListContacts();
        List<ListContacts> lstListContacts = new List<ListContacts>();

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 23-3-2015
        /// Comments :: Insertion function of ListContacts details.
        /// </summary>
        #region Insert_ListContactsCreation
        public void ListContactsInsert(ListContacts objListContacts)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Insert = (from cde in objEmailCampDataContext.spListContacts_AllActions(objListContacts.PK_ContListID, objListContacts.ListName, objListContacts.Comments, objListContacts.CreatedBy, objListContacts.CreatedOn, objListContacts.UpdatedBy, objListContacts.UpdatedOn, objListContacts.FK_CompanyID, "i")
                              select cde).ToList();

                Insert = null;
                objListContacts = null;
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
        /// Comments :: Updation function of ListContacts details.
        /// </summary>
        #region Update_ListContactsCreation
        public void ListContactsUpdate(ListContacts objListContacts)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spListContacts_AllActions(objListContacts.PK_ContListID, objListContacts.ListName, objListContacts.Comments, objListContacts.CreatedBy, objListContacts.CreatedOn, objListContacts.UpdatedBy, objListContacts.UpdatedOn, objListContacts.FK_CompanyID, "u")
                              select cde).ToList();

                Update = null;
                objListContacts = null;
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
        /// Comments :: Updation function of ListContacts details.
        /// </summary>
        #region Delete_ListContactsCreation
        public void ListContactsDelete(int ListContactsid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spListContacts_AllActions(ListContactsid, null, null, null, null, null, null, null, "d")
                              select cde).ToList();

                Delete = null;
                objListContacts = null;
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
        /// Comments :: Select all records for ListContacts details.
        /// </summary>
        #region Select_All_Records_CreateListContacts
        public List<ListContacts> ListContactsSelectforgrid(int Companyid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstListContacts = new List<ListContacts>();

            var Select = (from cde in objEmailCampDataContext.spListContacts_AllActions(null, null, null, null, null, null, null, Companyid, "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstListContacts = new List<ListContacts>();
                foreach (var item in Select)
                {
                    objListContacts = new ListContacts();
                    objListContacts.PK_ContListID = item.PK_ContListID;
                    objListContacts.ListName = item.ListName;
                    objListContacts.Comments = item.comments;
                    objListContacts.CreatedOn = item.CreatedOn;
                    objListContacts.CreatedBy = item.CreatedBy;
                    objListContacts.UpdatedBy = item.UpdatedBy;
                    objListContacts.UpdatedOn = item.UpdatedOn;
                    objListContacts.FK_CompanyID = item.FK_CompanyID;
                    lstListContacts.Add(objListContacts);
                }
            }
            objEmailCampDataContext = null;
            objListContacts = null;
            return lstListContacts;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-4-2015
        /// Comments :: Select all records for ListContacts details.
        /// </summary>
        #region Select_All_Records_CreateListContacts
        public List<ListContacts> ListContactsSelect(int PK_ContListID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstListContacts = new List<ListContacts>();

            var Select = (from cde in objEmailCampDataContext.spListContacts_AllActions(PK_ContListID, null, null, null, null, null, null, null, "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstListContacts = new List<ListContacts>();
                foreach (var item in Select)
                {
                    objListContacts = new ListContacts();
                    objListContacts.ListName = item.ListName;
                    objListContacts.Comments = item.comments;
                    objListContacts.CreatedOn = item.CreatedOn;
                    objListContacts.CreatedBy = item.CreatedBy;
                    objListContacts.UpdatedBy = item.UpdatedBy;
                    objListContacts.UpdatedOn = item.UpdatedOn;
                    objListContacts.FK_CompanyID = item.FK_CompanyID;
                    lstListContacts.Add(objListContacts);
                }
            }
            objEmailCampDataContext = null;
            objListContacts = null;
            return lstListContacts;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-4-2015
        /// Comments :: Select all records for ListContacts grid.
        /// </summary>
        #region Select_All_Records_ListContactsgrid
        public List<ListContacts> ListContactsgrid()
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstListContacts = new List<ListContacts>();

            var Select = (from cde in objEmailCampDataContext.spListContacts_AllActions(null, null, null, null, null, null, null, null, "c")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstListContacts = new List<ListContacts>();
                foreach (var item in Select)
                {
                    objListContacts = new ListContacts();
                    objListContacts.ListName = item.ListName;
                    //objListContacts.TotalCount = item.;
                    objListContacts.CreatedOn = item.CreatedOn;
                    objListContacts.CreatedBy = item.CreatedBy;
                    objListContacts.UpdatedBy = item.UpdatedBy;
                    objListContacts.UpdatedOn = item.UpdatedOn;
                    objListContacts.PK_ContListID = item.PK_ContListID;
                    lstListContacts.Add(objListContacts);
                }
            }
            objEmailCampDataContext = null;
            objListContacts = null;
            return lstListContacts;

        }

        #endregion
    }
}
