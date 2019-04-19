using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Author.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Author.Models.VM
{
    public class ArticleVM
    {
        public ArticleVM()
        {
            appUsers = new List<AppUser>();
            Categories = new List<Category>();
            article = new ArticleDTO();

        }
        public List<AppUser> appUsers { get; set; }
        public List<Category> Categories { get; set; }
        public ArticleDTO article { get; set; }
    }
}