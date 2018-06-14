using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace GeoConnect.DAL
{
    public static class SqlUtility
    {
        public static string getSQLConnetionString()
        {
            string connString = string.Empty;
            connString = "Data Source = Manikanta; Initial Catalog = GeoConnect; Integrated Security = True";
            return connString;
        }

        public static SqlConnection GetConnection()
        {
            string cnstr = getSQLConnetionString();
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }

        public static string DALExecuteCommand(string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            string execcomm = string.Empty;
            int rc;
            using (SqlConnection cn = GetConnection())
            {
                // create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    // assign parameters passed in to the command
                    foreach (var procParameter in procParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }

                    rc = cmd.ExecuteNonQuery();
                    execcomm = rc.ToString();
                }
            }
            return execcomm;
        }

        public static DataSet DALExecuteQuery(string storedProcName, Dictionary<string, SqlParameter> procParameters)
        {
            DataSet ds = new DataSet();
            using (SqlConnection cn = GetConnection())
            {
                // create a SQL command to execute the stored procedure
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcName;
                    // assign parameters passed in to the command
                    foreach (var procParameter in procParameters)
                    {
                        cmd.Parameters.Add(procParameter.Value);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }

                return ds;
            }

        }

    }
}