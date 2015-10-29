using DataAccessLayer.App_Code;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace DataAccessLayer
{
    public class DL_CreateCampaign
    {

        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        Campaign objCampaign = new Campaign();
        List<Campaign> lstCampaign = new List<Campaign>();

        ListToDataSet objListToDataSet = new ListToDataSet();

        campaignreport objcampaignreport = new campaignreport();
        List<campaignreport> lstCampaignreport = new List<campaignreport>();
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

                var Insert = (from cde in objEmailCampDataContext.spCampaign_AllActions(objCampaign.PK_CampaignID, objCampaign.FK_UserID, objCampaign.CampaignName, objCampaign.Title, objCampaign.SchduleDateTime, objCampaign.CampTimezone, objCampaign.Utctime, objCampaign.FromName, objCampaign.Emailid, objCampaign.CreatedBy, objCampaign.CreatedOn, objCampaign.UpdatedBy, objCampaign.UpdatedOn, objCampaign.CampaignStatus, objCampaign.mailcontent, null, null, null, "i")
                              select cde).ToList();

                Insert = null;
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
        #region Update_CampaignCreation
        public void CampaignUpdate(Campaign objCampaign)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spCampaign_AllActions(objCampaign.PK_CampaignID, objCampaign.FK_UserID, objCampaign.CampaignName, objCampaign.Title, objCampaign.SchduleDateTime, objCampaign.CampTimezone, objCampaign.Utctime, objCampaign.FromName, objCampaign.Emailid, objCampaign.CreatedBy, objCampaign.CreatedOn, objCampaign.UpdatedBy, objCampaign.UpdatedOn, objCampaign.CampaignStatus, objCampaign.mailcontent, null, null, null, "u")
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

                var Delete = (from cde in objEmailCampDataContext.spCampaign_AllActions(Campaignid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "d")
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
        public DataSet CampaignSelectforgrid(string uertype, Nullable<int> companyid, Nullable<int> userid, string alpha)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaign = new List<Campaign>();

            var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(null, userid, null, null, null, null, null, null, alpha, companyid, null, null, null, null, null, null, null, null, uertype)
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
            DataSet converted = new DataSet();

            if (lstCampaign.Count > 0)
            {
                converted.Tables.Add(ListToDataSet.newTable(lstCampaign));
                return converted;
            }
            else
            {
                converted.Tables.Add(ListToDataSet.newTableColumnAlone(lstCampaign));
                return converted;
            }

        }

        #endregion

        #region Select_All_Records_BasedonFilter_CreateCampaign
        public DataSet CampaignSelectforgridBasedonFilter(string uertype, int companyid, string CampName, string Title, Nullable<DateTime> CreatedOn, string all, string fromname)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaign = new List<Campaign>();


            var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(null, companyid, CampName, Title, null, null, null, fromname, all, null, CreatedOn, null, null, null, null, null, null, null, uertype)
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
            DataSet converted = new DataSet();
            
            if (lstCampaign.Count > 0)
            {
                converted.Tables.Add(ListToDataSet.newTable(lstCampaign));
                return converted;
            }
            else
            {
                converted.Tables.Add(ListToDataSet.newTableColumnAlone(lstCampaign));
                return converted;
            }
        }

        #endregion


        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 10-1-2015
        /// Comments :: Select all records for Campaign report details based on uertype and userid.
        /// </summary>
        #region Select_All_Records_CreateCampaignReport
        public DataSet CampaignReportSelectforgrid(string uertype, int userid, string alpha)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaignreport = new List<campaignreport>();

            var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(null, userid, null, null, null, null, null, null, alpha, null, null, null, null, null, null, null, null, null, uertype)
                          select cde).ToList();


            if (Select.Count > 0)
            {
                lstCampaignreport = new List<campaignreport>();
                foreach (var item in Select)
                {
                    objcampaignreport = new campaignreport();
                    objcampaignreport.CampaignName = Convert.ToString(item.CampaignName);
                    objcampaignreport.CampTimezone = Convert.ToString(item.CampTimezone);
                    objcampaignreport.CreatedBy = item.CreatedBy;
                    objcampaignreport.CreatedOn = item.CreatedOn;
                    objcampaignreport.UpdatedBy = item.UpdatedBy;
                    objcampaignreport.UpdatedOn = item.UpdatedOn;
                    objcampaignreport.Emailid = item.Emailid;
                    objcampaignreport.FK_UserID = item.FK_UserID;
                    objcampaignreport.FromName = item.FromName;
                    objcampaignreport.PK_CampaignID = item.PK_CampaignID;
                    objcampaignreport.SchduleDateTime = item.SchduleDateTime;
                    objcampaignreport.Title = item.Title;
                    objcampaignreport.Utctime = item.utctime;
                    objcampaignreport.CampaignStatus = item.CampaignStatus;
                    objcampaignreport.mailcontent = item.mailcontent;
                    objcampaignreport.Subscribers = item.Subscribers;
                    objcampaignreport.mailsent = item.mailsent;
                     objcampaignreport.SentOn = item.SentOn;

                    lstCampaignreport.Add(objcampaignreport);
                }
            }
            objEmailCampDataContext = null;
            objcampaignreport = null;
            DataSet converted = new DataSet();

            if (lstCampaignreport.Count > 0)
            {
                converted.Tables.Add(ListToDataSet.newTable(lstCampaignreport));
                return converted;
            }
            else
            {
                converted.Tables.Add(ListToDataSet.newTableColumnAlone(lstCampaignreport));
                return converted;
            }

        }

        #endregion

        #region Select_All_Records_BasedonFilter_CreateCampaignReport
        public DataSet CampaignReportSelectforgridBasedonFilter(string uertype, int companyid, string CampName, string Title, Nullable<DateTime> CreatedOn, string all)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaignreport = new List<campaignreport>();


            var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(null, companyid, CampName, Title, null, null, null, null, all, null, CreatedOn, null, null, null, null,  null, null, null,uertype)
                          select cde).ToList();


            if (Select.Count > 0)
            {
                lstCampaignreport = new List<campaignreport>();
                foreach (var item in Select)
                {
                    objcampaignreport = new campaignreport();
                    objcampaignreport.CampaignName = Convert.ToString(item.CampaignName);
                    objcampaignreport.CampTimezone = Convert.ToString(item.CampTimezone);
                    objcampaignreport.CreatedBy = item.CreatedBy;
                    objcampaignreport.CreatedOn = item.CreatedOn;
                    objcampaignreport.UpdatedBy = item.UpdatedBy;
                    objcampaignreport.UpdatedOn = item.UpdatedOn;
                    objcampaignreport.Emailid = item.Emailid;
                    objcampaignreport.FK_UserID = item.FK_UserID;
                    objcampaignreport.FromName = item.FromName;
                    objcampaignreport.PK_CampaignID = item.PK_CampaignID;
                    objcampaignreport.SchduleDateTime = item.SchduleDateTime;
                    objcampaignreport.Title = item.Title;
                    objcampaignreport.Utctime = item.utctime;
                    objcampaignreport.CampaignStatus = item.CampaignStatus;
                    objcampaignreport.mailcontent = item.mailcontent;
                    objcampaignreport.Subscribers = item.Subscribers;
                    objcampaignreport.mailsent = item.mailsent;
                    objcampaignreport.SentOn = item.SentOn;
                    lstCampaignreport.Add(objcampaignreport);
                }
            }


            objEmailCampDataContext = null;
            objcampaignreport = null;
            DataSet converted = new DataSet();

            if (lstCampaignreport.Count > 0)
            {
                converted.Tables.Add(ListToDataSet.newTable(lstCampaignreport));
                return converted;
            }
            else
            {
                converted.Tables.Add(ListToDataSet.newTableColumnAlone(lstCampaignreport));
                return converted;
            }
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

            var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(Campaignid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "s")
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

        public List<Campaign> CampaignBindDashboard(int CompanyID)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstCampaign = new List<Campaign>();

            var Select = (from cde in objEmailCampDataContext.spCampaign_AllActions(null, CompanyID, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "p")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstCampaign = new List<Campaign>();
                foreach (var item in Select)
                {
                    objCampaign = new Campaign();
                    objCampaign.CampaignName = Convert.ToString(item.CampaignName);                  
                    objCampaign.PK_CampaignID = item.PK_CampaignID;                   
                    lstCampaign.Add(objCampaign);
                }
            }
            objEmailCampDataContext = null;
            objCampaign = null;
            return lstCampaign;
        }


    }
}
