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
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Atlassian.Jira;

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
                cmdParams["@p_Avatar"]    = new SqlParameter("@p_Avatar", newuser.Avatar.ToString());
                DAL.SqlUtility.DALExecuteCommand(spName, cmdParams);

            }
            catch (Exception ex)
            {
                Logging.ErrorLogging.LogError(ex.Message.ToString(), "UserRegistration", "");
            }

        }


        [HttpPatch]
        public void updateUser(User updateUser, int id)
        {
            try
            {
                string spName = Models.Constants.GeoConnectConstants.spNameUpdateUser;
                Dictionary<string, SqlParameter> cmdParams = new Dictionary<string, SqlParameter>();
                cmdParams["@p_Id"] = new SqlParameter("@p_Id", id);
                cmdParams["@p_Name"] = new SqlParameter("@p_Name", updateUser.Name);
                cmdParams["@p_Mobile_no"] = new SqlParameter("@p_Mobile_no", updateUser.Mobile_no);
                cmdParams["@p_Email"] = new SqlParameter("@p_Email", updateUser.Email);
                cmdParams["@p_Location"] = new SqlParameter("@p_Location", updateUser.Location);
                //cmdParams["@p_Avatar"] = new SqlParameter("@p_Avatar", updateUser.Avatar.ToString());
                DAL.SqlUtility.DALExecuteCommand(spName, cmdParams);

            }
            catch (Exception ex)
            {
                Logging.ErrorLogging.LogError(ex.Message.ToString(), "UserRegistration", "");
            }

        }

        static private async Task JIraCall()
        {
            var jira = Jira.CreateRestClient("https://geoconnect.atlassian.net", "manimanu452@gmail.com", "Pranay@12");
            var issue = jira.CreateIssue("My Project");
            issue.Type = "Bug";
            issue.Priority = "Major";
            issue.Summary = "Issue Summary";

            await issue.SaveChangesAsync();
        }


    }


}
