using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Controllers;
using MyBlog.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Member.Controllers
{
    public class MemberArticleController : BaseController
    {
        private  object comment;


        public ActionResult Show(Guid id)
        {
            MemberArticleCommentVM model = new MemberArticleCommentVM()
            {

                Articles = service.ArticleService.GetActive(),

                AppUsers = service.AppUserService.GetActive(),

                Comments = service.CommentService.GetDefault(x => x.ArticleID == id).OrderByDescending(x => x.AddDate).Take(10),

                //Likes = service.LikeService.GetDefault(x => x.ArticleID == id).Count(),

            };
            return View(model);
        }

        public ActionResult AddComment(MemberCommentVM data)
        {
            Comment comment = new Comment
            {
                AppUserID = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name).ID,
                ArticleID = data.ID,
                Content = data.Content,
                AddDate = DateTime.Now
            };
            service.CommentService.Add(comment);
            return Redirect("Member/MemberArticle/Show/" + data.ID);
        }

    }
}