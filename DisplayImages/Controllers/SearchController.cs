using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisplayImages.Models;
using Newtonsoft.Json;
using PagedList;

namespace DisplayImages.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index(int? page, string searchBy, string search)
        {
            List<UserModel> model = new List<UserModel>();
            RetrieveData data = new RetrieveData();

            model = data.UserInfo();
            data.AlbumInfoByUserId(model);
            foreach (var user in model)
                data.FirstAlbumThumnailByAlbumId(user);

            List<UserModel> finalList = new List<UserModel>();
            ViewBag.search = search;
            ViewBag.page = page;

            if (searchBy == "User's Name")
            {
                ViewBag.searchBy = "User's Name";
                finalList = model.Where(x => x.name.ToLower().Contains(search)).ToList();
            }

            else //(searchBy == "Album Title")
            {
                ViewBag.searchBy = "Album Title";
                FilterModelOnAlbumTitle(search, model, finalList);
            }
            return View(finalList.ToPagedList(page ?? 1, 1));
        }

        private static void FilterModelOnAlbumTitle(string search, List<UserModel> model, List<UserModel> finalList)
        {
            foreach (var user in model)
            {
                List<AlbumsModel> tempAlbum = user.albums.Where(x => x.title.ToLower().Contains(search)).ToList();
                if (tempAlbum.Count != 0)
                {
                    UserModel tempUser = new UserModel(user);
                    tempUser.albums = tempAlbum;
                    finalList.Add(tempUser);
                }
            }
        }
    }
}