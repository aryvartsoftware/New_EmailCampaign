using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailCampaign
{
    public partial class ActivateSuccess : System.Web.UI.Page
    {
        New_EmailCampaign.App_Code.CryptographicHashCode objCryptographicHashCode = new New_EmailCampaign.App_Code.CryptographicHashCode();
        UserDetails objUserDetails = new UserDetails();
        BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //String originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
                //String parentDirectory = originalPath.Substring(0, originalPath.LastIndexOf("/"));
                //String result = originalPath.Substring(originalPath.LastIndexOf('?') + 1);
                //string DecryptQry = objCryptographicHashCode.DecryptCipherTextToPlainText(result);

                if (Request.QueryString["id"] != null)
                {
                    string DecryptQry = objCryptographicHashCode.DecryptCipherTextToPlainText(Request.QueryString["id"].ToString());
                    objUserDetails = new UserDetails();
                    objBL_UserLoginDetails = new BL_UserLoginDetails();
                    lstUserDetails = new List<UserDetails>();
                    lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsList(Convert.ToInt32(DecryptQry));

                    if (lstUserDetails.Count > 0)
                    {
                        objUserDetails.PK_UserID = lstUserDetails[0].PK_UserID;
                        objUserDetails.FK_CompanyID = lstUserDetails[0].FK_CompanyID;
                        objUserDetails.LastName = lstUserDetails[0].LastName;
                        objUserDetails.FirstName = lstUserDetails[0].FirstName;
                        objUserDetails.UserName = lstUserDetails[0].UserName;
                        objUserDetails.UserType = lstUserDetails[0].UserType;
                        objUserDetails.Addressline1 = lstUserDetails[0].Addressline1;
                        objUserDetails.City1 = lstUserDetails[0].City1;
                        objUserDetails.State1 = lstUserDetails[0].State1;
                        objUserDetails.Country1 = lstUserDetails[0].Country1;
                        objUserDetails.Designation = lstUserDetails[0].Designation;
                        objUserDetails.DateOfBirth = lstUserDetails[0].DateOfBirth;
                        objUserDetails.Email_id = lstUserDetails[0].Email_id;
                        objUserDetails.ContactNo = lstUserDetails[0].ContactNo;
                        objUserDetails.AlternativeNo = lstUserDetails[0].AlternativeNo;
                        objUserDetails.MemberSince = lstUserDetails[0].MemberSince;
                        objUserDetails.MemberTill = lstUserDetails[0].MemberTill;
                        objUserDetails.IsActive = lstUserDetails[0].IsActive;
                        objUserDetails.CreatedBy = lstUserDetails[0].CreatedBy;
                        objUserDetails.CreatedOn = lstUserDetails[0].CreatedOn;
                        objUserDetails.UpdatedBy = lstUserDetails[0].PK_UserID;
                        objUserDetails.UpdatedOn = DateTime.Now;
                        objUserDetails.ReportID = lstUserDetails[0].ReportID;
                        objUserDetails.FK_RoleID = lstUserDetails[0].FK_RoleID;
                        objUserDetails.TotalMailCount = lstUserDetails[0].TotalMailCount;
                        objUserDetails.TotalContactsCount = lstUserDetails[0].TotalContactsCount;
                        objUserDetails.FK_UserPlanID = lstUserDetails[0].FK_UserPlanID;
                        objUserDetails.UserPassword = lstUserDetails[0].UserPassword;
                        objUserDetails.UserPhoto = lstUserDetails[0].UserPhoto;
                        objUserDetails.AccountActivated = true;
                        objUserDetails.SendNewsLetter = lstUserDetails[0].SendNewsLetter;

                        objBL_UserLoginDetails.AccessUpdateUserLogin(objUserDetails);
                        objUserDetails = null;
                        objBL_UserLoginDetails = null;
                        lstUserDetails = null;
                    }
                }
            }
        }
    }
}