using GuvenisProjem.Areas.Admin.Models.DTO;
using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
       // public object Cetegory { get; private set; }

        public ActionResult Index()
        {
            List<CategoryVM> model = db.Categories.Where(x => x.IsDeleted == false).OrderBy(x => x.ID).Select(x => new CategoryVM()
            {
                Name = x.Name,
                Description = x.Description,
                icon = x.icon,
                ID = x.ID
            }).ToList();

            return View(model);
        }
        
        public ActionResult AddCategory()
        {
            return View();
        }

        [Authorize(Roles= ("IsActive = False"))]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddCategory(CategoryVM model)
        {
            
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = model.Name;
                category.icon = model.icon;
                category.Description = model.Description;

                db.Categories.Add(category);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;

                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }

        public ActionResult UpdateCategory(int id)
        {
            //önce  güncellenecek kategoryi bulup ekrana yazdırıyoruz
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            CategoryVM model = new CategoryVM();
            model.Name = category.Name;
            model.Description = category.Description;
            model.icon = category.icon;

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                //güncellenecek kategoriler yakalanır ve yeni veriler update edilir
                Category category = db.Categories.FirstOrDefault(x => x.ID == model.ID);
                category.Name = model.Name;
                category.Description = model.Description;
                category.icon = model.icon;
                ViewBag.IslemDurum = 1;

                db.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }

        public JsonResult DeleteCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.ID == id);
            category.IsDeleted = true;
            category.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }

    }
}