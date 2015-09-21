using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    public class BL_CampaignQueue
    {
        DL_CampaignQueue objDL_CampaignQueue = new DL_CampaignQueue();
        CampaignQueue objCampaignQueue1 = new CampaignQueue();
        List<CampaignQueue> lstCampaignQueue = new List<CampaignQueue>();

        public string AccessInsertCampignQueue(CampaignQueue objCampaignQueue1)
        {
            string pkid = objDL_CampaignQueue.CampaignQueueInsert(objCampaignQueue1);
            return pkid;
        }

        public void AccessUpdateCampignQueue(CampaignQueue objCampaignQueue1)
        {
            objDL_CampaignQueue.CampaignQueueUpdate(objCampaignQueue1);
        }

        public void AccessDeleteCampignQueue(int CampaignQueueid)
        {
            objDL_CampaignQueue.CampaignQueueDelete(CampaignQueueid);
        }

        public List<CampaignQueue> SelectCampaignQueueforcampid(int campid)
        {
            return objDL_CampaignQueue.CampaignQueuebasedoncampid(campid);
        }

        public List<CampaignQueue> SelectCampaignQueueforcontactid(int contactid)
        {
            return objDL_CampaignQueue.CampaignQueuebasedoncontactid(contactid);
        }

        public List<CampaignQueue> SelectCampaignQueueListbasedonid(int campid)
        {
            return objDL_CampaignQueue.CampaignQueueSelectbasedonid(campid);
        }

      
    }
}
