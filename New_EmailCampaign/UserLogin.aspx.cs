using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using System.Security.Cryptography;
using BALayer;
using System.Web.UI;
using System.Web;
using System.Data;


namespace New_EmailCampaign
{
    public partial class UserLogin : System.Web.UI.Page
    {
        UserDetails objUserDetails = new UserDetails();
        BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();

        Userplantype objUserplantype = new Userplantype();
        BL_PlanType objBL_PlanType = new BL_PlanType();
        List<Userplantype> lstUserplantype = new List<Userplantype>();

        //(21-9-2015)

        New_EmailCampaign.App_Code.CryptographicHashCode objCryptographicHashCode = new New_EmailCampaign.App_Code.CryptographicHashCode();

        Role objRole = new Role();
        BL_Role objBL_Role = new BL_Role();
        List<Role> lstRole = new List<Role>();

        //Userplantype objUserplantype = new Userplantype();
        //BL_PlanType objBL_PlanType = new BL_PlanType();
        //List<Userplantype> lstUserplantype = new List<Userplantype>();

        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                {
                    txtUsername.Value = Request.Cookies["username"].Value;
                    txtpassword.Value = objCryptographicHashCode.DecryptCipherTextToPlainText(txtpassword.Value);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //bool IsAvailable = false;
                HttpCookie myCookie = new HttpCookie("myCookie");
                bool IsRemember = chkRememberme.Checked;
                


                lstUserDetails = new List<UserDetails>();
                lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsforLogin(txtUsername.Value.ToString(), txtpassword.Value.ToString());

                if (lstUserDetails.Count > 0)
                {
                    //Response.Redirect("SelectUser.aspx", false);
                    if (lstUserDetails[0].AccountActivated == true)
                    {
                        if (IsRemember)
                        {

                            myCookie.Values.Add("username", txtUsername.Value);
                            myCookie.Values.Add("password", objCryptographicHashCode.EncryptPlainTextToCipherText(txtpassword.Value));
                            myCookie.Expires = DateTime.Now.AddDays(15);
                            Response.Cookies.Add(myCookie);
                        }
                        else
                        {
                            myCookie.Values.Add("username", string.Empty);
                            myCookie.Values.Add("password", string.Empty);
                            myCookie.Expires = DateTime.Now.AddMinutes(5);
                            Response.Cookies.Add(myCookie);
                        }
                        Response.Redirect("CreateCampaignList.aspx", false);
                        Session["UserID"] = lstUserDetails[0].PK_UserID;
                        Session["Usertype"] = lstUserDetails[0].UserType;
                        Session["CompanyID"] = lstUserDetails[0].FK_CompanyID;
                        Session["RoleID"] = lstUserDetails[0].FK_RoleID;
                        Session["UserPlanID"] = lstUserDetails[0].FK_UserPlanID;

                        if (Session["UserPlanID"] != null)
                        {
                            objBL_Common = new BL_Common();
                            DataTable dtplantype = new DataTable();
                            dtplantype = objBL_Common.plantypedetails("*", "EC_PlanType", "PK_PlanID in (select FK_PlanID from dbo.EC_UserPlan where PK_UserPlanID =" + Convert.ToInt32(Session["UserPlanID"].ToString()) + ")");

                            if (dtplantype.Rows.Count > 0)
                            {
                                Session["allowedmails"] = dtplantype.Rows[0].Field<int>("AllowedMails").ToString();
                                Session["nos"] = dtplantype.Rows[0].Field<int>("NOC").ToString();
                            }
                        }
                        
                        if (lstUserDetails[0].Email_id != null)
                            Session["AdminEmilid"] = lstUserDetails[0].Email_id;

                        if (lstUserDetails[0].FK_RoleID != 0)
                            roledetails();
                        
                    }
                    else
                        lblerrormsg.Text = "<span style='color:#c85305;font-size:11.5px;'>You have to activate your account from mail sent. Then only you can access your account.</span>";
                }
                else
                    lblerrormsg.Text = "<span style='color:#c85305;font-size:11.5px;'>That account doesn't exist. Enter a different account detail or </span> <a href='FreeAccountSignUp.aspx' style='font-size:11.5px; color: #00acec;'>get a new account</a>";
                
                UserPlanSession();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserLogin.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
        public void UserPlanSession()
        {
            try
            {
                objUserplantype = new Userplantype();
                objBL_PlanType = new BL_PlanType();
                lstUserplantype = new List<Userplantype>();

                int PlanID = Convert.ToInt32(Request.QueryString["PlanID"].ToString());
                lstUserplantype = objBL_PlanType.SelectUserplantypeforcampid(PlanID);

                if (lstUserplantype.Count > 0)
                {
                    string[] UPtype = new string[3];
                    UPtype[0] = Convert.ToString(lstUserplantype[0].IsSingleUser);
                    UPtype[1] = Convert.ToString(lstUserplantype[0].NOC);
                    UPtype[2] = Convert.ToString(lstUserplantype[0].AllowedMails);
                    Session["lstUserplantype"] = UPtype;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserPlanSuccess.aspx:SessionSaving() - " + ex.Message);
            }
        }

        public void roledetails()
        {
            objRole = new Role();
            lstRole = new List<Role>();
            try
            {
                lstRole = objBL_Role.SelectRoleforcampid(Convert.ToInt32(Session["RoleID"].ToString()));
            if (lstRole.Count > 0)
            {

                //ddlrole.DataBind();
                foreach (var items in lstRole)
                {
                    if (items.MailSend == true)
                        Session["cmpsend"] = 1;

                    if (items.CreateUser == true)
                        Session["crtusr"] = 1;
                        
                    if (items.CampaignDelete == true)
                        Session["cmpdelete"] = 1;

                    if (items.ViewingReports == true)
                        Session["vewrpts"] = 1;

                    if (items.ListExports == true)
                        Session["lstexprts"] = 1;

                    if (items.CampaignCreate == true)
                        Session["cmpcrte"] = 1;

                    //if (items.TemplateView == true)
                    //    Chkusr.Checked = true;
                }
            }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserLogin.aspx:roledetails() - " + ex.Message);
            }
        }
    }
}