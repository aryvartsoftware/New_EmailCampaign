using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

using System.Linq;

namespace DataAccessLayer
{
    public class DL_UserContaxcts
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        UserContacts objUserContacts = new UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();

        EC_UserContact objEC_UserContact = new EC_UserContact();
      

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 23-3-2015
        /// Comments :: Insertion function of UserContacts details.
        /// </summary>
        #region Insert_UserContactsCreation
        public void UserContactsInsert(UserContacts objUserContacts)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Insert = (from cde in objEmailCampDataContext.spUserContacts_AllActions(objUserContacts.PK_ContactID, objUserContacts.FK_UserID, objUserContacts.ContactName, objUserContacts.Designation, objUserContacts.Addressline1, objUserContacts.City1, objUserContacts.State1, objUserContacts.Country1, objUserContacts.Email_id, objUserContacts.MailContent, objUserContacts.ContactNo, objUserContacts.CreatedBy, objUserContacts.CreatedOn, objUserContacts.UpdatedBy, objUserContacts.UpdatedOn, objUserContacts.DateofBirth, "i")
                              select cde).ToList();

                Insert = null;
                objUserContacts = null;
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
        /// Comments :: Updation function of UserContacts details.
        /// </summary>
        #region Update_UserContactsCreation
        public void UserContactsUpdate(UserContacts objUserContacts)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spUserContacts_AllActions(objUserContacts.PK_ContactID, objUserContacts.FK_UserID, objUserContacts.ContactName, objUserContacts.Designation, objUserContacts.Addressline1, objUserContacts.City1, objUserContacts.State1, objUserContacts.Country1, objUserContacts.Email_id, objUserContacts.MailContent, objUserContacts.ContactNo, objUserContacts.CreatedBy, objUserContacts.CreatedOn, objUserContacts.UpdatedBy, objUserContacts.UpdatedOn, objUserContacts.DateofBirth, "u")
                              select cde).ToList();

                Update = null;
                objUserContacts = null;
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
        /// Comments :: Updation function of UserContacts details.
        /// </summary>
        #region Delete_UserContactsCreation
        public void UserContactsDelete(int UserContactsid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spUserContacts_AllActions(UserContactsid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "d")
                              select cde).ToList();

                Delete = null;
                objUserContacts = null;
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
        /// Created On :: 25-4-2015
        /// Comments :: Delete duplicate mail id from UserContacts.
        /// </summary>
        #region Delete_DuplicateEmailid_Uploading
        public void DeleteDuplicateEmailidUploading(int Contactlistid, int CreatedBy)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spUserContacts_AllActions(null, null, null, null, null, null, null, null, null, null, null, CreatedBy, null, null, null, null, "c")
                              select cde).ToList();

                Delete = null;
                objUserContacts = null;
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
        /// Comments :: Select all records for UserContacts details.
        /// </summary>
        #region Select_All_Records_CreateUserContacts
        public List<UserContacts> UserContactsSelectforgrid(int contlistid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserContacts = new List<UserContacts>();

            var Select = (from cde in objEmailCampDataContext.spUserContacts_AllActions(contlistid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserContacts = new List<UserContacts>();
                foreach (var item in Select)
                {
                    objUserContacts = new UserContacts();
                    objUserContacts.Addressline1 = Convert.ToString(item.Addressline1);
                    objUserContacts.City1 = Convert.ToString(item.City1);
                    objUserContacts.CreatedBy = item.CreatedBy;
                    objUserContacts.CreatedOn = item.CreatedOn;
                    objUserContacts.UpdatedBy = item.UpdatedBy;
                    objUserContacts.UpdatedOn = item.UpdatedOn;
                    objUserContacts.Email_id = item.email_id;
                    objUserContacts.FK_UserID = item.FK_UserID;
                    objUserContacts.ContactName = item.ContactName;
                    objUserContacts.PK_ContactID = Convert.ToInt16(item.PK_ContactID.ToString());
                    objUserContacts.State1 = item.State1;
                    objUserContacts.ContactNo = item.ContactNo;
                    objUserContacts.Country1 = item.Country1;
                    objUserContacts.Designation = item.Designation;
                    objUserContacts.MailContent = item.MailContent;
                    objUserContacts.DateofBirth = item.DateofBirth;
                    lstUserContacts.Add(objUserContacts);
                }
            }
            objEmailCampDataContext = null;
            objUserContacts = null;
            return lstUserContacts;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 29-4-2015
        /// Comments :: Select records based on ID for UserContacts details.
        /// </summary>
        #region Select_Records_BasedonID_UserContacts
        public DataSet SelectUserContactsbasedonID(int FKid, string alpha)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserContacts = new List<UserContacts>();

            var Select = (from cde in objEmailCampDataContext.spUserContacts_AllActions(null, FKid, null, null, null, null, null, null, alpha, null, null, null, null, null, null, null, "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserContacts = new List<UserContacts>();
                foreach (var item in Select)
                {
                    objUserContacts = new UserContacts();
                    objUserContacts.Addressline1 = Convert.ToString(item.Addressline1);
                    objUserContacts.City1 = Convert.ToString(item.City1);
                    objUserContacts.CreatedBy = item.CreatedBy;
                    objUserContacts.CreatedOn = item.CreatedOn;
                    objUserContacts.UpdatedBy = item.UpdatedBy;
                    objUserContacts.UpdatedOn = item.UpdatedOn;
                    objUserContacts.Email_id = item.email_id;
                    objUserContacts.FK_UserID = item.FK_UserID;
                    objUserContacts.ContactName = item.ContactName;
                    objUserContacts.PK_ContactID = Convert.ToInt16(item.PK_ContactID.ToString());
                    objUserContacts.State1 = item.State1;
                    objUserContacts.ContactNo = item.ContactNo;
                    objUserContacts.Country1 = item.Country1;
                    objUserContacts.Designation = item.Designation;
                    objUserContacts.MailContent = item.MailContent;
                    objUserContacts.DateofBirth = item.DateofBirth ;
                    lstUserContacts.Add(objUserContacts);
                }
            }
            objEmailCampDataContext = null;
            objUserContacts= null;
            DataSet converted = new DataSet();

            if (lstUserContacts.Count > 0)
            {
                converted.Tables.Add(ListToDataSet.newTable(lstUserContacts));
                return converted;
            }
            else
            {
                converted.Tables.Add(ListToDataSet.newTableColumnAlone(lstUserContacts));
                return converted;
            }

        }

        #endregion

        #region Select_Records_BasedonID_UserContacts_Filter
        public DataSet SelectUserContactsbasedonIDFilter(string ContactName, string Designation, string city, string state, string country, string emailid, string contactno, int FKid, string alpha)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserContacts = new List<UserContacts>();

            var Select = (from cde in objEmailCampDataContext.spUserContacts_AllActions(null, null, ContactName, Designation, alpha, city, state, country, emailid, null, contactno, FKid, null, null, null, null, "e")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserContacts = new List<UserContacts>();
                foreach (var item in Select)
                {
                    objUserContacts = new UserContacts();
                    objUserContacts.Addressline1 = Convert.ToString(item.Addressline1);
                    objUserContacts.City1 = Convert.ToString(item.City1);
                    objUserContacts.CreatedBy = item.CreatedBy;
                    objUserContacts.CreatedOn = item.CreatedOn;
                    objUserContacts.UpdatedBy = item.UpdatedBy;
                    objUserContacts.UpdatedOn = item.UpdatedOn;
                    objUserContacts.Email_id = item.email_id;
                    objUserContacts.FK_UserID = item.FK_UserID;
                    objUserContacts.ContactName = item.ContactName;
                    objUserContacts.PK_ContactID = Convert.ToInt16(item.PK_ContactID.ToString());
                    objUserContacts.State1 = item.State1;
                    objUserContacts.ContactNo = item.ContactNo;
                    objUserContacts.Country1 = item.Country1;
                    objUserContacts.Designation = item.Designation;
                    objUserContacts.MailContent = item.MailContent;
                    objUserContacts.DateofBirth = item.DateofBirth;
                    lstUserContacts.Add(objUserContacts);
                }
            }
            objEmailCampDataContext = null;
            objUserContacts = null;
            DataSet converted = new DataSet();

            if (lstUserContacts.Count > 0)
            {
                converted.Tables.Add(ListToDataSet.newTable(lstUserContacts));
                return converted;
            }
            else
            {
                converted.Tables.Add(ListToDataSet.newTableColumnAlone(lstUserContacts));
                return converted;
            }

        }

        #endregion

        #region Select_RecordsCount_BasedonID_UserContacts
        public int SelectUserContactsCountbasedonID(int FKid)
        {
            objEmailCampDataContext = new EmailCampDataContext();            

            var Select = (from cde in objEmailCampDataContext.spUserContacts_AllActions(null, FKid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "a")
                          select cde).ToList();
            int countrec = 0;

            if (Select.Count > 0)            
                countrec = Select.Count;               
           
            objEmailCampDataContext = null;            
            return countrec;
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 11-5-2015
        /// Comments :: Select records based on checkbox selectedID for UserContacts details.
        /// </summary>
        #region Select_Records_Basedon_Selected_ID_UserContacts
        public List<UserContacts> SelectUserContactsbasedonSelectedID(int FKid, string PKContid)
            {
            //objEmailCampDataContext = new EmailCampDataContext();
            //lstUserContacts = new List<UserContacts>();

            //var Select = (from cde in objEmailCampDataContext.spUserContacts_AllActions(PKContid, FKid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "p")
            //              select cde).ToList();
            //var Select = (from cde in objEmailCampDataContext.EC_UserContacts
            //              where cde.PK_ContactID.ToString().Contains(PKContid)
            //              select cde).ToList();

            //if (Select.Count > 0)
            //{
            //    lstUserContacts = new List<UserContacts>();
            //    foreach (var item in Select)
            //    {
            //        objUserContacts = new UserContacts();
            //        objUserContacts.Addressline1 = Convert.ToString(item.Addressline1);
            //        objUserContacts.City1 = Convert.ToString(item.City1);
            //        objUserContacts.CreatedBy = item.CreatedBy;
            //        objUserContacts.CreatedOn = item.CreatedOn;
            //        objUserContacts.UpdatedBy = item.UpdatedBy;
            //        objUserContacts.UpdatedOn = item.UpdatedOn;
            //        objUserContacts.Email_id = item.email_id;
            //        objUserContacts.FK_UserID = item.FK_UserID;
            //        objUserContacts.ContactName = item.ContactName;
            //        objUserContacts.PK_ContactID = Convert.ToInt16(item.PK_ContactID.ToString());
            //        objUserContacts.State1 = item.State1;
            //        objUserContacts.ContactNo = item.ContactNo;
            //        objUserContacts.Country1 = item.Country1;
            //        objUserContacts.Designation = item.Designation;
            //        objUserContacts.MailContent = item.MailContent;
            //        objUserContacts.DateofBirth = item.DateofBirth;
            //        lstUserContacts.Add(objUserContacts);
            //    }
            //}
            //objEmailCampDataContext = null;
            //objUserContacts = null;
                string cs = "Data Source=ARYVARTDOTNET;Integrated Security=true;Initial Catalog=EmailCampaign;User ID=sa;Password=aryvart@2015";
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter();
                con.Open();

                string excelread = "SELECT a.* from EC_UserContacts a inner join dbo.EC_UserLogin b on a.FK_UserID = b.PK_UserID where b.FK_CompanyID = " + FKid + " and PK_ContactID in (" + PKContid + ")";
                da.SelectCommand = new SqlCommand(excelread, con);
                //da.SelectCommand = new SqlCommand("select * from Addresses_Temp1",con);
                DataTable dt = new DataTable();
                //dt.Columns.Add("S No", typeof(int));
                //dt.Columns.Add("Name", typeof(string));
                //dt.Columns.Add("Email", typeof(string));DBNull.Value ? 0 : 
                da.Fill(dt);
                lstUserContacts = new List<UserContacts>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objUserContacts = new UserContacts();
                    objUserContacts.Addressline1 = Convert.ToString(dt.Rows[i]["Addressline1"]);
                    objUserContacts.City1 = Convert.ToString(dt.Rows[i]["City1"]);

                    if (dt.Rows[i]["CreatedBy"] != DBNull.Value)
                        objUserContacts.CreatedBy = Convert.ToInt16(dt.Rows[i]["CreatedBy"]);
                    if (dt.Rows[i]["CreatedOn"] != DBNull.Value)
                        objUserContacts.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    if (dt.Rows[i]["UpdatedBy"] != DBNull.Value)
                    {
                        //if(dt.Rows[i]["UpdatedBy"].ToString() !="")
                            objUserContacts.UpdatedBy = Convert.ToInt16(dt.Rows[i]["UpdatedBy"]);
                    }
                    if (dt.Rows[i]["UpdatedOn"] != DBNull.Value)
                    {
                        objUserContacts.UpdatedOn = Convert.ToDateTime(dt.Rows[i]["UpdatedOn"]);
                    }
                    if (dt.Rows[i]["email_id"] != DBNull.Value)
                    {
                        //if (dt.Rows[i]["email_id"] != "")
                            objUserContacts.Email_id = dt.Rows[i]["email_id"].ToString();
                    }

                    if (dt.Rows[i]["FK_UserID"] != DBNull.Value)
                    {
                        //if(dt.Rows[i]["FK_UserID"] != "")
                            objUserContacts.FK_UserID = Convert.ToInt16(dt.Rows[i]["FK_UserID"]);
                    }
                    objUserContacts.ContactName = dt.Rows[i]["ContactName"].ToString();

                    if (dt.Rows[i]["PK_ContactID"] != DBNull.Value)
                        objUserContacts.PK_ContactID = Convert.ToInt16(dt.Rows[i]["PK_ContactID"].ToString());

                    objUserContacts.State1 = dt.Rows[i]["State1"].ToString();
                    objUserContacts.ContactNo = dt.Rows[i]["ContactNo"].ToString();
                    objUserContacts.Country1 = dt.Rows[i]["Country1"].ToString();
                    objUserContacts.Designation = dt.Rows[i]["Designation"].ToString();
                    objUserContacts.MailContent = dt.Rows[i]["MailContent"].ToString();

                    if (dt.Rows[i]["DateofBirth"] != DBNull.Value)
                    {
                        if (dt.Rows[i]["DateofBirth"] != "")
                            objUserContacts.DateofBirth = Convert.ToDateTime(dt.Rows[i]["DateofBirth"].ToString());
                    }
                    lstUserContacts.Add(objUserContacts);
                }
                con.Close();

            return lstUserContacts;

        }

        #endregion
    }

}
