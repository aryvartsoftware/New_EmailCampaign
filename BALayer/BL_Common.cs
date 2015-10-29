
using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;
using System.Data;

namespace BALayer
{
    public class BL_Common
    {
        CommonQueryClass objCommonQueryClass = new CommonQueryClass();
        public void AccessDeletAlleCampaign(string tblName, string Column, string Campaignid)
        {
            objCommonQueryClass.Deleteall(tblName, Column, Campaignid);
        }

        public void AccessUpdateAllCampaign(string tblName, string Column, string wherecondition)
        {
            objCommonQueryClass.Updateall(tblName, Column, wherecondition);
        }

        public void AccessUpdatecampue(string tblName, string Column, string wherecondition, string content)
        {
            objCommonQueryClass.UpdateCampqueall(tblName, Column, wherecondition, content);
        }

        public string IsValidUser(string Column, string tblName, string wherecondition)
        {
            return objCommonQueryClass.IsValidUser(Column, tblName, wherecondition);
        }

        public DataTable campaignreport(int PK_CampaignID)
        {
            return objCommonQueryClass.campaignreportdata(PK_CampaignID);
        }

        public DataTable Inviteuserlist(int companyid)
        {
            return objCommonQueryClass.listuserbasedoncompanyid(companyid);
        }
        public DataTable DashboardBarChart(int companyid)
        {
            return objCommonQueryClass.listDashboardBarchart(companyid);
        }
        public DataTable plantypedetails(string Column, string tblName, string wherecondition)
        {
            return objCommonQueryClass.listselectquery(Column, tblName, wherecondition);
        }

        public DataTable SelectColumnQuery(string Column)
        {
            return objCommonQueryClass.listselectqueryColumn(Column);
        }

        public List<long> SelectDashboardChart(int companyid)
        {
            return objCommonQueryClass.DashboardChart(companyid);
        }
    }
}
