using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    public class BL_ScheduleMailDetails
    {
        DL_ScheduleMailDetails objDL_ScheduleMailDetails = new DL_ScheduleMailDetails();
        ScheduleMailDetails  objScheduleMailDetails = new ScheduleMailDetails();
        List<ScheduleMailDetails> lstScheduleMailDetails = new List<ScheduleMailDetails>();

        public void AccessInsertScheduleMailDetails(ScheduleMailDetails objScheduleMailDetails1)
        {
            objDL_ScheduleMailDetails.ScheduleMailDetailsInsert(objScheduleMailDetails1);
        }

        public void AccessUpdateScheduleMailDetails(ScheduleMailDetails objScheduleMailDetails1)
        {
            objDL_ScheduleMailDetails.ScheduleMailDetailsUpdate(objScheduleMailDetails1);
        }

        public void AccessDeleteScheduleMailDetails(int ScheduleMailDetailsid)
        {
            objDL_ScheduleMailDetails.ScheduleMailDetailsDelete(ScheduleMailDetailsid);
        }

        public List<ScheduleMailDetails> SelectScheduleMailDetailsforcontactid(int sdid)
        {
            return objDL_ScheduleMailDetails.ScheduleMailDetailsSelectbasedonid(sdid);
        }

    }
}
