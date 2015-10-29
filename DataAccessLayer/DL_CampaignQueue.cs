using DataAccessLayer.App_Code;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLayer
{
    public class DL_CampaignQueue
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        CampaignQueue objCampaignQueue = new CampaignQueue();
        List<CampaignQueue> lstCampaignQueue = new List<CampaignQueue>();
        long? val = 0;

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 27-5-2015
        /// Comments :: Insertion function of CampaignQueue details.
        /// </summary>
        #region Insert_CampaignQueueCreation
        public string CampaignQueueInsert(CampaignQueue objCampaignQueue)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();
                long? totrow = 0;
                var Insert = (from cde in objEmailCampDataContext.spCampaignQueue_AllActions(objCampaignQueue.PK_CampaignQueueID, objCampaignQueue.FK_CampaignID, objCampaignQueue.SentOn, objCampaignQueue.MailFailedContent, objCampaignQueue.IsMailSent, objCampaignQueue.IsBounced, objCampaignQueue.Isdelivered, objCampaignQueue.IsHardBounce, objCampaignQueue.IsRead, objCampaignQueue.ReadCount, objCampaignQueue.CreatedBy, objCampaignQueue.CreatedOn, objCampaignQueue.UpdatedBy, objCampaignQueue.UpdatedOn, objCampaignQueue.FK_ContactID, ref totrow, "i")
                              select cde).ToList();
                //totrow = (int)objEmailCampDataContext.spCampaignQueue_AllActions(objCampaignQueue.PK_CampaignQueueID, objCampaignQueue.FK_CampaignID, objCampaignQueue.SentOn, objCampaignQueue.MailFailedContent, objCampaignQueue.IsMailSent, objCampaignQueue.IsBounced, objCampaignQueue.Isdelivered, objCampaignQueue.IsHardBounce, objCampaignQueue.IsRead, objCampaignQueue.ReadCount, objCampaignQueue.CreatedBy, objCampaignQueue.CreatedOn, objCampaignQueue.UpdatedBy, objCampaignQueue.UpdatedOn, objCampaignQueue.FK_ContactID, ref val, "i").ReturnValue;
                              
                Insert = null;
                
                objEmailCampDataContext = null;
                return totrow.ToString();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-3-2015
        /// Comments :: Updation function of CampaignQueue details.
        /// </summary>
        #region Update_CampaignQueueCreation
        public void CampaignQueueUpdate(CampaignQueue objCampaignQueue)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spCampaignQueue_AllActions(objCampaignQueue.PK_CampaignQueueID, objCampaignQueue.FK_CampaignID, objCampaignQueue.SentOn, objCampaignQueue.MailFailedContent, objCampaignQueue.IsMailSent, objCampaignQueue.IsBounced, objCampaignQueue.Isdelivered, objCampaignQueue.IsHardBounce, objCampaignQueue.IsRead, objCampaignQueue.ReadCount, objCampaignQueue.CreatedBy, objCampaignQueue.CreatedOn, objCampaignQueue.UpdatedBy, objCampaignQueue.UpdatedOn, objCampaignQueue.FK_ContactID, ref val,  "u")
                              select cde).ToList();

                Update = null;
                objCampaignQueue = null;
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
        /// Created On :: 30-3-2015
        /// Comments :: Updation function of CampaignQueue details.
        /// </summary>
        #region Delete_CampaignQueueCreation
        public void CampaignQueueDelete(int CampaignQueueid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spCampaignQueue_AllActions(CampaignQueueid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "d")
                              select cde).ToList();

                Delete = null;
                objCampaignQueue = null;
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
        /// Created On :: 30-3-2015
        /// Comments :: Select all records for CampaignQueue details based on uertype and companyid.
        /// </summary>
        #region Select_All_Records_CreateCampaignQueue
        public List<CampaignQueue> CampaignQueuebasedoncampid(int campid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaignQueue = new List<CampaignQueue>();
           
           var Select = (from cde in objEmailCampDataContext.spCampaignQueue_AllActions(null, campid, null, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "a")
                              select cde).ToList();
           


            if (Select.Count > 0)
            {
                lstCampaignQueue = new List<CampaignQueue>();
                foreach (var item in Select)
                {
                    objCampaignQueue = new CampaignQueue();
                    objCampaignQueue.PK_CampaignQueueID = item.PK_CampaignQueueID;
                    
                    if(item.FK_CampaignID != null)
                        objCampaignQueue.FK_CampaignID = Convert.ToInt32(item.FK_CampaignID);

                    objCampaignQueue.SentOn = item.SentOn;
                    objCampaignQueue.MailFailedContent = item.MailFailedContent;
                    objCampaignQueue.IsMailSent = item.IsMailSent;
                    objCampaignQueue.IsBounced = item.isBounced;
                    objCampaignQueue.Isdelivered = item.Isdelivered;
                    objCampaignQueue.IsHardBounce = item.IsHardBounce;
                    objCampaignQueue.IsRead = item.IsRead;
                    
                    if (item.ReadCount != null)
                        objCampaignQueue.ReadCount = Convert.ToByte(item.ReadCount.ToString());
                    if (item.FK_ContactID != null)
                        objCampaignQueue.FK_ContactID = Convert.ToInt32(item.FK_ContactID);

                    objCampaignQueue.CreatedBy = item.CreatedBy;
                    objCampaignQueue.CreatedOn = item.CreatedOn;
                    objCampaignQueue.UpdatedBy = item.UpdatedBy;
                    objCampaignQueue.UpdatedOn = item.UpdatedOn;
                    lstCampaignQueue.Add(objCampaignQueue);
                }
            }
            objEmailCampDataContext = null;
            objCampaignQueue = null;
            return lstCampaignQueue;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 24-9-2015
        /// Comments :: Select all records for Campaign details based on uertype and companyid.
        /// </summary>
        #region Select_MailCount
        public string SelectMailCount(int companyid, DateTime ActiveFrom, DateTime ActiveTo)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            long? totrow = 0;
            var Select = (from cde in objEmailCampDataContext.spCampaignQueue_AllActions(companyid, null, null, null, null, null, null, null, null, null, null, ActiveFrom, null, ActiveTo, null, ref totrow, "e")
                          select cde).ToList();
            return totrow.ToString();
        }
        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-5-2015
        /// Comments :: Select all records for CampaignQueue details based on contactid.
        /// </summary>
        #region Select_All_Records_CreateCampaignQueue
        public List<CampaignQueue> CampaignQueuebasedoncontactid(int contactid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaignQueue = new List<CampaignQueue>();

            var Select = (from cde in objEmailCampDataContext.spCampaignQueue_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, null, null, contactid, ref val, "c")
                          select cde).ToList();



            if (Select.Count > 0)
            {
                lstCampaignQueue = new List<CampaignQueue>();
                foreach (var item in Select)
                {
                    objCampaignQueue = new CampaignQueue();
                    objCampaignQueue.PK_CampaignQueueID = item.PK_CampaignQueueID;

                    if (item.FK_CampaignID != null)
                        objCampaignQueue.FK_CampaignID = Convert.ToInt32(item.FK_CampaignID);

                    objCampaignQueue.SentOn = item.SentOn;
                    objCampaignQueue.MailFailedContent = item.MailFailedContent;
                    objCampaignQueue.IsMailSent = item.IsMailSent;
                    objCampaignQueue.IsBounced = item.isBounced;
                    objCampaignQueue.Isdelivered = item.Isdelivered;
                    objCampaignQueue.IsHardBounce = item.IsHardBounce;
                    objCampaignQueue.IsRead = item.IsRead;

                    if (item.ReadCount != null)
                        objCampaignQueue.ReadCount = Convert.ToByte(item.ReadCount.ToString());
                    if (item.FK_ContactID != null)
                        objCampaignQueue.FK_ContactID = Convert.ToInt32(item.FK_ContactID);

                    objCampaignQueue.CreatedBy = item.CreatedBy;
                    objCampaignQueue.CreatedOn = item.CreatedOn;
                    objCampaignQueue.UpdatedBy = item.UpdatedBy;
                    objCampaignQueue.UpdatedOn = item.UpdatedOn;
                    lstCampaignQueue.Add(objCampaignQueue);
                }
            }
            objEmailCampDataContext = null;
            objCampaignQueue = null;
            return lstCampaignQueue;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-3-2015
        /// Comments :: Select all records for CampaignQueue details based on CampaignQueueid.
        /// </summary>
        public List<CampaignQueue> CampaignQueueSelectbasedonid(int CampaignQueueid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaignQueue = new List<CampaignQueue>();

            var Select = (from cde in objEmailCampDataContext.spCampaignQueue_AllActions(CampaignQueueid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, ref val, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstCampaignQueue = new List<CampaignQueue>();
                foreach (var item in Select)
                {
                    objCampaignQueue = new CampaignQueue();
                    objCampaignQueue.PK_CampaignQueueID = item.PK_CampaignQueueID;

                    if (item.FK_CampaignID != null)
                        objCampaignQueue.FK_CampaignID = Convert.ToInt32(item.FK_CampaignID);

                    objCampaignQueue.SentOn = item.SentOn;
                    objCampaignQueue.MailFailedContent = item.MailFailedContent;
                    objCampaignQueue.IsMailSent = item.IsMailSent;
                    objCampaignQueue.IsBounced = item.isBounced;
                    objCampaignQueue.Isdelivered = item.Isdelivered;
                    objCampaignQueue.IsHardBounce = item.IsHardBounce;
                    objCampaignQueue.IsRead = item.IsRead;

                    if (item.ReadCount != null)
                        objCampaignQueue.ReadCount = Convert.ToByte(item.ReadCount.ToString());

                    if (item.FK_ContactID != null)
                        objCampaignQueue.FK_ContactID = Convert.ToInt32(item.FK_ContactID);
                   
                    objCampaignQueue.CreatedBy = item.CreatedBy;
                    objCampaignQueue.CreatedOn = item.CreatedOn;
                    objCampaignQueue.UpdatedBy = item.UpdatedBy;
                    objCampaignQueue.UpdatedOn = item.UpdatedOn;
                    
                    lstCampaignQueue.Add(objCampaignQueue);
                }
            }
            objEmailCampDataContext = null;
            objCampaignQueue = null;
            return lstCampaignQueue;
        }
    }
}
