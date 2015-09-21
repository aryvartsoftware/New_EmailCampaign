using System;

namespace DataAccessLayer.App_Code
{
    public class UserContacts
    {
        private int PK_ContactID1;

        public int PK_ContactID
        {
            get { return PK_ContactID1; }
            set { PK_ContactID1 = value; }
        }

        private int? FK_UserID1;

        public int? FK_UserID
        {
            get { return FK_UserID1; }
            set { FK_UserID1 = value; }
        }
        private string ContactName1;

        public string ContactName
        {
            get { return ContactName1; }
            set { ContactName1 = value; }
        }
        private string Designation1;

        public string Designation
        {
            get { return Designation1; }
            set { Designation1 = value; }
        }
        private string Addressline11;

        public string Addressline1
        {
            get { return Addressline11; }
            set { Addressline11 = value; }
        }
        private string City11;

        public string City1
        {
            get { return City11; }
            set { City11 = value; }
        }
        private string State11;

        public string State1
        {
            get { return State11; }
            set { State11 = value; }
        }
        private string Country11;

        public string Country1
        {
            get { return Country11; }
            set { Country11 = value; }
        }
        private string email_id1;

        public string Email_id
        {
            get { return email_id1; }
            set { email_id1 = value; }
        }
        private string MailContent1;

        public string MailContent
        {
            get { return MailContent1; }
            set { MailContent1 = value; }
        }
        private string ContactNo1;

        public string ContactNo
        {
            get { return ContactNo1; }
            set { ContactNo1 = value; }
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

        private DateTime? DateofBirth1;
        public DateTime? DateofBirth
        {
            get { return DateofBirth1; }
            set { DateofBirth1 = value; }
        }
    }
}
