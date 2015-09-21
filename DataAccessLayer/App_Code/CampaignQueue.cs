using System;

namespace DataAccessLayer.App_Code
{
    public class CampaignQueue
    {
        private int PK_CampaignQueueID1;

        public int PK_CampaignQueueID
        {
            get { return PK_CampaignQueueID1; }
            set { PK_CampaignQueueID1 = value; }
        }

        private int? val1;

        public int? Val
        {
            get { return val1; }
            set { val1 = value; }
        }

        private int FK_CampaignID1;

        public int FK_CampaignID
        {
            get { return FK_CampaignID1; }
            set { FK_CampaignID1 = value; }
        }
        private int FK_ContactID1;

        public int FK_ContactID
        {
            get { return FK_ContactID1; }
            set { FK_ContactID1 = value; }
        }
        private DateTime? SentOn1;

        public DateTime? SentOn
        {
            get { return SentOn1; }
            set { SentOn1 = value; }
        }
        private string MailFailedContent1;

        public string MailFailedContent
        {
            get { return MailFailedContent1; }
            set { MailFailedContent1 = value; }
        }
        private bool? IsMailSent1;

        public bool? IsMailSent
        {
            get { return IsMailSent1; }
            set { IsMailSent1 = value; }
        }
        private bool? isBounced1;

        public bool? IsBounced
        {
            get { return isBounced1; }
            set { isBounced1 = value; }
        }
        private bool? Isdelivered1;

        public bool? Isdelivered
        {
            get { return Isdelivered1; }
            set { Isdelivered1 = value; }
        }
        private bool? IsHardBounce1;

        public bool? IsHardBounce
        {
            get { return IsHardBounce1; }
            set { IsHardBounce1 = value; }
        }
        private bool? IsRead1;

        public bool? IsRead
        {
            get { return IsRead1; }
            set { IsRead1 = value; }
        }
        private byte ReadCount1;

        public byte ReadCount
        {
            get { return ReadCount1; }
            set { ReadCount1 = value; }
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
