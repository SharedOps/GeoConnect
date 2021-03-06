﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoConnect.Models.Constants
{
    public class GeoConnectConstants
    {
        public const string baseURL          = "http://localhost/GeoConnect/";
        public const string spNameAddUser    = "sp_insert_Users";
        public const string spNameUpdateUser = "sp_update_Users";
        public const string spUpdateAvatar   = "sp_update_avatar";
        public const string spNameDeleteUser = "";
        public const string spNameGetUsers   = "sp_get_Users ";
        public const string spLogError       = "sp_Log_Error ";
    }
}