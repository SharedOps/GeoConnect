using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using GeoConnect.Models.GeoConnect;
using System.Text;

namespace GeoConnect.Controllers.GeoConnect
{
    public class UserRegistrationController : ApiController
    {

        [HttpPost]
        public void AddUser(User newuser)
        {
            try
            {
                string spName = Models.Constants.GeoConnectConstants.spNameAddUser;
                Dictionary<string, SqlParameter> cmdParams = new Dictionary<string, SqlParameter>();
                cmdParams["@p_Name"]      = new SqlParameter("@p_Name", newuser.Name);
                cmdParams["@p_Mobile_no"] = new SqlParameter("@p_Mobile_no", newuser.Mobile_no);
                cmdParams["@p_Email"]     = new SqlParameter("@p_Email", newuser.Email);
                cmdParams["@p_Location"]  = new SqlParameter("@p_Location", newuser.Location);
                cmdParams["@p_Avatar"]    = new SqlParameter("@p_Name", newuser.Avatar);
                DAL.SqlUtility.DALExecuteCommand(spName, cmdParams);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpGet]
        public DataTable GetAllUsers()
        {
            try
            {
                string spName = Models.Constants.GeoConnectConstants.spNameGetUsers;
                Dictionary<string, SqlParameter> cmdParams = new Dictionary<string, SqlParameter>();
                DataSet ds = DAL.SqlUtility.DALExecuteQuery(spName, cmdParams);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }


}
