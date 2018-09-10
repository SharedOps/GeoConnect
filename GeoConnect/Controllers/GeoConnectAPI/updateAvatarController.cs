using System;
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

namespace GeoConnect.Controllers.GeoConnectAPI
{
    public class updateAvatarController : ApiController
    {

        [HttpPatch]
        public void UpdatePhoto(User updateAvatar, int id)
        {
            try
            {
                string spName = Models.Constants.GeoConnectConstants.spUpdateAvatar;
                Dictionary<string, SqlParameter> cmdParams = new Dictionary<string, SqlParameter>();
                cmdParams["@p_Id"] = new SqlParameter("@p_Id", id);
                cmdParams["@p_Avatar"] = new SqlParameter("@p_Avatar", updateAvatar.Avatar.ToString());
                DAL.SqlUtility.DALExecuteCommand(spName, cmdParams);

            }
            catch (Exception ex)
            {
                Logging.ErrorLogging.LogError(ex.Message.ToString(), "UserRegistration", "");
            }

        }
    }
}
