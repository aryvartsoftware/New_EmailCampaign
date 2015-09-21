using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DataAccessLayer.App_Code;
using BALayer;

namespace New_EmailCampaign
{
    //disable UAC indexer Control panel for executing link server in MS.
    //Control Panel -> User Accounts -> Change User Account Control Settings - "Move the slider to 'Never notify"
    public partial class ImportReciepientsList : System.Web.UI.Page
    {
        UserContacts objUserContacts = new UserContacts();
        BL_UserContacts objBL_UserContacts = new BL_UserContacts();
        List<UserContacts> lstUserContacts = new List<UserContacts>();
        
        //EmailCampDataContext  objEmailCampDataContext = new EmailCampDataContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["Listid"] = 1;
                   
                    //var query = (from p in objEmailCampDataContext.spExcelRead("").Cast<spex>() select p).Single();

                    //int lastUserLogin = 0;
                }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ImportReciepientsList.aspx:Page_Load() - " + ex.Message);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
            if (FileUpload1.HasFile)
            {
                bool uplod = true;
                string fleUpload = Path.GetExtension(FileUpload1.FileName.ToString());

                if (fleUpload.Trim().ToLower() == ".xls" | fleUpload.Trim().ToLower() == ".xlsx")
                {
                    // Save excel file into Server sub dir
                    // to catch excel file downloading permission
                    FileUpload1.SaveAs(Server.MapPath("~/FileUploadExcel/" +
                        FileUpload1.FileName.ToString()));
                    string uploadedFile = (Server.MapPath("~/FileUploadExcel/" +
                        FileUpload1.FileName.ToString()));
                    ReadDataFromExcelToDB();
                }
                //if (uplod)
                //{
                //    string mess1 = "File has successfully uploaded";                    
                //}
            }
            else
            {
                //this.lblMessage.Text = "Please select file to upload.";
            }
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ImportReciepientsList.aspx:btnUpload_Click() - " + ex.Message);
            }

        }

        public string Mapcolumn()
        {           
                string concatquery = string.Empty;
              
                    if (DD1.SelectedIndex != 0)
                        concatquery = DD1.Value.ToString();
                    if (DD2.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD2.Value.ToString();
                        else
                        concatquery = DD2.Value.ToString();
                    }
                    if (DD3.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD3.Value.ToString();
                        else
                        concatquery = DD3.Value.ToString();
                    }
                    if (DD4.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD4.Value.ToString();
                        else
                        concatquery = DD4.Value.ToString();
                    }
                    if (DD5.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD5.Value.ToString();
                        else
                        concatquery = DD5.Value.ToString();
                    }
                    if (DD6.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD6.Value.ToString();
                        else
                        concatquery = DD6.Value.ToString();
                    }
                    if (DD7.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD7.Value.ToString();
                        else
                        concatquery = DD7.Value.ToString();
                    }
                    if (DD8.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD8.Value.ToString();
                        else
                        concatquery = DD8.Value.ToString();
                    }
                    if (DD9.SelectedIndex != 0)
                    {
                        if (concatquery != "")
                            concatquery = concatquery + "," + DD9.Value.ToString();
                        else
                        concatquery = DD9.Value.ToString();
                    }
               
                return concatquery;
            

        }

        public void ReadDataFromExcelToDB()
        {
            string cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
            try
            {
        SqlDataAdapter da = new SqlDataAdapter();
                con.Open();
                string path = Server.MapPath("~/FileUploadExcel/" + FileUpload1.FileName.ToString());
                string excelread = string.Empty;
                excelread = "INSERT INTO [dbo].[EC_UserContacts] (" + Mapcolumn() + ", FK_UserID, CreatedBy, CreatedOn) SELECT *, " + Convert.ToInt32(Session["UserID"].ToString()) + " as FK_UserID, " + Convert.ToInt32(Session["UserID"].ToString()) + " as CreatedBy, '" + DateTime.Today + "' as CreatedOn FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'Excel 8.0; Database=" + path + "', 'SELECT * FROM [Sheet1$]');";
                //excelread = "INSERT INTO [dbo].[EC_UserContacts] ([ContactName], [email_id], [ContactNo], [Designation], Addressline1, City1, State1, Country1, DateofBirth, CreatedBy, CreatedOn) SELECT *, " + Convert.ToInt32(Session["UserID"].ToString()) + " as FK_UserID, " + Convert.ToInt32(Session["UserID"].ToString()) + " as CreatedBy, '" + DateTime.Today + "' as CreatedOn FROM OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'Excel 8.0; Database=" + path + "', 'SELECT * FROM [Sheet1$]');";

                da.SelectCommand = new SqlCommand(excelread, con);
                //da.SelectCommand = new SqlCommand("select * from Addresses_Temp1",con);
                DataTable dt = new DataTable();
                //dt.Columns.Add("S No", typeof(int));
                //dt.Columns.Add("Name", typeof(string));
                //dt.Columns.Add("Email", typeof(string));
                da.Fill(dt);
                con.Close();
                
                if(File.Exists(path))
                    File.Delete(path);

                excelread = string.Empty;
                //dg.DataSource = dt;

                objBL_UserContacts.DeleteDuplicateMailid(Convert.ToInt32(Session["Listid"].ToString()), Convert.ToInt32(Session["UserID"].ToString()));
                Label1.Text = "Your contacts are now successfully imported.";
                Label1.CssClass = "alert alert-success";
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("The select list for the INSERT statement contains more items than the insert list"))
                {
                    Label1.Text = "The select list for the INSERT statement contains more items than the insert list.";
                    Label1.CssClass = "alert alert-danger";
                }
                else if (ex.ToString().Contains("Cannot insert the value NULL into column 'email_id'"))
                {
                    Label1.Text = "No data found for emailid. It is a mandatory one.";
                    Label1.CssClass = "alert alert-danger";
                }
                
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ImportReciepientsList.aspx:ReadDataFromExcelToDB() - " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                ////string filePath = gvDetails.DataKeys[gvrow.RowIndex].Value.ToString();
                ////string FileName = filePath.Replace("Document/", "");
                //Response.ContentType = "application/octet-stream";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"ExcelTemplate\"");
                //string hh = Server.MapPath("~/ExcelEmptyTemplate/ExcelTemplate.xlt");
                //Response.TransmitFile(Server.MapPath("~/ExcelEmptyTemplate/ExcelTemplate.xlt"));
                ////filePath = null;
                ////FileName = null;
                //Response.Flush();
                //Response.Clear();
                //Response.End();

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=ExcelTemplate");
                Response.TransmitFile(Server.MapPath("~/ExcelEmptyTemplate/ExcelTemplate.xlsx"));
                Response.Flush();
                Response.Clear();
                Response.End();
            }
            catch (Exception ex)
            {
                New_EmailCampaign.App_Code.GlobalFunction.StoreLog("ImportReciepientsList.aspx:ReadDataFromExcelToDB() - " + ex.Message);
            }
            finally
            {
               
            }
        }     
      
    }
}