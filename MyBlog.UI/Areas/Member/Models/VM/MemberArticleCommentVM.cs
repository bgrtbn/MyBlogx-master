using MyBlog.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Member.Models.VM
{
    public class MemberArticleCommentVM
    {

        public MemberArticleCommentVM()
        {
            Comments = new List<Comment>();
            Articles = new List<Article>();
            AppUsers = new List<AppUser>();

        }

        public IEnumerable<AppUser> AppUsers { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        //public int Likes { get; set; }

    }
}
