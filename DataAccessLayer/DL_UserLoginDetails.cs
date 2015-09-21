using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DL_UserLoginDetails
    {
        EmailCampDataContext objEmailCampDataContext = new EmailCampDataContext();
        UserDetails objUserDetails = new UserDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 23-3-2015
        /// Comments :: Insertion function of UserDetails.
        /// </summary>
        #region Insert_UserDetailsCreation
        public void UserDetailsInsert(UserDetails objUserDetails)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Insert = (from cde in objEmailCampDataContext.spUserLogin_AllActions(objUserDetails.PK_UserID, objUserDetails.FK_CompanyID, objUserDetails.LastName, objUserDetails.FirstName, objUserDetails.UserName, objUserDetails.UserType, objUserDetails.Addressline1, objUserDetails.City1, objUserDetails.State1, objUserDetails.Country1, objUserDetails.Designation, objUserDetails.DateOfBirth, objUserDetails.Email_id, objUserDetails.ContactNo, objUserDetails.AlternativeNo, objUserDetails.MemberSince, objUserDetails.MemberTill, objUserDetails.IsActive, objUserDetails.CreatedBy, objUserDetails.CreatedOn, objUserDetails.UpdatedBy, objUserDetails.UpdatedOn, objUserDetails.ReportID, objUserDetails.FK_RoleID, objUserDetails.TotalMailCount, objUserDetails.TotalContactsCount, objUserDetails.FK_UserPlanID, objUserDetails.UserPassword, objUserDetails.UserPhoto, objUserDetails.AccountActivated, objUserDetails.SendNewsLetter, "i")
                              select cde).ToList();

                Insert = null;
                objUserDetails = null;
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
        /// Comments :: Updation function of UserDetails details.
        /// </summary>
        #region Update_UserDetailsCreation
        public void UserDetailsUpdate(UserDetails objUserDetails)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Update = (from cde in objEmailCampDataContext.spUserLogin_AllActions(objUserDetails.PK_UserID, objUserDetails.FK_CompanyID, objUserDetails.LastName, objUserDetails.FirstName, objUserDetails.UserName, objUserDetails.UserType, objUserDetails.Addressline1, objUserDetails.City1, objUserDetails.State1, objUserDetails.Country1, objUserDetails.Designation, objUserDetails.DateOfBirth, objUserDetails.Email_id, objUserDetails.ContactNo, objUserDetails.AlternativeNo, objUserDetails.MemberSince, objUserDetails.MemberTill, objUserDetails.IsActive, objUserDetails.CreatedBy, objUserDetails.CreatedOn, objUserDetails.UpdatedBy, objUserDetails.UpdatedOn, objUserDetails.ReportID, objUserDetails.FK_RoleID, objUserDetails.TotalMailCount, objUserDetails.TotalContactsCount, objUserDetails.FK_UserPlanID, objUserDetails.UserPassword, objUserDetails.UserPhoto, objUserDetails.AccountActivated, objUserDetails.SendNewsLetter, "u")
                              select cde).ToList();

                Update = null;
                objUserDetails = null;
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
        /// Comments :: Updation function of UserDetails details.
        /// </summary>
        #region Delete_UserDetailsCreation
        public void UserDetailsDelete(int UserDetailsid)
        {

            try
            {
                objEmailCampDataContext = new EmailCampDataContext();

                var Delete = (from cde in objEmailCampDataContext.spUserLogin_AllActions(UserDetailsid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "d")
                              select cde).ToList();

                Delete = null;
                objUserDetails = null;
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
        /// Comments :: Select all records for UserDetails.
        /// </summary>
        #region Select_All_Records_CreateUserDetails
        public List<UserDetails> UserDetailsSelectforgrid()
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserDetails = new List<UserDetails>();

            var Select = (from cde in objEmailCampDataContext.spUserLogin_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,  null, "a")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserDetails = new List<UserDetails>();
                foreach (var item in Select)
                {
                    objUserDetails = new UserDetails();
                    objUserDetails.PK_UserID = item.PK_UserID;
                    objUserDetails.FK_CompanyID = Convert.ToInt16(item.FK_CompanyID);
                    objUserDetails.LastName = item.LastName;
                    objUserDetails.FirstName = item.FirstName;
                    objUserDetails.UserName = item.UserName;
                    objUserDetails.UserType = Convert.ToInt16(item.UserType);
                    objUserDetails.Addressline1 = item.addressline1;
                    objUserDetails.City1 = item.city1;
                    objUserDetails.State1 = item.state1;
                    objUserDetails.Country1 = item.country1;
                    objUserDetails.Designation = item.Designation;
                    objUserDetails.DateOfBirth = item.DateOfBirth;
                    objUserDetails.Email_id = item.email_id;
                    objUserDetails.ContactNo = item.ContactNo;
                    objUserDetails.AlternativeNo = item.AlternativeNo;
                    objUserDetails.MemberSince = Convert.ToDateTime(item.MemberSince);
                    objUserDetails.MemberTill = Convert.ToDateTime(item.MemberTill);
                    objUserDetails.IsActive = item.IsActive;
                    objUserDetails.CreatedBy = item.CreatedBy;
                    objUserDetails.CreatedOn = item.CreatedOn;
                    objUserDetails.UpdatedBy = item.UpdatedBy;
                    objUserDetails.UpdatedOn = item.UpdatedOn;
                    objUserDetails.ReportID = item.ReportID;
                    objUserDetails.FK_RoleID = item.FK_RoleID;
                    objUserDetails.TotalMailCount = item.TotalMailCount;
                    objUserDetails.TotalContactsCount = item.TotalContactsCount;
                    objUserDetails.FK_UserPlanID = item.FK_UserPlanID;
                    objUserDetails.UserPassword = item.UserPassword;
                    lstUserDetails.Add(objUserDetails);
                }
            }
            objEmailCampDataContext = null;
            objUserDetails = null;
            return lstUserDetails;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-3-2015
        /// Comments :: Select records for UserDetails.
        /// </summary>
        #region Select_Records_CreateUserDetails
        public List<UserDetails> UserDetailsSelect(int UserDetailsid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserDetails = new List<UserDetails>();

            var Select = (from cde in objEmailCampDataContext.spUserLogin_AllActions(UserDetailsid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "s")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserDetails = new List<UserDetails>();
                foreach (var item in Select)
                {
                    objUserDetails = new UserDetails();
                    objUserDetails.PK_UserID = item.PK_UserID;
                    objUserDetails.FK_CompanyID = Convert.ToInt16(item.FK_CompanyID);
                    objUserDetails.LastName = item.LastName;
                    objUserDetails.FirstName = item.FirstName;
                    objUserDetails.UserName = item.UserName;
                    objUserDetails.UserType = Convert.ToInt16(item.UserType);
                    objUserDetails.Addressline1 = item.addressline1;
                    objUserDetails.City1 = item.city1;
                    objUserDetails.State1 = item.state1;
                    objUserDetails.Country1 = item.country1;
                    objUserDetails.Designation = item.Designation;
                    objUserDetails.DateOfBirth = item.DateOfBirth;
                    objUserDetails.Email_id = item.email_id;
                    objUserDetails.ContactNo = item.ContactNo;
                    objUserDetails.AlternativeNo = item.AlternativeNo;
                    objUserDetails.MemberSince = Convert.ToDateTime(item.MemberSince);
                    objUserDetails.MemberTill = Convert.ToDateTime(item.MemberTill);
                    objUserDetails.IsActive = item.IsActive;
                    objUserDetails.CreatedBy = item.CreatedBy;
                    objUserDetails.CreatedOn = item.CreatedOn;
                    objUserDetails.UpdatedBy = item.UpdatedBy;
                    objUserDetails.UpdatedOn = item.UpdatedOn;
                    objUserDetails.ReportID = item.ReportID;
                    objUserDetails.FK_RoleID = item.FK_RoleID;
                    objUserDetails.TotalMailCount = item.TotalMailCount;
                    objUserDetails.TotalContactsCount = item.TotalContactsCount;
                    objUserDetails.FK_UserPlanID = item.FK_UserPlanID;
        objUserDetails.UserPassword = item.UserPassword;
        objUserDetails.UserPhoto = item.UserPhoto;
        objUserDetails.AccountActivated = Convert.ToBoolean(item.AccountActivated);
        objUserDetails.SendNewsLetter = Convert.ToBoolean(item.SendNewsLetter);
                    lstUserDetails.Add(objUserDetails);
                }
            }
            objEmailCampDataContext = null;
            objUserDetails = null;
            return lstUserDetails;

        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 30-3-2015
        /// Comments :: Check user credentials and retrieve records for UserDetails .
        /// </summary>
        #region Select_Records_CreateUserDetailsforlogin
        public List<UserDetails> UserDetailsSelectforLogin(string UserName, string Password)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserDetails = new List<UserDetails>();

            var Select = (from cde in objEmailCampDataContext.spUserLogin_AllActions(null, null, null, null, UserName, null, null, null, null, null, null, null, UserName, null, null, null, null, null, null, null, null, null, null, null, null, null, null, Password, null, null, null, "p")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserDetails = new List<UserDetails>();
                foreach (var item in Select)
                {
                    objUserDetails = new UserDetails();
                    objUserDetails.PK_UserID = item.PK_UserID;
                    objUserDetails.FK_CompanyID = Convert.ToInt16(item.FK_CompanyID);
                    objUserDetails.LastName = item.LastName;
                    objUserDetails.FirstName = item.FirstName;
                    objUserDetails.UserName = item.UserName;
                    objUserDetails.UserType = Convert.ToInt16(item.UserType);
                    objUserDetails.Addressline1 = item.addressline1;
                    objUserDetails.City1 = item.city1;
                    objUserDetails.State1 = item.state1;
                    objUserDetails.Country1 = item.country1;
                    objUserDetails.Designation = item.Designation;
                    objUserDetails.DateOfBirth = item.DateOfBirth;
                    objUserDetails.Email_id = item.email_id;
                    objUserDetails.ContactNo = item.ContactNo;
                    objUserDetails.AlternativeNo = item.AlternativeNo;
                    objUserDetails.MemberSince = Convert.ToDateTime(item.MemberSince);
                    objUserDetails.MemberTill = Convert.ToDateTime(item.MemberTill);
                    objUserDetails.IsActive = item.IsActive;
                    objUserDetails.CreatedBy = item.CreatedBy;
                    objUserDetails.CreatedOn = item.CreatedOn;
                    objUserDetails.UpdatedBy = item.UpdatedBy;
                    objUserDetails.UpdatedOn = item.UpdatedOn;
                    objUserDetails.ReportID = item.ReportID;
                    objUserDetails.FK_RoleID = item.FK_RoleID;
                    objUserDetails.TotalMailCount = item.TotalMailCount;
                    objUserDetails.TotalContactsCount = item.TotalContactsCount;
                    objUserDetails.FK_UserPlanID = item.FK_UserPlanID;
objUserDetails.UserPassword = item.UserPassword;
objUserDetails.UserPhoto = item.UserPhoto;
objUserDetails.AccountActivated = Convert.ToBoolean(item.AccountActivated);
objUserDetails.SendNewsLetter = Convert.ToBoolean(item.SendNewsLetter);
                    lstUserDetails.Add(objUserDetails);
                }
            }
            objEmailCampDataContext = null;
            objUserDetails = null;
            return lstUserDetails;

        }

        #endregion

              /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 8-4-2015
        /// Comments :: For forget password .
        /// </summary>
        #region Select_Records_Basedon_emaiidforlogin

        public List<UserDetails> ForgotPasswordbasedonEmailid(string emailid)
        {
            objEmailCampDataContext = new EmailCampDataContext();
            lstUserDetails = new List<UserDetails>();

            var Select = (from cde in objEmailCampDataContext.spUserLogin_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, emailid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "e")
                          select cde).ToList();

            if (Select.Count > 0)
            {
                lstUserDetails = new List<UserDetails>();
                foreach (var item in Select)
                {
                    objUserDetails = new UserDetails();
                    objUserDetails.PK_UserID = item.PK_UserID;
                    objUserDetails.FK_CompanyID = Convert.ToInt16(item.FK_CompanyID);
                    objUserDetails.LastName = item.LastName;
                    objUserDetails.FirstName = item.FirstName;
                    objUserDetails.UserName = item.UserName;
                    objUserDetails.UserType = Convert.ToInt16(item.UserType);
                    objUserDetails.Addressline1 = item.addressline1;
                    objUserDetails.City1 = item.city1;
                    objUserDetails.State1 = item.state1;
                    objUserDetails.Country1 = item.country1;
                    objUserDetails.Designation = item.Designation;
                    objUserDetails.DateOfBirth = item.DateOfBirth;
                    objUserDetails.Email_id = item.email_id;
                    objUserDetails.ContactNo = item.ContactNo;
                    objUserDetails.AlternativeNo = item.AlternativeNo;
                    objUserDetails.MemberSince = Convert.ToDateTime(item.MemberSince);
                    objUserDetails.MemberTill = Convert.ToDateTime(item.MemberTill);
                    objUserDetails.IsActive = item.IsActive;
                    objUserDetails.CreatedBy = item.CreatedBy;
                    objUserDetails.CreatedOn = item.CreatedOn;
                    objUserDetails.UpdatedBy = item.UpdatedBy;
                    objUserDetails.UpdatedOn = item.UpdatedOn;
                    objUserDetails.ReportID = item.ReportID;
                    objUserDetails.FK_RoleID = item.FK_RoleID;
                    objUserDetails.TotalMailCount = item.TotalMailCount;
                    objUserDetails.TotalContactsCount = item.TotalContactsCount;
                    objUserDetails.FK_UserPlanID = item.FK_UserPlanID;
                    objUserDetails.UserPassword = item.UserPassword;
                    objUserDetails.AccountActivated = Convert.ToBoolean(item.AccountActivated);
                    objUserDetails.SendNewsLetter = Convert.ToBoolean(item.SendNewsLetter);
                    lstUserDetails.Add(objUserDetails);
                }
            }
            objEmailCampDataContext = null;
            objUserDetails = null;
            return lstUserDetails;
        }
 #endregion
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 6-4-2015
        /// Comments :: Verify User Emailid Exist.
        /// </summary>
        #region Select_Records_VerifyUserEmailidExist

        public int VerifyUserEmailidExist(string emailid)
        {
            int status = 0;
            objEmailCampDataContext = new EmailCampDataContext();

            var Select = (from cde in objEmailCampDataContext.spUserLogin_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, emailid, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "e")
                          select cde).ToList();

            if (Select.Count > 0)
                status = 1;
            
            Select = null;
            objEmailCampDataContext = null;
            return status;
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 10-4-2015
        /// Comments :: Verify User FileName Exist.
        /// </summary>
        #region Select_Records_VerifyUserFileNameExist

        public int VerifyUserFileNameExist(string FileName)
        {
            int status = 0;
            objEmailCampDataContext = new EmailCampDataContext();

            var Select = (from cde in objEmailCampDataContext.spUserLogin_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, FileName, null, null, "t")
                          select cde).ToList();

            if (Select.Count > 0)
                status = 1;

            Select = null;
            objEmailCampDataContext = null;
            return status;
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 7-4-2015
        /// Comments :: Select maximum primary key records for User Login details.
        /// </summary>
        #region Get_UserLogin_MAx_ID
        public int UserLoginMaxID()
        {
            objEmailCampDataContext = new EmailCampDataContext();

            var Select = (from cde in objEmailCampDataContext.spUserLogin_AllActions(null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "a")
                          select cde).ToList();

            int lastUserLogin = 0;

            if (Select.Count > 0)
            {
                lastUserLogin = Convert.ToInt16(Select.LastOrDefault().PK_UserID);
            }
            objEmailCampDataContext = null;
            Select = null;
            return lastUserLogin;

        }

        #endregion
    }
}
