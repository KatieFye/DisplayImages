using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DisplayImages.Models;
using Newtonsoft.Json;
using PagedList;
using PagedList.Mvc;

namespace DisplayImages.Controllers
{
    public class AlbumTitlesController : Controller
    {
        public ActionResult Index(int id, int? page, bool? fromSearch, string searchBy, string search)
        {
            RetrieveData data = new RetrieveData();
            List<PhotoModel> model = new List<PhotoModel>();
            model = data.PhotosByAlbumId(id);

            string albumTitle = data.AlbumTitleByAlbumId(id);
            ViewBag.AlbumTitle = albumTitle;
            ViewBag.id = id;

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            if (fromSearch != null)
            {
                ViewBag.fromSearch = fromSearch;
                ViewBag.page = page;
                ViewBag.searchBy = searchBy;
                ViewBag.search = search;
            }
            else
                ViewBag.fromSearch = false;

            return View(model.ToPagedList(pageNumber, pageSize));
        }



      
    }
}