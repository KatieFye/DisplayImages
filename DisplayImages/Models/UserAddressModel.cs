using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayImages.Models
{
    public class UserAddressModel
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public UserGeoModel geo { get; set; }
    }
}