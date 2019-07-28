using DisplayImages.Models;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DisplayImages.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            RetrieveData data = new RetrieveData();
            List<UserModel> model = new List<UserModel>();

            model = data.UserInfo();
            data.AlbumInfoByUserId(model);
            foreach (var user in model)
                data.FirstAlbumThumnailByAlbumId(user);

            return View(model.ToPagedList(page ?? 1, 1));
        }
    }
}