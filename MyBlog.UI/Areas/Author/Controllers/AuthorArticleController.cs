using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Controllers;
using MyBlog.UI.Areas.Author.Models.DTO;
using MyBlog.UI.Areas.Author.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Author.Controllers
{
    public class AuthorArticleController : BaseController
    {
           public ActionResult Add()
        {
            ArticleVM model = new ArticleVM()
            {
               
                Categories = service.CategoryService.GetActive()
            };
            return View(model);
        }
       
            
        [HttpPost]
        public ActionResult Add(Article data)
        {
          AppUser  appUser = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);
            data.AppUserID = appUser.ID;
            data.PublishDate = DateTime.Now;
            service.ArticleService.Add(data);
            return Redirect("/Author/AuthorArticle/List");
        }

        public ActionResult List()
        {
 

           List<Article> model= service.ArticleService.GetActive();
 


            return View(model);

        }

        public ActionResult Update(Guid id)
        {
            Article article = service.ArticleService.GetById(id);
            ArticleVM model = new ArticleVM();
            model.article.ID = article.ID;
            model.article.Content = article.Content;
            model.article.SubTitle = article.SubTitle;
            model.article.Header = article.Header;
            model.article.PublishDate = article.PublishDate;
            List<Category> category = service.CategoryService.GetActive();

            model.Categories = category;

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
            return Redirect("/Author/AuthorArticle/List");
        }

        public ActionResult Delete(Guid id)
        {
            service.ArticleService.Remove(id);
            //TempData["Successful"] = "Transaction is successful.";
            return Redirect("/Author/AuthorArticle/List");
        }
    }
}