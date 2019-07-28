using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayImages.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public UserAddressModel address { get; set; }
        public UserCompanyModel company { get; set; }
        public List<AlbumsModel> albums {get;set;}
        public PhotoModel photo { get; set; }


        public UserModel()
        { }

        public UserModel(UserModel modelpassed)
        {
            id = modelpassed.id;
            name = modelpassed.name;
            username = modelpassed.username;
            email = modelpassed.email;
            phone = modelpassed.phone;
            website = modelpassed.website;
            address = modelpassed.address;
            company = modelpassed.company;
            photo = modelpassed.photo;
        }
    }

}