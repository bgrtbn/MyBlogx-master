using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Author.Controllers
{
    public class AuthorHomeController : BaseController
    {
        public ActionResult Index()
        {
            TempData["class"] = "custom-hide";

            var model = service.ArticleService.GetActive().OrderByDescending(x => x.AddDate).Take(5);

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View(model);
            }

            AppUser user = new AppUser();
            user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);

            if (user.Role == MyBlog.DAL.ORM.Enum.Role.Author)
            {
                TempData["class"] = "custom-show";
            }

            return View(model);
        }

    }
}