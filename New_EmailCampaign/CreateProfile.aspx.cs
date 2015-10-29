using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DataAccessLayer.App_Code;
using BALayer;
using System.Globalization;

namespace New_EmailCampaign
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        UserDetails objUserDetails = new UserDetails();
        BL_UserLoginDetails objBL_UserLoginDetails = new BL_UserLoginDetails();
        List<UserDetails> lstUserDetails = new List<UserDetails>();

        Role objRole = new Role();
        BL_Role objBL_Role = new BL_Role();
        List<Role> lstRole = new List<Role>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("UserLogin.aspx");
                else
                {
                    BindRole();
                    BindUserDetail();
                }
            }
        }

        #region Bind_ddlrole
        public void BindRole()
        {
            try
            {
                objRole = new Role();
                objBL_UserLoginDetails = new BL_UserLoginDetails();
                lstRole = new List<Role>();
                lstRole = objBL_Role.SelectRoleall(Convert.ToInt32(Session["CompanyID"].ToString()));

                if (lstRole.Count > 0)
                {
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
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateProfile.aspx:BindRole() - " + ex.Message);
            }
        }
        #endregion

        #region Binding User Details informatiom
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 28-3-2015
        /// Comments :: Populating all campaign creation list in the grid.
        /// </summary>
        public void BindUserDetail()
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    objUserDetails = new UserDetails();
                    objBL_UserLoginDetails = new BL_UserLoginDetails();
                    lstUserDetails = new List<UserDetails>();
                    lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsList(Convert.ToInt32(Session["UserID"].ToString()));

                    if (lstUserDetails.Count > 0)
                    {
                        txtLastName.Value = lstUserDetails[0].LastName;
                        txtFirstName.Value = lstUserDetails[0].FirstName;
                        txtUserName.Value = lstUserDetails[0].UserName;
                        txtAddress.Value = lstUserDetails[0].Addressline1;
                        txtCity.Value = lstUserDetails[0].City1;
                        txtState.Value = lstUserDetails[0].State1;
                        txtCountry.Value = lstUserDetails[0].Country1;
                        txtDesignation.Value = lstUserDetails[0].Designation;

                        if (lstUserDetails[0].FK_RoleID != null)
                            ddlrole.SelectedValue = Convert.ToString(lstUserDetails[0].FK_RoleID);

                        if (lstUserDetails[0].DateOfBirth != null)
                            dtScheduledatetime.Value = (Convert.ToDateTime(lstUserDetails[0].DateOfBirth)).ToString("dd/MM/yyyy");

                        txtEmail.Value = lstUserDetails[0].Email_id;
                        txtContactNumber.Value = lstUserDetails[0].ContactNo;
                        txtAlternativeNumber.Value = lstUserDetails[0].AlternativeNo;

                        if (lstUserDetails[0].UserPhoto != null)
                        {
                            Image1.Attributes["src"] = ResolveUrl("~/UserImage/" + lstUserDetails[0].UserPhoto);
                        }

                        objUserDetails = null;
                        objBL_UserLoginDetails = null;
                        lstUserDetails = null;
                    }
                    objUserDetails = null;
                    objBL_UserLoginDetails = null;
                    lstUserDetails = null;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateProfile.aspx:BindUserDetail() - " + ex.Message);
            }
        }

        #endregion

        public void ProfilePhotoUpload(string photoname)
        {
            try
            {
                if (!Directory.Exists(MapPath(@"UserImage")))
                    Directory.CreateDirectory(MapPath(@"UserImage"));
                string directory = Server.MapPath(@"UserImage\");
                Bitmap originalBMP = new Bitmap(FileUpload1.PostedFile.InputStream);
                Bitmap newBMP = new Bitmap(originalBMP);
                newBMP.Save(directory + photoname);
                originalBMP.Dispose();
                newBMP.Dispose();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateProfile.aspx:ProfilePhotoUpload() - " + ex.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                objUserDetails = new UserDetails();
                objBL_UserLoginDetails = new BL_UserLoginDetails();
                lstUserDetails = new List<UserDetails>();
                lstUserDetails = objBL_UserLoginDetails.SelectUserDetailsList(Convert.ToInt32(Session["UserID"].ToString()));

                if (lstUserDetails.Count > 0)
                {
                    objUserDetails.PK_UserID = lstUserDetails[0].PK_UserID;
                    objUserDetails.FK_CompanyID = lstUserDetails[0].FK_CompanyID;
                    objUserDetails.LastName = txtLastName.Value;
                    objUserDetails.FirstName = txtFirstName.Value;
                    objUserDetails.UserName = txtUserName.Value;
                    objUserDetails.UserType = lstUserDetails[0].UserType;
                    objUserDetails.Addressline1 = txtAddress.Value;
                    objUserDetails.City1 = txtCity.Value;
                    objUserDetails.State1 = txtState.Value;
                    objUserDetails.Country1 = txtCountry.Value;
                    objUserDetails.Designation = txtDesignation.Value;

                    if (ddlrole.SelectedValue != "0")
                        objUserDetails.FK_RoleID = Convert.ToInt32(ddlrole.SelectedValue.ToString());

                    if (dtScheduledatetime.Value != string.Empty)
                        objUserDetails.DateOfBirth = DateTime.ParseExact(dtScheduledatetime.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //Convert.ToDateTime(dtScheduledatetime.Value);

                    objUserDetails.Email_id = txtEmail.Value;
                    objUserDetails.ContactNo = txtContactNumber.Value;
                    objUserDetails.AlternativeNo = txtAlternativeNumber.Value;
                    objUserDetails.MemberSince = lstUserDetails[0].MemberSince;
                    objUserDetails.MemberTill = lstUserDetails[0].MemberTill;
                    objUserDetails.IsActive = lstUserDetails[0].IsActive;
                    objUserDetails.CreatedBy = lstUserDetails[0].CreatedBy;
                    objUserDetails.CreatedOn = lstUserDetails[0].CreatedOn;
                    objUserDetails.UpdatedBy = Convert.ToInt16(Session["UserID"].ToString());
                    objUserDetails.UpdatedOn = DateTime.Now;
                    objUserDetails.ReportID = lstUserDetails[0].ReportID;
                    objUserDetails.TotalMailCount = lstUserDetails[0].TotalMailCount;
                    objUserDetails.TotalContactsCount = lstUserDetails[0].TotalContactsCount;
                    objUserDetails.FK_UserPlanID = lstUserDetails[0].FK_UserPlanID;
                    objUserDetails.UserPassword = lstUserDetails[0].UserPassword;

                    int status = objBL_UserLoginDetails.AccessVerifyUserFileNameExist(FileUpload1.PostedFile.FileName.ToString().Trim());
                    string ChangedFileName = string.Empty;

                    if (status == 0)
                    {
                        if (FileUpload1.Value == string.Empty)
                            objUserDetails.UserPhoto = lstUserDetails[0].UserPhoto;
                        else
                        {
                            ChangedFileName = FileUpload1.Value;
                            objUserDetails.UserPhoto = ChangedFileName;
                            ProfilePhotoUpload(ChangedFileName);
                        }
                    }
                    else
                    {
                        if (FileUpload1.Value == string.Empty)
                            objUserDetails.UserPhoto = lstUserDetails[0].UserPhoto;
                        else
                        {
                            ChangedFileName = Path.GetFileNameWithoutExtension(FileUpload1.Value) + "1" + Path.GetExtension(FileUpload1.Value);
                            objUserDetails.UserPhoto = ChangedFileName;
                            ProfilePhotoUpload(ChangedFileName);
                        }
                    }

                    objUserDetails.AccountActivated = true;
                    objUserDetails.SendNewsLetter = lstUserDetails[0].SendNewsLetter;

                    objBL_UserLoginDetails.AccessUpdateUserLogin(objUserDetails);
                    Session["UserName"] = txtFirstName.Value.Trim() + " " + txtLastName.Value.Trim();
                    objUserDetails = null;
                    objBL_UserLoginDetails = null;
                    lstUserDetails = null;

                    ClientScript.RegisterStartupScript(Page.GetType(), "mykey1", "alert('User profile information submitted successfully.');", true);
                }


                //string[] files = System.IO.Directory.GetFiles(MapPath(@"UserImage")).Equals(green);
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("CreateProfile.aspx:btnSubmit_Click() - " + ex.Message);
            }

        }
    }
}