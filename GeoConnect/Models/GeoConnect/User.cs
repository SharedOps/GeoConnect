using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Avatar { get; set; }

        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Created_date { get; set; }

        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Modified_date { get; set; }
    }
}