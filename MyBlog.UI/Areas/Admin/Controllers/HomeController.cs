﻿using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
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

            if (user.Role == MyBlog.DAL.ORM.Enum.Role.Admin)
            {
                TempData["class"] = "custom-show";
            }

            return View(model);
        }
    }
}