using System;

namespace DataAccessLayer.App_Code
{
    public class Campaign
    {
        private int PK_CampaignID1;

        public int PK_CampaignID
        {
            get { return PK_CampaignID1; }
            set { PK_CampaignID1 = value; }
        }      

        private int FK_UserID1;

        public int FK_UserID
        {
            get { return FK_UserID1; }
            set { FK_UserID1 = value; }
        }

        private string CampaignName1;

        public string CampaignName
        {
            get { return CampaignName1; }
            set { CampaignName1 = value; }
        }

        private string Title1;

        public string Title
        {
            get { return Title1; }
            set { Title1 = value; }
        }

        private DateTime? SchduleDateTime1;

        public DateTime? SchduleDateTime
        {
            get { return SchduleDateTime1; }
            set { SchduleDateTime1 = value; }
        }

        private string CampTimezone1;

        public string CampTimezone
        {
            get { return CampTimezone1; }
            set { CampTimezone1 = value; }
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

        private DateTime? utctime1;

public DateTime? Utctime
{
  get { return utctime1; }
  set { utctime1 = value; }
}

private string FromName1;

public string FromName
{
  get { return FromName1; }
  set { FromName1 = value; }
}
private string Emailid1;

public string Emailid
{
    get { return Emailid1; }
    set { Emailid1 = value; }
}

private bool? CampaignStatus1;

public bool? CampaignStatus
{
    get { return CampaignStatus1; }
    set { CampaignStatus1 = value; }
}
private string mailcontent1;

public string mailcontent
{
    get { return mailcontent1; }
    set { mailcontent1 = value; }
}
 


    }

    public class campaignreport : Campaign
    {
        private int? Subscribers1;

        public int? Subscribers
        {
            get { return Subscribers1; }
            set { Subscribers1 = value; }
        }

        private int? mailsent1;

        public int? mailsent
        {
            get { return mailsent1; }
            set { mailsent1 = value; }
        }

        private DateTime? SentOn1;

        public DateTime? SentOn
        {
            get { return SentOn1; }
            set { SentOn1 = value; }
        }

    }
}
