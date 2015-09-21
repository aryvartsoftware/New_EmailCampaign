using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;

namespace BALayer
{
    public class BL_ListContacts
    {
        DL_ListContacts objDL_ListContacts = new DL_ListContacts();
        ListContacts objListContacts1 = new ListContacts();
        List<ListContacts> lstListContacts = new List<ListContacts>();
        //public void AccessExcelDataStore()
        //{
        //    objDL_ListContacts.ListContactsExcelInsert();
        //}

        public void AccessInsertContacts(ListContacts objListContacts1)
        {
            objDL_ListContacts.ListContactsInsert(objListContacts1);
        }

        public void AccessUpdateContacts(ListContacts objListContacts1)
        {
            objDL_ListContacts.ListContactsUpdate(objListContacts1);
        }

        public void AccessDeleteContacts(int ListContactsid)
        {
            objDL_ListContacts.ListContactsDelete(ListContactsid);
        }

        public List<ListContacts> SelectListContactsListforgrid(int Companyid)
        {
            return objDL_ListContacts.ListContactsSelectforgrid(Companyid);
        }

        public List<ListContacts> SelectListContactsList(int PK_ContListID)
        {
            return objDL_ListContacts.ListContactsSelect(PK_ContListID);
        }

        public List<ListContacts> SelectListContactsforgrid()
        {
            return objDL_ListContacts.ListContactsgrid();
        }

    }
}
