using System.Collections.Generic;
using DataAccessLayer;
using DataAccessLayer.App_Code;


namespace BALayer
{
    /// <summary>
    /// Created By :: Sakthivel.R
    /// Created On :: 15-4-2015
    /// Comments :: This Business Logic Layer is for User Contacts details.
    /// </summary>
    public class BL_UserContacts
    {
        DL_UserContaxcts objDL_UserContaxcts = new DL_UserContaxcts();
        UserContacts objUserContacts1 = new UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();
        //public void AccessExcelDataStore()
        //{
        //    objDL_UserContaxcts.UserContactsExcelInsert();
        //}

        public void AccessInsertContacts(UserContacts objUserContacts1)
        {
            objDL_UserContaxcts.UserContactsInsert(objUserContacts1);
        }

        public void AccessUpdateContacts(UserContacts objUserContacts1)
        {
            objDL_UserContaxcts.UserContactsUpdate(objUserContacts1);
        }

        public void AccessDeleteContacts(int UserContactsid)
        {
            objDL_UserContaxcts.UserContactsDelete(UserContactsid);
        }

        public List<UserContacts> SelectUserContactsListforgrid(int contlistid)
        {
            return objDL_UserContaxcts.UserContactsSelectforgrid(contlistid);
        }

        public List<UserContacts> SelectUserContactsListforid(int FKid)
        {
            return objDL_UserContaxcts.SelectUserContactsbasedonID(FKid);
        }

        public void DeleteDuplicateMailid(int Contactlistid, int CreatedBy)
        {
            objDL_UserContaxcts.DeleteDuplicateEmailidUploading(Contactlistid, CreatedBy);
        }

        public List<UserContacts> SelectContactsonSelectedID(int FKid, string PKContid)
        {
            return objDL_UserContaxcts.SelectUserContactsbasedonSelectedID(FKid, PKContid);
        }

    }
}
