using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class CommonQueryClass
    {
        //string connection = "Data Source=ARYVARTDOTNET;Integrated Security=true;Initial Catalog=EmailCampaign;User ID=sa;Password=aryvart@2015";
        string connection = Properties.Settings.Default.EmailCampaignConnectionString;
        List<long> donutchartvalues = new List<long>();
        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 16-5-2015
        /// Comments :: Delete function of Campaign details.
        /// </summary>
        #region Delete_CampaignCreation
        public void Deleteall(string tblName, string Column, string Campaignid)
        {

            try
            {
                SqlConnection sqlConn = new SqlConnection(connection);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                sqlComm.CommandText = @"DELETE FROM " + tblName + " WHERE " + Column + " in (" + Campaignid + ")";
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 16-5-2015
        /// Comments :: UpdateAll function of Campaign details.
        /// </summary>
        #region UpdateAll_CampaignCreation
        public void Updateall(string tblName, string Column, string wherecondition)
        {

            try
            {
                SqlConnection sqlConn = new SqlConnection(connection);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                //sqlComm.Parameters.AddWithValue("@UserName", UserName);
                sqlComm.CommandText = @"update " + tblName + " set " + Column + " WHERE " + wherecondition + "";

                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Created By :: Sakthivel.R
        /// Created On :: 13-6-2015
        /// Comments :: UpdateCampqueall function of Campaign details.
        /// </summary>
        #region UpdateCampqueall
        public void UpdateCampqueall(string tblName, string Column, string wherecondition, string content)
        {

            try
            {
                SqlConnection sqlConn = new SqlConnection(connection);
                SqlCommand sqlComm = new SqlCommand();
                sqlComm = sqlConn.CreateCommand();
                //sqlComm.Parameters.AddWithValue("@UserName", UserName);
                sqlComm.CommandText = @"update " + tblName + " set " + Column + " WHERE " + wherecondition + "";

                if (Column.Contains("@UserName"))
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@UserName ";
                    param.Value = content;
                    sqlComm.Parameters.Add(param);
                }
                sqlConn.Open();
                sqlComm.ExecuteNonQuery();
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        #endregion
        public string IsValidUser(string Column, string tblName, string wherecondition)
        {
            string UserType = "";
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select " + Column + " from " + tblName + " WHERE " + wherecondition + "", cn);
            //SqlCommand cmd = new SqlCommand("DECLARE @newcount int SELECT @newcount  = count(dbo.EC_CampaignQueue.PK_CampaignQueueID) FROM dbo.EC_Campaign INNER JOIN dbo.EC_CampaignQueue ON dbo.EC_Campaign.PK_CampaignID = dbo.EC_CampaignQueue.FK_CampaignID INNER JOIN dbo.EC_UserLogin ON dbo.EC_Campaign.FK_UserID = dbo.EC_UserLogin.PK_UserID INNER JOIN dbo.EC_UserPlan ON dbo.EC_UserLogin.PK_UserID = dbo.EC_UserPlan.FK_UserID where dbo.EC_UserLogin.FK_CompanyID = 45 and dbo.EC_CampaignQueue.CreatedOn between '2015-09-28' and '2015-10-28' print @newcount", cn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    UserType = dr[Column].ToString();
                }
            }
            else
                UserType = "";

            cn.Close();
            return UserType;
        }
        #region select_Dynamic_Query_for select alone
        public DataTable listselectqueryColumn(string Column)
        {
            DataTable reportdt = new DataTable();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand command = new SqlCommand("select " + Column + "", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(reportdt);

            cn.Close();
            return reportdt;
        }
        #endregion
        #region select_Dynamic_Query

        public DataTable listselectquery(string Column, string tblName, string wherecondition)
        {
            DataTable reportdt = new DataTable();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand command = new SqlCommand("select " + Column + " from " + tblName + " WHERE " + wherecondition + "", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(reportdt);

            cn.Close();
            return reportdt;
        }

        #endregion

        #region getcampaignreportsdata
        public DataTable campaignreportdata(int PK_CampaignID)
        {
            //string UserType = "";
            DataTable reportdt = new DataTable();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            SqlCommand command = new SqlCommand("spCampaign_AllActions", cn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@CKStatus";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = "c";

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@PK_CampaignID";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = PK_CampaignID;
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(reportdt);
            cn.Close();
            return reportdt;
        }


        #endregion

        #region getlistuser_basedon_companyid
        public DataTable listuserbasedoncompanyid(int FK_CompanyID)
        {
            DataTable reportdt = new DataTable();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand command = new SqlCommand("spUserLogin_AllActions", cn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@CKStatus";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = "v";

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@FK_CompanyID";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = FK_CompanyID;
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(reportdt);

            cn.Close();
            return reportdt;
        }
        #endregion
        
        public List<long> DashboardChart(int companyid)
        {
            donutchartvalues = new List<long>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("spDashboard", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", companyid);//int.Parse("45")
                    cmd.Parameters.Add("@TotalCampaign", SqlDbType.BigInt);
                    cmd.Parameters["@TotalCampaign"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@SentCampaign", SqlDbType.BigInt);
                    cmd.Parameters["@SentCampaign"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@PendingCampaign", SqlDbType.BigInt);
                    cmd.Parameters["@PendingCampaign"].Direction = ParameterDirection.Output;                  
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    donutchartvalues.Add(Convert.ToInt64(cmd.Parameters["@TotalCampaign"].Value.ToString()));
                    donutchartvalues.Add(Convert.ToInt64(cmd.Parameters["@SentCampaign"].Value.ToString()));
                    donutchartvalues.Add(Convert.ToInt64(cmd.Parameters["@PendingCampaign"].Value.ToString()));
                }
            }
            return donutchartvalues;
        }

        public DataTable listDashboardBarchart(int FK_CompanyID)
        {
            DataTable reportdt = new DataTable();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();
            SqlCommand command = new SqlCommand("spDashboardChart", cn);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter();
            parameter1.ParameterName = "@CKStatus";
            parameter1.SqlDbType = SqlDbType.NVarChar;
            parameter1.Direction = ParameterDirection.Input;
            parameter1.Value = "a";

            SqlParameter parameter2 = new SqlParameter();
            parameter2.ParameterName = "@CompanyID";
            parameter2.SqlDbType = SqlDbType.NVarChar;
            parameter2.Direction = ParameterDirection.Input;
            parameter2.Value = FK_CompanyID;
            command.Parameters.Add(parameter1);
            command.Parameters.Add(parameter2);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(reportdt);

            cn.Close();
            return reportdt;
        }

    }
}
