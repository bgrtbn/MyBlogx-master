using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Controllers;
using MyBlog.UI.Areas.Admin.Models.VM;
using MyBlog.UI.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.UI.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {

                AppUser user = service.AppUserService.FindByUserName(HttpContext.User.Identity.Name);

                if (user.Role == DAL.ORM.Enum.Role.Admin)
                {

                    return Redirect("/Admin/Home/Index");
                }
                else if (user.Role == DAL.ORM.Enum.Role.Author)
                {

                    return Redirect("/Author/AuthorHome/Index");
                }
                else if (user.Role == DAL.ORM.Enum.Role.Member)
                {

                    return Redirect("/Member/MemberHome/MemberHomeIndex");

                }
            }

                return View();
            }
        
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credentials)
        {
            if (ModelState.IsValid)
            {
                if (service.AppUserService.CheckCredentials(credentials.UserName, credentials.Password))
                {
                    AppUser user = service.AppUserService.FindByUserName(credentials.UserName);

                    string cookie = user.UserName;
                    FormsAuthentication.SetAuthCookie(cookie, true);
                  
                    if (user.Role == DAL.ORM.Enum.Role.Admin)
                    {
                        Session["FullName"] = user.FirstName + " " + user.LastName;
                        return Redirect("/Admin/Home/Index" );
                    }
                    else if (user.Role == DAL.ORM.Enum.Role.Author)
                    {
                        Session["ID"] = user.ID;
                        Session["FullName"] = user.FirstName + " " + user.LastName;
                        return Redirect("/Author/AuthorHome/Index");
                    }
                    else if (user.Role == DAL.ORM.Enum.Role.Member)
                    {
                        Session["FullName"] = user.FirstName + " " + user.LastName;
                        return Redirect("/Member/MemberHome/Index");

                       
                    }
                }
                else
                {
                    ViewData["error"] = "Kullanıcı Adı veya Şifre Hatalı";
                    return View();
                }
            }
            TempData["class"] = "custom-show";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}