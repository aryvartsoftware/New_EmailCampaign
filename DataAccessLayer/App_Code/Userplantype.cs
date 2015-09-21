using System;

namespace DataAccessLayer.App_Code
{
    public class Userplantype
    {
        private int PK_PlanID1;

        public int PK_PlanID
        {
            get { return PK_PlanID1; }
            set { PK_PlanID1 = value; }
        }

        private string PlanName1;
        public string PlanName
        {
            get { return PlanName1; }
            set { PlanName1 = value; }
        }

        private bool IsSingleUser1;

        public bool IsSingleUser
        {
            get { return IsSingleUser1; }
            set { IsSingleUser1 = value; }
        }
        private int Planrate1;

        public int Planrate
        {
            get { return Planrate1; }
            set { Planrate1 = value; }
        }
        private int NOC1;

        public int NOC
        {
            get { return NOC1; }
            set { NOC1 = value; }
        }
        private int AllowedMails1;

        public int AllowedMails
        {
            get { return AllowedMails1; }
            set { AllowedMails1 = value; }
        }
        private bool? IsActive1;

        public bool? IsActive
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
        private DateTime? plandate1;

        public DateTime? Plandate
        {
            get { return plandate1; }
            set { plandate1 = value; }
        }
    }
}
