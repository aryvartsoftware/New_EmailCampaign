using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.App_Code
{
    public class UserDetails
    {
        private int PK_UserID1;

        public int PK_UserID
        {
            get { return PK_UserID1; }
            set { PK_UserID1 = value; }
        }
        private int? FK_CompanyID1;

        public int? FK_CompanyID
        {
            get { return FK_CompanyID1; }
            set { FK_CompanyID1 = value; }
        }
        private string LastName1;

        public string LastName
        {
            get { return LastName1; }
            set { LastName1 = value; }
        }
        private string FirstName1;

        public string FirstName
        {
            get { return FirstName1; }
            set { FirstName1 = value; }
        }
        private string UserName1;

        public string UserName
        {
            get { return UserName1; }
            set { UserName1 = value; }
        }
        private int UserType1;

        public int UserType
        {
            get { return UserType1; }
            set { UserType1 = value; }
        }
        private string addressline11;

        public string Addressline1
        {
            get { return addressline11; }
            set { addressline11 = value; }
        }
        private string city11;

        public string City1
        {
            get { return city11; }
            set { city11 = value; }
        }
        private string state11;

        public string State1
        {
            get { return state11; }
            set { state11 = value; }
        }
        private string country11;

        public string Country1
        {
            get { return country11; }
            set { country11 = value; }
        }
        private string Designation1;

        public string Designation
        {
            get { return Designation1; }
            set { Designation1 = value; }
        }
        private DateTime? DateOfBirth1;

        public DateTime? DateOfBirth
        {
            get { return DateOfBirth1; }
            set { DateOfBirth1 = value; }
        }
        private string email_id1;

        public string Email_id
        {
            get { return email_id1; }
            set { email_id1 = value; }
        }
        private string ContactNo1;

        public string ContactNo
        {
            get { return ContactNo1; }
            set { ContactNo1 = value; }
        }
        private string AlternativeNo1;

        public string AlternativeNo
        {
            get { return AlternativeNo1; }
            set { AlternativeNo1 = value; }
        }
        private DateTime? MemberSince1;

        public DateTime? MemberSince
        {
            get { return MemberSince1; }
            set { MemberSince1 = value; }
        }
        private DateTime? MemberTill1;

        public DateTime? MemberTill
        {
            get { return MemberTill1; }
            set { MemberTill1 = value; }
        }
        private bool IsActive1;

        public bool IsActive
        {
            get { return IsActive1; }
            set { IsActive1 = value; }
        }
        private int? CreatedBy1;

        public int? CreatedBy
        {
            get { return CreatedBy1; }
            set { CreatedBy1 = value; }
        }
        private DateTime? CreatedOn1;

        public DateTime? CreatedOn
        {
            get { return CreatedOn1; }
            set { CreatedOn1 = value; }
        }
        private int? UpdatedBy1;

        public int? UpdatedBy
        {
            get { return UpdatedBy1; }
            set { UpdatedBy1 = value; }
        }
        private DateTime? UpdatedOn1;

        public DateTime? UpdatedOn
        {
            get { return UpdatedOn1; }
            set { UpdatedOn1 = value; }
        }
        private int? ReportID1;

        public int? ReportID
        {
            get { return ReportID1; }
            set { ReportID1 = value; }
        }
        private int? FK_RoleID1;

        public int? FK_RoleID
        {
            get { return FK_RoleID1; }
            set { FK_RoleID1 = value; }
        }
        private int? TotalMailCount1;

        public int? TotalMailCount
        {
            get { return TotalMailCount1; }
            set { TotalMailCount1 = value; }
        }
        private int? TotalContactsCount1;

        public int? TotalContactsCount
        {
            get { return TotalContactsCount1; }
            set { TotalContactsCount1 = value; }
        }
        private int? FK_UserPlanID1;

        public int? FK_UserPlanID
        {
            get { return FK_UserPlanID1; }
            set { FK_UserPlanID1 = value; }
        }

        private string UserPassword1;

        public string UserPassword
        {
            get { return UserPassword1; }
            set { UserPassword1 = value; }
        }

        private string UserPhoto1;

        public string UserPhoto
        {
            get { return UserPhoto1; }
            set { UserPhoto1 = value; }
        }

        private Boolean AccountActivated1;

        public Boolean AccountActivated
        {
            get { return AccountActivated1; }
            set { AccountActivated1 = value; }
        }

        private Boolean SendNewsLetter1;

        public Boolean SendNewsLetter
        {
            get { return SendNewsLetter1; }
            set { SendNewsLetter1 = value; }
        }
    }
}
