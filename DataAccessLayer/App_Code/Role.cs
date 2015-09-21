using System;

namespace DataAccessLayer.App_Code
{
    public class Role
    {
        private int PK_RoleID1;

        public int PK_RoleID
        {
            get { return PK_RoleID1; }
            set { PK_RoleID1 = value; }
        }
        private int FK_CompanyID1;

        public int FK_CompanyID
        {
            get { return FK_CompanyID1; }
            set { FK_CompanyID1 = value; }
        }
        private string RoleName1;

        public string RoleName
        {
            get { return RoleName1; }
            set { RoleName1 = value; }
        }
       
         private bool? CampaignCreate1;

        public bool? CampaignCreate
        {
            get { return CampaignCreate1; }
            set { CampaignCreate1 = value; }
        }

        private bool? ListExports1;

        public bool? ListExports
        {
            get { return ListExports1; }
            set { ListExports1 = value; }
        }

        private bool? MailSend1;

        public bool? MailSend
        {
            get { return MailSend1; }
            set { MailSend1 = value; }
        }
        private bool? CreateUser1;

        public bool? CreateUser
        {
            get { return CreateUser1; }
            set { CreateUser1 = value; }
        }
        private bool? CampaignDelete1;

        public bool? CampaignDelete
        {
            get { return CampaignDelete1; }
            set { CampaignDelete1 = value; }
        }
        private bool? ViewingReports1;

        public bool? ViewingReports
        {
            get { return ViewingReports1; }
            set { ViewingReports1 = value; }
        }
        private bool? TemplateView1;

        public bool? TemplateView
        {
            get { return TemplateView1; }
            set { TemplateView1 = value; }
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
