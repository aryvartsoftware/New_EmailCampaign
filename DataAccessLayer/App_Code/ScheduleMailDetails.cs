using System;

namespace DataAccessLayer.App_Code
{
    public class ScheduleMailDetails
    {
        private int PK_ScheduleID1;

        public int PK_ScheduleID
        {
            get { return PK_ScheduleID1; }
            set { PK_ScheduleID1 = value; }
        }
        private int FK_ContactID1;

        public int FK_ContactID
        {
            get { return FK_ContactID1; }
            set { FK_ContactID1 = value; }
        }
        private DateTime? scheduledatetime1;

        public DateTime? Scheduledatetime
        {
            get { return scheduledatetime1; }
            set { scheduledatetime1 = value; }
        }
        private int FK_Scheduleby1;

        public int FK_Scheduleby
        {
            get { return FK_Scheduleby1; }
            set { FK_Scheduleby1 = value; }
        }
        private bool? QueueStatus1;

        public bool? QueueStatus
        {
            get { return QueueStatus1; }
            set { QueueStatus1 = value; }
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

        private int FK_CampaignID1;

        public int FK_CampaignID
        {
            get { return FK_CampaignID1; }
            set { FK_CampaignID1 = value; }
        }
    }
}
