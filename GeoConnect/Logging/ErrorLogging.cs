using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GeoConnect.Logging
{
    public static class ErrorLogging
    {
        public static void LogError(string error, string userName, string ipAddress)
        {
            try
            {
                Dictionary<string, SqlParameter> cmdParams = new Dictionary<string, SqlParameter>();
                cmdParams["@p_ErrorDescription"] = new SqlParameter("@p_ErrorDescription", error);
                cmdParams["@p_UserName"]         = new SqlParameter("@p_UserName", userName);
                cmdParams["@p_IPAddtress"]       = new SqlParameter("@p_IPAddtress", ipAddress);
                DAL.ErrorUtility.DALExecuteCommand(Models.Constants.GeoConnectConstants.spNameAddUser, cmdParams);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}