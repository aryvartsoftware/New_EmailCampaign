using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    public class BL_Role
    {
        DL_Role objDL_Role = new DL_Role();
        Role objRole1 = new Role();
        List<Role> lstRole = new List<Role>();

        public void AccessInsertRole(Role objRole1)
        {
            objDL_Role.RoleInsert(objRole1);            
        }

        public void AccessUpdateRole(Role objRole1)
        {
            objDL_Role.RoleUpdate(objRole1);
        }

        public void AccessDeleteRole(int Roleid)
        {
            objDL_Role.RoleDelete(Roleid);
        }

        public List<Role> SelectRoleforcampid(int campid)
        {
            return objDL_Role.RoleSelect(campid);
        }

        public List<Role> SelectRoleall(int compid)
        {
            return objDL_Role.RoleSelectall(compid);
        }
        public List<Role> SelectRolealldropdownselection(int PK_RoleID, int compid)
        {
            return objDL_Role.RoleSelectBasedondropdownselection(PK_RoleID, compid);
        }
    }
}
