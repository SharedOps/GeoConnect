using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoConnect.Models.GeoConnect
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile_no { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime Created_date { get; set; }
        public DateTime Modified_date { get; set; }
    }
}