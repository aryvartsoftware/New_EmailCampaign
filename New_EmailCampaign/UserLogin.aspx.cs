using System;
using System.Collections.Generic;
using DataAccessLayer.App_Code;
using BALayer;
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

        Role objRole = new Role();
        BL_Role objBL_Role = new BL_Role();
        List<Role> lstRole = new List<Role>();

        UserPlan objUserPlan = new UserPlan();
        BL_UserPlan objBL_UserPlan = new BL_UserPlan();
        List<UserPlan> lstUserPlan = new List<UserPlan>();

        New_EmailCampaign.App_Code.CryptographicHashCode objCryptographicHashCode = new New_EmailCampaign.App_Code.CryptographicHashCode();
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
                HttpCookie myCookie = new HttpCookie("myCookie");
                bool IsRemember = chkRememberme.Checked;
                lstUserDetails = new List<UserDetails>();
                lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsforLogin(txtUsername.Value.ToString(), txtpassword.Value.ToString());

                if (lstUserDetails.Count > 0)
                {
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

                        Session["UserID"] = lstUserDetails[0].PK_UserID;
                        Session["Usertype"] = lstUserDetails[0].UserType;
                        Session["CompanyID"] = lstUserDetails[0].FK_CompanyID;                                               
                        
                        if (lstUserDetails[0].FirstName == "" && lstUserDetails[0].LastName == "")
                            Session["UserName"] = lstUserDetails[0].UserName;
                        else
                            Session["UserName"] = lstUserDetails[0].FirstName + " " + lstUserDetails[0].LastName;

                        if (Session["CompanyID"].ToString() != "")
                            Session["CompanyName"] = objBL_Common.IsValidUser("Company_Name", "EC_Company", "PK_CompanyID =" + Convert.ToInt32(Session["CompanyID"].ToString()) + "");
                        else
                            Session["CompanyName"] = "-";

                        if (Convert.ToInt64(Session["Usertype"].ToString()) == 10)
                        {
                            Response.Redirect("UserPlanTypeDetails.aspx", false);
                            return;
                        }

                        if (lstUserDetails[0].FK_RoleID != null)
                            Session["RoleID"] = lstUserDetails[0].FK_RoleID;

                        if (lstUserDetails[0].UserType == 1)
                        {
                            if (lstUserDetails[0].FK_RoleID == null)
                            {
                                objRole = new Role();
                                objRole.RoleName = "Admin";
                                objRole.CampaignCreate = true;
                                objRole.FK_CompanyID = Convert.ToInt32(Session["CompanyID"].ToString());
                                objRole.MailSend = true;
                                objRole.CreateUser = true;
                                objRole.CampaignDelete = true;
                                objRole.ViewingReports = true;
                                objRole.TemplateView = true;
                                objRole.ListExports = true;
                                objRole.CreatedOn = DateTime.Now;
                                objRole.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                                string pkcqid = objBL_Role.AccessInsertRole(objRole);

                                if (pkcqid != "")
                                {
                                    Session["RoleID"] = Convert.ToInt32(pkcqid);
                                    objBL_Common = new BL_Common();
                                    objBL_Common.AccessUpdateAllCampaign("EC_UserLogin", "FK_RoleID = '" + Convert.ToInt32(pkcqid) + "'", "PK_UserID =" + Convert.ToInt32(Session["UserID"].ToString()) + "");
                                    objBL_Common = null;


                                }
                            }
                        }
                        objBL_UserPlan = new BL_UserPlan();
                        lstUserPlan = new List<UserPlan>();
                        lstUserPlan = objBL_UserPlan.GetUserPlanBasedonCompanyID(Convert.ToInt32(Session["CompanyID"].ToString()));

                        if (lstUserPlan.Count <= 0)
                        {
                            InsertUserPlan(Convert.ToInt32(Session["UserID"].ToString()));
                            Response.Redirect("Dashboard.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("Dashboard.aspx", false);
                            DataTable dtplantype = new DataTable();
                            objBL_Common = new BL_Common();
                            dtplantype = objBL_Common.plantypedetails("*", "EC_PlanType", "PK_PlanID = " + Convert.ToInt32(lstUserPlan[0].FK_PlanID.ToString()) + " and IsActive = 1 order by plandate desc");

                            string[] UPtype = new string[3];
                            UPtype[0] = Convert.ToString(dtplantype.Rows[0]["IsSingleUser"]);
                            UPtype[1] = Convert.ToString(dtplantype.Rows[0]["NOC"]);
                            UPtype[2] = Convert.ToString(dtplantype.Rows[0]["AllowedMails"]);
                            Session["lstUserPlanType"] = UPtype;
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

            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("UserLogin.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }

        public void InsertUserPlan(int loginid)
        {
            DataTable dtplantype = new DataTable();
            objBL_Common = new BL_Common();
            try
            {
                dtplantype = objBL_Common.plantypedetails("top 1 *", "EC_PlanType", "LOWER(PlanName)='FREE' and IsActive = 1 order by plandate desc");

                if (dtplantype.Rows.Count > 0)
                {
                    objUserPlan = new UserPlan();
                    objBL_UserPlan = new BL_UserPlan();
                    objUserPlan.FK_UserID = loginid;
                    objUserPlan.FK_PlanID = Convert.ToInt32(dtplantype.Rows[0]["PK_PlanID"].ToString());
                    objUserPlan.ActiveFrom = DateTime.Now;
                    objUserPlan.ActiveTo = DateTime.Now.AddMonths(1);
                    objUserPlan.IsActive = true;
                    objUserPlan.CreatedBy = loginid;
                    objUserPlan.CreatedOn = DateTime.Now;
                    objBL_UserPlan.AccessInsertUserPlan(objUserPlan);
                    string[] UPtype = new string[3];
                    UPtype[0] = Convert.ToString(dtplantype.Rows[0]["IsSingleUser"]);
                    UPtype[1] = Convert.ToString(dtplantype.Rows[0]["NOC"]);
                    UPtype[2] = Convert.ToString(dtplantype.Rows[0]["AllowedMails"]);
                    Session["lstUserPlanType"] = UPtype;

                    objUserPlan = null;
                    objBL_UserPlan = null;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("FreeAccountSignUp.aspx:InsertUserPlan() - " + ex.Message);
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