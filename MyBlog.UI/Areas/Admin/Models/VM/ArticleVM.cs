using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.UI.Areas.Admin.Models.VM
{
    public class ArticleVM
    {

        public ArticleVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
            articles = new ArticleDTO();
        
        }
        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }
        public ArticleDTO articles { get; set; }

    }
}