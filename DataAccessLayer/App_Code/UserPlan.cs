using System;

namespace DataAccessLayer.App_Code
{
    public class UserPlan
    {
        private int PK_UserPlanID1;

        public int PK_UserPlanID
        {
            get { return PK_UserPlanID1; }
            set { PK_UserPlanID1 = value; }
        }
        private int FK_UserID1;

        public int FK_UserID
        {
            get { return FK_UserID1; }
            set { FK_UserID1 = value; }
        }
        private int FK_PlanID1;

        public int FK_PlanID
        {
            get { return FK_PlanID1; }
            set { FK_PlanID1 = value; }
        }
        private DateTime ActiveFrom1;

        public DateTime ActiveFrom
        {
            get { return ActiveFrom1; }
            set { ActiveFrom1 = value; }
        }
        private DateTime ActiveTo1;

        public DateTime ActiveTo
        {
            get { return ActiveTo1; }
            set { ActiveTo1 = value; }
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

    }
}
