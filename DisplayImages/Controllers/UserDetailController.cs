using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisplayImages.Models;
using Newtonsoft.Json;

namespace DisplayImages.Controllers
{
    public class UserDetailController : Controller
    {
        public ActionResult Index(int id, bool? fromSearch, int? page, string searchBy, string search)
        {
            UserDetailModel model = new UserDetailModel();
            RetrieveData data = new RetrieveData();
            model.User = data.UserInfoByUserId(id);
            model.Posts = data.PostsByUserId(id);

            if (fromSearch != null)
            {
                ViewBag.fromSearch = fromSearch;
                ViewBag.page = page;
                ViewBag.searchBy = searchBy;
                ViewBag.search = search;
            }
            else
                ViewBag.fromSearch = false;
            return View(model);
        }

      
    }
}