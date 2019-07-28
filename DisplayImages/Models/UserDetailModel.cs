using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayImages.Models
{
    public class UserDetailModel
    {
        public UserModel User { get; set; }
        public List<UserPostsModel> Posts { get; set; }
    }
}