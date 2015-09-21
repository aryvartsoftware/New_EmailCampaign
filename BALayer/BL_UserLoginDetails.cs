using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    /// <summary>
    /// Created By :: Sakthivel.R
    /// Created On :: 31-3-2015
    /// Comments :: This Business Logic Layer is for User login details.
    /// </summary>
    public class BL_UserLoginDetails
    {
        DL_UserLoginDetails objDL_UserLoginDetails = new DL_UserLoginDetails();
        UserDetails objUserDetails1 = new UserDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();
        public void AccessInsertUserLogin(UserDetails objUserDetails1)
        {
            objDL_UserLoginDetails.UserDetailsInsert(objUserDetails1);
        }

        public void AccessUpdateUserLogin(UserDetails objUserDetails1)
        {
            objDL_UserLoginDetails.UserDetailsUpdate(objUserDetails1);
        }

        public void AccessDeleteUserLogin(int UserDetailsid)
        {
            objDL_UserLoginDetails.UserDetailsDelete(UserDetailsid);
        }

        public List<UserDetails> SelectUserDetailsListforgrid()
        {
            return objDL_UserLoginDetails.UserDetailsSelectforgrid();
        }

        public List<UserDetails> SelectUserDetailsList(int UserDetailsid)
        {
            return objDL_UserLoginDetails.UserDetailsSelect(UserDetailsid);
        }

        public List<UserDetails> SelectUserDetailsforLogin(string UserName, string Password)
        {
            return objDL_UserLoginDetails.UserDetailsSelectforLogin(UserName, Password);

        }

        public List<UserDetails> SelectUserDetailsforForgetPassword(string emailid)
        {
            return objDL_UserLoginDetails.ForgotPasswordbasedonEmailid(emailid);
        }

        public int AccessVerifyUserEmailidExist(string emailid)
        {
            int emailstatus = objDL_UserLoginDetails.VerifyUserEmailidExist(emailid);
            return emailstatus;
        }

        public int AccessVerifyUserFileNameExist(string FileName)
        {
            int FileNamestatus = objDL_UserLoginDetails.VerifyUserFileNameExist(FileName);
            return FileNamestatus;
        }

        public int ReturnUserLoginMaxID()
        {
            int lastRecord = objDL_UserLoginDetails.UserLoginMaxID();
            return lastRecord;
        }
    }
}
