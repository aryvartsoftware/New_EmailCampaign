using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BALayer;
using DataAccessLayer.App_Code;

namespace New_EmailCampaign
{
    public partial class checkmailreadcount : System.Web.UI.Page
    {
        CampaignQueue objCampaignQueue = new CampaignQueue();
        BL_CampaignQueue objBL_CampaignQueue = new BL_CampaignQueue();
        List<CampaignQueue> lstCampaignQueue = new List<CampaignQueue>();

        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            int messageId;

            if (Request.QueryString["msg_id"] != null)
            {
                messageId = Convert.ToInt32(Request.QueryString["msg_id"].ToString());
                objCampaignQueue = new CampaignQueue();
                objBL_CampaignQueue = new BL_CampaignQueue();
                lstCampaignQueue = new List<CampaignQueue>();
                objCampaignQueue.PK_CampaignQueueID = messageId;
                lstCampaignQueue = objBL_CampaignQueue.SelectCampaignQueueListbasedonid(objCampaignQueue.PK_CampaignQueueID);
                int readcount = 0;

                if (lstCampaignQueue.Count > 0)
                {
                    objBL_Common = new BL_Common();
                    readcount = lstCampaignQueue[0].ReadCount;

                    if (lstCampaignQueue[0].ReadCount == 0)
                    {
                        readcount = readcount + 1;
                        objBL_Common.AccessUpdateAllCampaign("EC_CampaignQueue", "ReadCount = " + readcount + ",IsRead = 1", "PK_CampaignQueueID =" + messageId + "");
                    }
                    else
                    {
                        readcount = readcount + 1;
                        objBL_Common.AccessUpdateAllCampaign("EC_CampaignQueue", "ReadCount = " + readcount + "", "PK_CampaignQueueID =" + messageId + "");
                    }
                }
                objCampaignQueue = null;
                objBL_CampaignQueue = null;
                lstCampaignQueue = null;
            }
        }
    }
}