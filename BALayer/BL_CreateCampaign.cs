using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

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

        public List<Campaign> SelectCampaignListforgrid(string uertype, int companyid)
        {
            return objDL_CreateCampaign.CampaignSelectforgrid(uertype, companyid);
        }

        public List<Campaign> SelectCampaignListbasedonid(int campid)
        {
            return objDL_CreateCampaign.CampaignSelectbasedonid(campid);
        }

      
    }
}
