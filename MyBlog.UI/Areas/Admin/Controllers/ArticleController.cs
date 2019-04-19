using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO;
using MyBlog.UI.Areas.Admin.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        public ActionResult Add()
        {
            ArticleVM model = new ArticleVM()
            {
                Categories = service.CategoryService.GetActive(),

                AppUsers = service.AppUserService.GetActive(),

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Article data)
        {
            service.ArticleService.Add(data);
            return Redirect("/Admin/Article/List");
        }

        public ActionResult List()
        {
            List<Article> model = service.ArticleService.GetActive();
            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            Article article = service.ArticleService.GetById(id);
            ArticleVM model = new ArticleVM();
            model.articles.ID = article.ID;
            model.articles.Content = article.Content;
            model.articles.SubTitle = article.SubTitle;
            model.articles.Header = article.Header;
            model.articles.PublishDate = article.PublishDate;
            List<Category> category = service.CategoryService.GetActive();
            List<AppUser> appUsers = service.AppUserService.GetActive();
            model.Categories = category;
            model.AppUsers = appUsers;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ArticleDTO data)
        {
            Article article = service.ArticleService.GetById(data.ID);
            article.Header = data.Header;
            article.Content = data.Content;
            article.SubTitle = data.SubTitle;
            article.PublishDate = data.PublishDate;
            service.ArticleService.Update(article);
            //TempData["Successful"] = "Transaction is successful.";
            return Redirect("/Admin/Article/List");
        }

        public ActionResult Delete(Guid id)
        {
            service.ArticleService.Remove(id);
            //TempData["Successful"] = "Transaction is successful.";
            return Redirect("/Admin/Article/List");
        }
    }
}