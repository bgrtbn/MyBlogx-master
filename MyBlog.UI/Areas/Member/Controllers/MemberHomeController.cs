using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Member.Controllers
{
    public class MemberHomeController : BaseController
    {
        public ActionResult MemberHomeIndex()
        {

            IEnumerable<Article> model = service.ArticleService.GetActive().OrderByDescending(x => x.AddDate).Take(5);

            return View(model);
        }
    }
}