using System;

namespace DataAccessLayer.App_Code
{
    public class Company
    {
        private int PK_CompanyID1;

        public int PK_CompanyID
        {
            get { return PK_CompanyID1; }
            set { PK_CompanyID1 = value; }
        }
        private string Company_Name1;

        public string Company_Name
        {
            get { return Company_Name1; }
            set { Company_Name1 = value; }
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
    }
}
