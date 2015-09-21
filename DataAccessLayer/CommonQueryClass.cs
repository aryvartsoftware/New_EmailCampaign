using DataAccessLayer.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class CommonQueryClass
    {
        string connection = "Data Source=ARYVARTDOTNET;Integrated Security=true;Initial Catalog=EmailCampaign;User ID=sa;Password=aryvart@2015";
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
            {
                UserType = "";
            }

            cn.Close();
            return UserType;
        }

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

            SqlCommand command = new SqlCommand
       ("spCampaign_AllActions", cn);
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

            //using (SqlCommand cmd = new SqlCommand("spCampaign_AllActions"))
            //{
            //    using (SqlDataAdapter sda = new SqlDataAdapter())
            //    {
            //        cmd.Connection = cn;
            //        cmd.Parameters.AddWithValue("@CKStatus", "c");
            //        cmd.Parameters.AddWithValue("@PK_CampaignID", PK_CampaignID);                    
            //        sda.SelectCommand = cmd;
            //        using (reportdt = new DataTable())
            //        {
            //             sda.Fill(reportdt);
            //        }
            //    }
            //}
            //SqlCommand cmd = new SqlCommand("spCampaign_AllActions", cn);
            //SqlDataAdapter dr = new SqlDataAdapter(); ;
            //cmd.Parameters.AddWithValue("@PK_CampaignID", PK_CampaignID);
            //cmd.Parameters.AddWithValue("@CKStatus", "c");
            //dr.SelectCommand = cmd;
            //dr.Fill(reportdt);
            cn.Close();
            return reportdt;
        }


        #endregion

        #region getlistuser_basedon_companyid
        public DataTable listuserbasedoncompanyid(int FK_CompanyID)
        {
            //string UserType = "";
            DataTable reportdt = new DataTable();
            SqlConnection cn = new SqlConnection(connection);
            cn.Open();

            SqlCommand command = new SqlCommand
       ("spUserLogin_AllActions", cn);
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
    }
}
