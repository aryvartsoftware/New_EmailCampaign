using DataAccessLayer.App_Code;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
   public class DL_CreateCampaign
    {

       EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
       Campaign objCampaign = new Campaign();
       List<Campaign> lstCampaign = new List<Campaign>();
       
       /// <summary>
       /// Created By :: Sakthivel.R
       /// Created On :: 23-3-2015
        /// Comments :: Insertion function of Campaign details.
       /// </summary>
       #region Insert_CampaignCreation
       public void CampaignInsert(Campaign objCampaign)
       {
           
           try
           {
               objEmailCampDataContext = new EmailCampDataContext();

               var Insert = (from cde in objEmailCampDataContext.spCampaign_AllActions(objCampaign.PK_CampaignID, objCampaign.FK_UserID, objCampaign.CampaignName, objCampaign.Title, objCampaign.SchduleDateTime, objCampaign.CampTimezone, objCampaign.Utctime, objCampaign.FromName, objCampaign.Emailid, objCampaign.CreatedBy, objCampaign.CreatedOn, objCampaign.UpdatedBy, objCampaign.UpdatedOn, objCampaign.CampaignStatus, objCampaign.mailcontent, "i")
                                select cde).ToList();

               Insert = null;
               objCampaign = null;
               objEmailCampDataContext = null;
           }
           catch(Exception ex)
           {
               ex.ToString();
           }
       }

       #endregion

       /// <summary>
       /// Created By :: Sakthivel.R
       /// Created On :: 30-3-2015
       /// Comments :: Updation function of Campaign details.
       /// </summary>
       #region Update_CampaignCreation
       public void CampaignUpdate(Campaign objCampaign)
       {

           try
           {
               objEmailCampDataContext = new EmailCampDataContext();

               var Update = (from cde in objEmailCampDataContext.spCampaign_AllActions(objCampaign.PK_CampaignID, objCampaign.FK_UserID, objCampaign.CampaignName, objCampaign.Title, objCampaign.SchduleDateTime, objCampaign.CampTimezone, objCampaign.Utctime, objCampaign.FromName, objCampaign.Emailid, objCampaign.CreatedBy, objCampaign.CreatedOn, objCampaign.UpdatedBy, objCampaign.UpdatedOn, objCampaign.CampaignStatus, objCampaign.mailcontent, "u")
                             select cde).ToList();

               Update = null;
               objCampaign = null;
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
       /// Comments :: Updation function of Campaign details.
       /// </summary>
       #region Delete_CampaignCreation
       public void CampaignDelete(int Campaignid)
       {

           try
           {
               objEmailCampDataContext = new EmailCampDataContext();

               var Delete = (from cde in objEmailCampDataContext.spCampaign_AllActions(Campaignid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "d")
                             select cde).ToList();

               Delete = null;
               objCampaign = null;
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
       /// Comments :: Select all records for Campaign details based on uertype and companyid.
       /// </summary>
       #region Select_All_Records_CreateCampaign
       public List<Campaign> CampaignSelectforgrid(string uertype, int companyid)
       {          
               objEmailCampDataContext = new EmailCampDataContext();
               lstCampaign = new List<Campaign>();


               var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(null, companyid, null, null, null, null, null, null, null, null, null, null, null, null, null, uertype)
                                 select cde).ToList();
              

               if (Select.Count > 0)
               {
                   lstCampaign = new List<Campaign>();
                   foreach (var item in Select)
                   {
                       objCampaign = new Campaign();
                       objCampaign.CampaignName = Convert.ToString(item.CampaignName);
                       objCampaign.CampTimezone = Convert.ToString(item.CampTimezone);
                       objCampaign.CreatedBy = item.CreatedBy;
                       objCampaign.CreatedOn = item.CreatedOn;
                       objCampaign.UpdatedBy = item.UpdatedBy;
                       objCampaign.UpdatedOn = item.UpdatedOn;
                       objCampaign.Emailid = item.Emailid;
                       objCampaign.FK_UserID = item.FK_UserID;
                       objCampaign.FromName = item.FromName;
                       objCampaign.PK_CampaignID = item.PK_CampaignID;
                       objCampaign.SchduleDateTime = item.SchduleDateTime;
                       objCampaign.Title = item.Title;
                       objCampaign.Utctime = item.utctime;
                       objCampaign.CampaignStatus = item.CampaignStatus;
                       objCampaign.mailcontent = item.mailcontent;
                       lstCampaign.Add(objCampaign);
                   }
               }
               objEmailCampDataContext = null;
               objCampaign = null;
               return lstCampaign;
          
       }

       #endregion
      
       /// <summary>
       /// Created By :: Sakthivel.R
       /// Created On :: 30-3-2015
       /// Comments :: Select all records for Campaign details based on campaignid.
       /// </summary>
       public List<Campaign> CampaignSelectbasedonid(int Campaignid)
       {
             objEmailCampDataContext = new EmailCampDataContext();
               lstCampaign = new List<Campaign>();

               var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(Campaignid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "s")
                             select cde).ToList();

               if (Select.Count > 0)
               {
                   lstCampaign = new List<Campaign>();
                   foreach (var item in Select)
                   {
                       objCampaign = new Campaign();
                       objCampaign.CampaignName = Convert.ToString(item.CampaignName);
                       objCampaign.CampTimezone = Convert.ToString(item.CampTimezone);
                       objCampaign.CreatedBy = item.CreatedBy;
                       objCampaign.CreatedOn = item.CreatedOn;
                       objCampaign.UpdatedBy = item.UpdatedBy;
                       objCampaign.UpdatedOn = item.UpdatedOn;
                       objCampaign.Emailid = item.Emailid;
                       objCampaign.FK_UserID = item.FK_UserID;
                       objCampaign.CampaignStatus = item.CampaignStatus;
                       objCampaign.CampTimezone = item.CampTimezone;
                       objCampaign.FromName = item.FromName;
                       objCampaign.PK_CampaignID = item.PK_CampaignID;
                       objCampaign.SchduleDateTime = item.SchduleDateTime;
                       objCampaign.Title = item.Title;
                       objCampaign.Utctime = item.utctime;
                       objCampaign.mailcontent = item.mailcontent;
                       lstCampaign.Add(objCampaign);
                   }
               }
               objEmailCampDataContext = null;
               objCampaign = null;
               return lstCampaign;         
       }
     
    }
}
