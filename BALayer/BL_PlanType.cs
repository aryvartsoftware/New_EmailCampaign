using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    public class BL_PlanType
    {
        DL_PlanType objDL_PlanType = new DL_PlanType();
        Userplantype objUserplantype1 = new Userplantype();
        List<Userplantype> lstUserplantype = new List<Userplantype>();

        public void AccessInsertUserplantype(Userplantype objUserplantype1)
        {
            objDL_PlanType.UserplantypeInsert(objUserplantype1);
        }

        public void AccessUpdateUserplantype(Userplantype objUserplantype1)
        {
            objDL_PlanType.UserplantypeUpdate(objUserplantype1);
        }

        public void AccessDeleteUserplantype(int Userplantypeid)
        {
            objDL_PlanType.UserplantypeDelete(Userplantypeid);
        }

        public List<Userplantype> SelectUserplantypeforcampid(int campid)
        {
            return objDL_PlanType.UserplantypeSelect(campid);
        }

        public List<Userplantype> SelectAllUserplantype()
        {
            return objDL_PlanType.UserplantypeSelectall();
        }

        public List<Userplantype> SelectAllUserplantypebasedonisactive()
        {
                return objDL_PlanType.UserplantypeSelectallbasedonisactive();
        }
    }
}
