using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DL_CompanyDetails
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        Company objCompany = new Company();
        List<Company> lstCompany = new List<Company>();

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 2-4-2015
        /// Comments :: Insertion function of Company details.
        /// </summary>
        #region Insert_CompanyCreation
        public void CompanyInsert(Company objCompany)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Insert = (from cde in objEmailCampDataContext.spCompany_AllActions(objCompany.PK_CompanyID ,objCompany.Company_Name ,objCompany.Email_id ,objCompany.ContactNo ,objCompany.Addressline1 ,objCompany.City1 ,objCompany.State1 ,objCompany.Country1 ,objCompany.CreatedBy ,objCompany.CreatedOn ,objCompany.UpdatedBy ,objCompany.UpdatedOn, "i")
                              select cde).ToList();

                Insert = null;
                objCompany = null;
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
        /// Created On :: 2-4-2015
        /// Comments :: Updation function of Company details.
        /// </summary>
        #region Update_CompanyCreation
        public void CompanyUpdate(Company objCompany)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spCompany_AllActions(objCompany.PK_CompanyID, objCompany.Company_Name, objCompany.Email_id, objCompany.ContactNo, objCompany.Addressline1, objCompany.City1, objCompany.State1, objCompany.Country1, objCompany.CreatedBy, objCompany.CreatedOn, objCompany.UpdatedBy, objCompany.UpdatedOn, "u")
                              select cde).ToList();

                Update = null;
                objCompany = null;
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
        /// Created On :: 2-4-2015
        /// Comments :: Updation function of Company details.
        /// </summary>
        #region Delete_CompanyCreation
        public void CompanyDelete(int Companyid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spCompany_AllActions(Companyid, null, null, null, null, null, null, null, null, null, null, null, "d")
                              select cde).ToList();

                Delete = null;
                objCompany = null;
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
        /// Created On :: 2-4-2015
        /// Comments :: Select all records for Company details.
        /// </summary>
        #region Select_All_Records_CreateCompany
        public List<Company> CompanySelectforgrid()
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCompany = new List<Company>();

            var Select = (from cde in objEmailCampDataContext.spCompany_AllActions(null, null, null, null, null, null, null, null, null, null, null, null,  "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstCompany = new List<Company>();
                foreach (var item in Select)
                {
                    objCompany = new Company();
                    objCompany.Addressline1 = Convert.ToString(item.addressline1);
                    objCompany.City1 = Convert.ToString(item.city1);
                    objCompany.CreatedBy = Convert.ToInt16(item.CreatedBy);
                    objCompany.CreatedOn = Convert.ToDateTime(item.CreatedOn);
                    objCompany.UpdatedBy = Convert.ToInt16(item.UpdatedBy);
                    objCompany.UpdatedOn = Convert.ToDateTime(item.UpdatedOn);
                    objCompany.Company_Name = item.Company_Name;
                    objCompany.ContactNo = item.ContactNo;
                    objCompany.Country1 = item.country1;
                    objCompany.PK_CompanyID = item.PK_CompanyID;
                    objCompany.Email_id = item.email_id;
                    objCompany.State1 = item.state1;
                    lstCompany.Add(objCompany);
                }
            }
            objEmailCampDataContext = null;
            objCompany = null;
            return lstCompany;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 2-4-2015
        /// Comments :: Select all records for Company details.
        /// </summary>
        #region Select_All_Records_CreateCompany
        public List<Company> CompanySelectbasedonid(int id)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCompany = new List<Company>();

            var Select = (from cde in objEmailCampDataContext.spCompany_AllActions(id, null, null, null, null, null, null, null, null, null, null, null, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstCompany = new List<Company>();
                foreach (var item in Select)
                {
                    objCompany = new Company();
                    objCompany.Addressline1 = Convert.ToString(item.addressline1);
                    objCompany.City1 = Convert.ToString(item.city1);
                    objCompany.CreatedBy = Convert.ToInt16(item.CreatedBy);
                    objCompany.CreatedOn = Convert.ToDateTime(item.CreatedOn);
                    objCompany.UpdatedBy = Convert.ToInt16(item.UpdatedBy);
                    objCompany.UpdatedOn = Convert.ToDateTime(item.UpdatedOn);
                    objCompany.Company_Name = item.Company_Name;
                    objCompany.ContactNo = item.ContactNo;
                    objCompany.Country1 = item.country1;
                    objCompany.PK_CompanyID = item.PK_CompanyID;
                    objCompany.Email_id = item.email_id;
                    objCompany.State1 = item.state1;
                    lstCompany.Add(objCompany);
                }
            }
            objEmailCampDataContext = null;
            objCompany = null;
            return lstCompany;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 6-4-2015
        /// Comments :: Select maximum primary key records for Company details.
        /// </summary>
        #region Get_Company_MAx_ID
        public int CompanyMaxID()
        {
            objEmailCampDataContext = new EmailCampDataContext();

            var Select = (from cde in objEmailCampDataContext.spCompany_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, "a")
                          select cde).ToList();

            int lastCompany = 0;

            if (Select.Count > 0)
            {
                lastCompany = Convert.ToInt16(Select.LastOrDefault().PK_CompanyID);
            }
            objEmailCampDataContext = null;
            Select = null;
            return lastCompany;

        }

        #endregion
    }
}
