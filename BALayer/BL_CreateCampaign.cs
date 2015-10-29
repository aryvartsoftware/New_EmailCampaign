using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;
using System.Data;
using System;


namespace BALayer
{
    public class BL_CreateCampaign
    {
        DL_CreateCampaign objDL_CreateCampaign = new DL_CreateCampaign();
        Campaign objCampaign1 = new Campaign();
        List<Campaign> lstCampaign = new List<Campaign>();
        
        public void AccessInsertCampign(Campaign objCampaign1)
        {
            objDL_CreateCampaign.CampaignInsert(objCampaign1);
        }

        public void AccessUpdateCampign(Campaign objCampaign1)
        {
            objDL_CreateCampaign.CampaignUpdate(objCampaign1);
        }

        public void AccessDeleteCampign(int Campaignid)
        {
            objDL_CreateCampaign.CampaignDelete(Campaignid);
        }

        public DataSet SelectCampaignListforgrid(string uertype, Nullable<int> companyid, Nullable<int> Userid, string alpha)
        {
            return objDL_CreateCampaign.CampaignSelectforgrid(uertype, companyid, Userid, alpha);
        }

        public DataSet SelectCampaignListforgridBasedonfilter(string uertype, int companyid, string CampName, string Title, Nullable<DateTime> CreatedOn, string all, string fromname)
        {
            return objDL_CreateCampaign.CampaignSelectforgridBasedonFilter(uertype, companyid, CampName, Title, CreatedOn, all, fromname);
        }

        public DataSet SelectCampaignreportListforgrid(string uertype, int Userid, string alpha)
        {
            return objDL_CreateCampaign.CampaignReportSelectforgrid(uertype, Userid, alpha);
        }

        public DataSet SelectCampaignreportListforgridBasedonfilter(string uertype, int companyid, string CampName, string Title, Nullable<DateTime> CreatedOn, string all)
        {
            return objDL_CreateCampaign.CampaignReportSelectforgridBasedonFilter(uertype, companyid, CampName, Title, CreatedOn, all);
        }

        public List<Campaign> SelectCampaignListbasedonid(int campid)
        {
            return objDL_CreateCampaign.CampaignSelectbasedonid(campid);
        }
        public List<Campaign> SelectCampaignBindDashboard(int CompanyID)
        {
            return objDL_CreateCampaign.CampaignBindDashboard(CompanyID);
        }
      
    }
}
