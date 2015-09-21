using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DataAccessLayer.App_Code;
using BALayer;
using System.Web;

namespace New_EmailCampaign
{
    public partial class InvitieUser : System.Web.UI.Page
    {
        Role objRole = new Role();
        BL_Role objBL_Role = new BL_Role();
        List<Role> lstRole = new List<Role>();

        InviteUser objInviteUser = new InviteUser();
        BL_InviteUser objBL_InviteUser = new BL_InviteUser();
        List<InviteUser> lstInviteUser = new List<InviteUser>();

        Company objCompany = new Company();
        BL_CompanyDetails objBL_CompanyDetails = new BL_CompanyDetails();
        List<Company> lstCompany = new List<Company>();

        UserDetails objUserDetails = new UserDetails();
        BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();

        MailTemplate objMailTemplate = new MailTemplate();
        New_EmailCampaign.App_Code.CryptographicHashCode objCryptographicHashCode = new New_EmailCampaign.App_Code.CryptographicHashCode();

        BL_Common objBL_Common = new BL_Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                { 
                    BindRole();
                    if (Request.QueryString["CampInvtusrId"] != null)
                        RetrieveInviteUser();
                       
                }
            }
        }

        #region Retrieve_Records_Based_on_InviteUserid
        public void RetrieveInviteUser()
        {
            try
            {
                objUserDetails = new UserDetails();
                objBL_UserLoginDetails = new BL_UserLoginDetails();
                lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsList(Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["CampInvtusrId"]).ToString()));

                if (lstUserDetails.Count > 0)
                {
                    //txta1.Value = lstUserDetails[0].Message;
                    Text1.Value = lstUserDetails[0].Email_id;
                    ddlrole.SelectedValue = Convert.ToString(lstUserDetails[0].FK_RoleID);
                }
                lstUserDetails = null;
                objBL_UserLoginDetails = null;
                objUserDetails = null;
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("InvitieUser.aspx:RetrieveInviteUser() - " + ex.Message);
            }
        }

        #endregion

        #region Bind_ddlrole
        public void BindRole()
        {
            try
            {
                objRole = new Role();
                lstRole = new List<Role>();
                lstRole = objBL_Role.SelectRoleall(Convert.ToInt32(Session["CompanyID"].ToString()));

                if (lstRole.Count > 0)
                {

                    //ddlrole.DataBind();
                    foreach (var items in lstRole)
                    {
                        ddlrole.DataValueField = "PK_RoleID";
                        ddlrole.DataTextField = "RoleName";
                    }
                    ddlrole.DataSource = lstRole;
                    ddlrole.DataBind();
                }
                ddlrole.Items.Insert(0, "-- Select --");
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("InvitieUser.aspx:BindRole() - " + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 25-6-2015
        /// Comments :: Inserting all values of InviteUser form.
        /// </summary>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objInviteUser = new InviteUser();
                lstInviteUser = new List<InviteUser>();
                
                objInviteUser.FK_RoleID = Convert.ToInt32(ddlrole.SelectedValue);
                

                if (Request.QueryString["CampInvtusrId"] != null)
                {
                    objUserDetails = new UserDetails();
                    lstUserDetails = new List<UserDetails>();
                    objBL_UserLoginDetails = new BL_UserLoginDetails();
                    lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsList(Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["CampInvtusrId"]).ToString()));

                    if (lstUserDetails.Count > 0)
                    {
                        if (ddlrole.SelectedValue != "0")
                            objBL_Common.AccessUpdateAllCampaign("EC_UserLogin", "FK_RoleID= " + Convert.ToInt32(ddlrole.SelectedValue) + ", UpdatedBy = " + Convert.ToInt32(Session["UserID"].ToString()) + ", UpdatedOn = '" + DateTime.Now + "' ", "PK_UserID =" + Convert.ToInt32(HttpUtility.UrlDecode(Request.QueryString["CampInvtusrId"]).ToString()) + "");                       
                    }
                    lstUserDetails = null;
                    objUserDetails = null;
                    objBL_UserLoginDetails = null;
                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "Clearuserinput2();", true);
                }
                else
                {
                    int status = objBL_UserLoginDetails.AccessVerifyUserEmailidExist(EmailID.Value.ToString().Trim());

                    if (status == 0)
                    {
                        objInviteUser.Emailid = EmailID.Value;
                        objInviteUser.Invitedate = DateTime.Now;
                        objInviteUser.Message = txtmessage.Value;
                        objInviteUser.FK_CompanyID = Convert.ToInt32(Session["CompanyID"].ToString());
                        objInviteUser.CreatedOn = DateTime.Now;
                        objInviteUser.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                        string pkcqid = objBL_InviteUser.AccessInsertInviteUser(objInviteUser);

                        //------Sending confirmtion Email of account created to client.-----
                        string sEmailId = "sakthivel@aryvart.com";
                        //subject
                        string sSubject = "Join my Email Campaign account";

                        ////sending emails to client
                        string strReceiverName = "ADMIN";
                        string EncryptQry = "signid=" + objCryptographicHashCode.EncryptPlainTextToCipherText(pkcqid) + "'";
                        lstCompany = objBL_CompanyDetails.SelectCompanyListbasedonid(Convert.ToInt32(Session["CompanyID"].ToString()));
                        string companyname = "";
                        string emailid = "";

                        if (lstCompany.Count > 0)
                        {
                            if (lstCompany[0].Company_Name != null)
                                companyname = lstCompany[0].Company_Name;
                        }

                        if (Session["AdminEmilid"] != null)
                            emailid = Session["AdminEmilid"].ToString();

                        string body = MailTemplate.MailInviteUser(companyname, emailid, EncryptQry);
                        objMailTemplate.fnSendMailToClientForCoUpld(body, sEmailId, sSubject, EmailID.Value.ToString().Trim());
                        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "Clearuserinput1();", true);
                    }
                    else if (status == 1)
                    {
                        lblerrormsg.Text = "<span style='color:#c85305;font-size:12px;'>Emailid already exist use some other emailid.</span>";
                    }
                    //---------End---------------------
                }

                
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("InvitieUser.aspx:btnSubmit_Click() - " + ex.Message);
            }
        }
    }
}