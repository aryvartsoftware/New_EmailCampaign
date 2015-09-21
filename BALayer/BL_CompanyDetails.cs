using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    /// <summary>
    /// Created By :: Sakthivel.R
    /// Created On :: 2-4-2015
    /// Comments :: This Business Logic Layer is for User Company details.
    /// </summary>
    public class BL_CompanyDetails
    {
        DL_CompanyDetails objDL_CompanyDetails = new DL_CompanyDetails();
        Company objCompany1 = new Company();
        List<Company> lstCompany = new List<Company>();
        public void AccessInsertCompany(Company objCompany1)
        {
            objDL_CompanyDetails.CompanyInsert(objCompany1);
        }

        public void AccessUpdateCompany(Company objCompany1)
        {
            objDL_CompanyDetails.CompanyUpdate(objCompany1);
        }

        public void AccessDeleteCompany(int Companyid)
        {
            objDL_CompanyDetails.CompanyDelete(Companyid);
        }

        public List<Company> SelectAllCompanyList()
        {
            return objDL_CompanyDetails.CompanySelectforgrid();
        }
        public List<Company> SelectCompanyListbasedonid(int id)
        {
            return objDL_CompanyDetails.CompanySelectbasedonid(id);
        }
        public int ReturnCompanyMaxID()
        {
           int lastRecord = objDL_CompanyDetails.CompanyMaxID();
           return lastRecord;
        }
    }
}
