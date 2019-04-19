using MyBlog.DAL.ORM.Entity;
using MyBlog.UI.Areas.Admin.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category data)
        {
            service.CategoryService.Add(data);
            return Redirect("/Admin/Category/List");
        }
        public ActionResult List()
        {
            List<Category> model = service.CategoryService.GetActive();
            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            Category category = service.CategoryService.GetById(id);
            CategoryDTO model = new CategoryDTO();
            model.ID = category.ID;
            model.CategoryName = category.CategoryName;
            model.Description = category.Description;

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CategoryDTO data)
        {
            Category category = service.CategoryService.GetById(data.ID);
            category.CategoryName = data.CategoryName;
            category.Description = data.Description;
      

            service.CategoryService.Update(category);
            // TempData["Successful"] = "Transaction is successful.";
            return Redirect("/Admin/Category/List");
        }

        public ActionResult Delete(Guid id)
        {
            service.CategoryService.Remove(id);
            //TempData["Successful"] = "Transaction is successful.";
            return Redirect("/Admin/Category/List");
        }
    }
}