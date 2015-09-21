using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.App_Code;

namespace DataAccessLayer
{
    public class DL_ScheduleMailDetails
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        ScheduleMailDetails objScheduleMailDetails = new ScheduleMailDetails();
        List<ScheduleMailDetails> lstScheduleMailDetails = new List<ScheduleMailDetails>();

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 2-6-2015
        /// Comments :: Insertion function of ScheduleMailDetails details.
        /// </summary>
        #region Insert_ScheduleMailDetailsCreation
        public void ScheduleMailDetailsInsert(ScheduleMailDetails objScheduleMailDetails)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Insert = (from cde in objEmailCampDataContext.spScheduleMailDetails_AllActions(objScheduleMailDetails.PK_ScheduleID, objScheduleMailDetails.FK_ContactID, objScheduleMailDetails.Scheduledatetime, objScheduleMailDetails.FK_Scheduleby, objScheduleMailDetails.QueueStatus, objScheduleMailDetails.CreatedBy, objScheduleMailDetails.CreatedOn, objScheduleMailDetails.UpdatedBy, objScheduleMailDetails.UpdatedOn, objScheduleMailDetails.FK_CampaignID, "i")
                              select cde).ToList();

                Insert = null;
                objScheduleMailDetails = null;
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
        /// Created On :: 2-6-2015
        /// Comments :: Updation function of ScheduleMailDetails details.
        /// </summary>
        #region Update_ScheduleMailDetailsCreation
        public void ScheduleMailDetailsUpdate(ScheduleMailDetails objScheduleMailDetails)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spScheduleMailDetails_AllActions(objScheduleMailDetails.PK_ScheduleID, objScheduleMailDetails.FK_ContactID, objScheduleMailDetails.Scheduledatetime, objScheduleMailDetails.FK_Scheduleby, objScheduleMailDetails.QueueStatus, objScheduleMailDetails.CreatedBy, objScheduleMailDetails.CreatedOn, objScheduleMailDetails.UpdatedBy, objScheduleMailDetails.UpdatedOn, objScheduleMailDetails.FK_CampaignID, "u")
                              select cde).ToList();

                Update = null;
                objScheduleMailDetails = null;
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
        /// Created On :: 2-6-2015
        /// Comments :: Delete function of ScheduleMailDetails details.
        /// </summary>
        #region Delete_ScheduleMailDetailsCreation
        public void ScheduleMailDetailsDelete(int ScheduleMailDetailsid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spScheduleMailDetails_AllActions(ScheduleMailDetailsid, null, null, null, null, null, null, null, null, null, "d")
                              select cde).ToList();

                Delete = null;
                objScheduleMailDetails = null;
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
        /// Comments :: Select all records for ScheduleMailDetails details based on uertype and companyid.
        /// </summary>
        //#region Select_All_Records_CreateScheduleMailDetails
        //public List<ScheduleMailDetails> ScheduleMailDetailsbasedoncampid(int campid)
        //{
        //    objEmailCampDataContext = new EmailCampDataContext();
        //    lstScheduleMailDetails = new List<ScheduleMailDetails>();

        //    var Select = (from cde in objEmailCampDataContext.spScheduleMailDetails_AllActions(null, campid, null, null, null, null, null, null, null, null, "a")
        //                  select cde).ToList();



        //    if (Select.Count > 0)
        //    {
        //        lstScheduleMailDetails = new List<ScheduleMailDetails>();
        //        foreach (var item in Select)
        //        {
        //            objScheduleMailDetails = new ScheduleMailDetails();
        //            objScheduleMailDetails.PK_ScheduleMailDetailsID = item.PK_ScheduleMailDetailsID;

        //            if (item.FK_CampaignID != null)
        //                objScheduleMailDetails.FK_CampaignID = Convert.ToInt32(item.FK_CampaignID);

        //            objScheduleMailDetails.SentOn = item.SentOn;
        //            objScheduleMailDetails.MailFailedContent = item.MailFailedContent;
        //            objScheduleMailDetails.IsMailSent = item.IsMailSent;
        //            objScheduleMailDetails.IsBounced = item.isBounced;
        //            objScheduleMailDetails.Isdelivered = item.Isdelivered;
        //            objScheduleMailDetails.IsHardBounce = item.IsHardBounce;
        //            objScheduleMailDetails.IsRead = item.IsRead;

        //            if (item.ReadCount != null)
        //                objScheduleMailDetails.ReadCount = Convert.ToByte(item.ReadCount.ToString());
        //            if (item.FK_ContactID != null)
        //                objScheduleMailDetails.FK_ContactID = Convert.ToInt32(item.FK_ContactID);

        //            objScheduleMailDetails.CreatedBy = item.CreatedBy;
        //            objScheduleMailDetails.CreatedOn = item.CreatedOn;
        //            objScheduleMailDetails.UpdatedBy = item.UpdatedBy;
        //            objScheduleMailDetails.UpdatedOn = item.UpdatedOn;
        //            lstScheduleMailDetails.Add(objScheduleMailDetails);
        //        }
        //    }
        //    objEmailCampDataContext = null;
        //    objScheduleMailDetails = null;
        //    return lstScheduleMailDetails;

        //}

        //#endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-5-2015
        /// Comments :: Select all records for ScheduleMailDetails details based on contactid.
        /// </summary>
        #region Select_All_Records_CreateScheduleMailDetails
        //public List<ScheduleMailDetails> ScheduleMailDetailsbasedoncontactid(int contactid)
        //{
        //    objEmailCampDataContext = new EmailCampDataContext();
        //    lstScheduleMailDetails = new List<ScheduleMailDetails>();

        //    var Select = (from cde in objEmailCampDataContext.spScheduleMailDetails_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, null, null, contactid, "c")
        //                  select cde).ToList();



        //    if (Select.Count > 0)
        //    {
        //        lstScheduleMailDetails = new List<ScheduleMailDetails>();
        //        foreach (var item in Select)
        //        {
        //            objScheduleMailDetails = new ScheduleMailDetails();
        //            objScheduleMailDetails.PK_ScheduleMailDetailsID = item.PK_ScheduleMailDetailsID;

        //            if (item.FK_CampaignID != null)
        //                objScheduleMailDetails.FK_CampaignID = Convert.ToInt32(item.FK_CampaignID);

        //            objScheduleMailDetails.SentOn = item.SentOn;
        //            objScheduleMailDetails.MailFailedContent = item.MailFailedContent;
        //            objScheduleMailDetails.IsMailSent = item.IsMailSent;
        //            objScheduleMailDetails.IsBounced = item.isBounced;
        //            objScheduleMailDetails.Isdelivered = item.Isdelivered;
        //            objScheduleMailDetails.IsHardBounce = item.IsHardBounce;
        //            objScheduleMailDetails.IsRead = item.IsRead;

        //            if (item.ReadCount != null)
        //                objScheduleMailDetails.ReadCount = Convert.ToByte(item.ReadCount.ToString());
        //            if (item.FK_ContactID != null)
        //                objScheduleMailDetails.FK_ContactID = Convert.ToInt32(item.FK_ContactID);

        //            objScheduleMailDetails.CreatedBy = item.CreatedBy;
        //            objScheduleMailDetails.CreatedOn = item.CreatedOn;
        //            objScheduleMailDetails.UpdatedBy = item.UpdatedBy;
        //            objScheduleMailDetails.UpdatedOn = item.UpdatedOn;
        //            lstScheduleMailDetails.Add(objScheduleMailDetails);
        //        }
        //    }
        //    objEmailCampDataContext = null;
        //    objScheduleMailDetails = null;
        //    return lstScheduleMailDetails;

        //}

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-3-2015
        /// Comments :: Select all records for ScheduleMailDetails details based on ScheduleMailDetailsid.
        /// </summary>
        public List<ScheduleMailDetails> ScheduleMailDetailsSelectbasedonid(int ScheduleMailDetailsid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstScheduleMailDetails = new List<ScheduleMailDetails>();

            var Select = (from cde in objEmailCampDataContext.spScheduleMailDetails_AllActions(ScheduleMailDetailsid, null, null, null, null, null, null, null, null, null, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstScheduleMailDetails = new List<ScheduleMailDetails>();
                foreach (var item in Select)
                {
                    objScheduleMailDetails = new ScheduleMailDetails();
                    objScheduleMailDetails.PK_ScheduleID = item.PK_ScheduleID;

                    if (item.FK_CampaignID != null)
                        objScheduleMailDetails.FK_CampaignID = Convert.ToInt32(item.FK_CampaignID);
                    objScheduleMailDetails.Scheduledatetime = item.scheduledatetime;
                    if (item.FK_Scheduleby != null)
                        objScheduleMailDetails.FK_Scheduleby = Convert.ToInt32(item.FK_Scheduleby);
                    objScheduleMailDetails.QueueStatus = item.QueueStatus;
                    if (item.FK_ContactID != null)
                        objScheduleMailDetails.FK_ContactID = Convert.ToInt32(item.FK_ContactID);

                    objScheduleMailDetails.CreatedBy = item.CreatedBy;
                    objScheduleMailDetails.CreatedOn = item.CreatedOn;
                    objScheduleMailDetails.UpdatedBy = item.UpdatedBy;
                    objScheduleMailDetails.UpdatedOn = item.UpdatedOn;

                    lstScheduleMailDetails.Add(objScheduleMailDetails);
                }
            }
            objEmailCampDataContext = null;
            objScheduleMailDetails = null;
            return lstScheduleMailDetails;
        }
    }
}
