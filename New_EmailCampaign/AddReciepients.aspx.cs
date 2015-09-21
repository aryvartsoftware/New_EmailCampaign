using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailUserContacts
{
    public partial class AddReciepients : System.Web.UI.Page
    {
        UserContacts objUserContacts = new UserContacts();
        BL_UserContacts objBL_UserContacts = new BL_UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
               // New_EmailUserContacts.App_Code.GlobalFunction.StoreLog("AddReciepients.aspx:Page_Load() - " + ex.Message);
            }
        }

    
    }
}