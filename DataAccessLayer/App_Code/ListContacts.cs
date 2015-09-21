using System;

namespace DataAccessLayer.App_Code
{
    public class ListContacts
    {
        private int PK_ContListID1;

        public int PK_ContListID
        {
            get { return PK_ContListID1; }
            set { PK_ContListID1 = value; }
        }
        private string ListName1;

        public string ListName
        {
            get { return ListName1; }
            set { ListName1 = value; }
        }
        private string comments1;

        public string Comments
        {
            get { return comments1; }
            set { comments1 = value; }
        }
        private int? CreatedBy1;

        public int? CreatedBy
        {
            get { return CreatedBy1; }
            set { CreatedBy1 = value; }
        }

        private int? TotalCount1;

        public int? TotalCount
        {
            get { return TotalCount1; }
            set { TotalCount1 = value; }
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
        private int? FK_CompanyID1;

        public int? FK_CompanyID
        {
            get { return FK_CompanyID1; }
            set { FK_CompanyID1 = value; }
        }
    }
}
