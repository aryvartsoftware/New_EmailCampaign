using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace New_EmailCampaign.App_Code
{
    public static class GlobalFunction
    {
        public static void StoreLog(string strlogMessage)
        {
            string strLogMessageWithDate = string.Empty;
            string strAppPath = System.Configuration.ConfigurationManager.AppSettings["AryvartLogFilePath"].ToString();
            string strLogFile = strAppPath + "\\" + String.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".txt";
            //string strLogFile = System.Web.HttpContext.Current.Server.MapPath("ErrorLog/" + String.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".txt");
            //string strLogFile = @"https:///" + "\\" + String.Format("{0:dd-MM-yyyy}", DateTime.Now) + ".txt";    
            StreamWriter swStoreLog;

            strLogMessageWithDate = string.Format("{0}: {1}", DateTime.Now, strlogMessage);

            if (!File.Exists(strLogFile))
                swStoreLog = new StreamWriter(strLogFile);
            else
                swStoreLog = File.AppendText(strLogFile);

            swStoreLog.WriteLine(strLogMessageWithDate);
            swStoreLog.WriteLine();

            swStoreLog.Close();
        }
    }
}