using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    public class BL_InviteUser
    {
        DL_InviteUser objDL_InviteUser = new DL_InviteUser();
        InviteUser objInviteUser1 = new InviteUser();
        List<InviteUser> lstInviteUser = new List<InviteUser>();

        public string AccessInsertInviteUser(InviteUser objInviteUser1)
        {
            string pkid = objDL_InviteUser.InviteUserInsert(objInviteUser1);
            return pkid;
        }

        public void AccessUpdateInviteUser(InviteUser objInviteUser1)
        {
            objDL_InviteUser.InviteUserUpdate(objInviteUser1);
        }

        public void AccessDeleteInviteUser(int InviteUserid)
        {
            objDL_InviteUser.InviteUserDelete(InviteUserid);
        }

        public List<InviteUser> SelectInviteUserforcampid(int campid)
        {
            return objDL_InviteUser.InviteUserSelect(campid);
        }

        public List<InviteUser> CheckDateInviteuser(int compid)
        {
            return objDL_InviteUser.CheckDateInviteuser(compid);
        }
        public List<InviteUser> checkexpired(int compid)
        {
            return objDL_InviteUser.checkexpired(compid);
        }        
    }
}
