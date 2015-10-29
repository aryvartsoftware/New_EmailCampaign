using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New_EmailCampaign
{
    public partial class Common_Menu : System.Web.UI.UserControl
    {
        //UserDetails objUserDetails = new UserDetails();
        //BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        //List<UserDetails> lstUserDetails = new List<UserDetails>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    //if (Session["UserName"].ToString() == "")
                    //{
                    //    lstUserDetails = new List<UserDetails>();
                    //    lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsList(Convert.ToInt32(Session["UserID"].ToString()));
                        
                    //    if (lstUserDetails.Count > 0)
                    //    {
                    //        Session["UserName"] = lstUserDetails[0].FirstName + " " + lstUserDetails[0].LastName;
                    //    }
                    //}

                    Literal1.Text = Session["UserName"].ToString() + "<b> [" + Session["CompanyName"].ToString() + "]</b>";
                }
            }
        }
    }
}