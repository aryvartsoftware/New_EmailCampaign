using System;

namespace DataAccessLayer.App_Code
{
    public class InviteUser
    {

        private int PK_Inviteid1;

        public int PK_Inviteid
        {
            get { return PK_Inviteid1; }
            set { PK_Inviteid1 = value; }
        }
        private string Emailid1;

        public string Emailid
        {
            get { return Emailid1; }
            set { Emailid1 = value; }
        }
        private DateTime? invitedate1;

        public DateTime? Invitedate
        {
            get { return invitedate1; }
            set { invitedate1 = value; }
        }
        private int FK_RoleID1;

        public int FK_RoleID
        {
            get { return FK_RoleID1; }
            set { FK_RoleID1 = value; }
        }
        private string Message1;

        public string Message
        {
            get { return Message1; }
            set { Message1 = value; }
        }
        private bool? mailsentstatus1;

        public bool? Mailsentstatus
        {
            get { return mailsentstatus1; }
            set { mailsentstatus1 = value; }
        }
        private bool? expired1;

        public bool? Expired
        {
            get { return expired1; }
            set { expired1 = value; }
        }

        private int FK_CompanyID1;

        public int FK_CompanyID
        {
            get { return FK_CompanyID1; }
            set { FK_CompanyID1 = value; }
        }
        private bool? ApproveStatus1;

        public bool? ApproveStatus
        {
            get { return ApproveStatus1; }
            set { ApproveStatus1 = value; }
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
