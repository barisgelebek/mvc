using GuvenisProjem.Areas.Admin.Models.DTO;
using GuvenisProjem.Areas.Admin.Models.Services.HTMLDataSourceServices;
using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    public class ProjectController : BaseController
    {
        public ActionResult Index()
        {
            List<ProjectVM> model = db.Projects.Where(x => x.IsDeleted == false).OrderBy(x => x.AddDate).Select(x => new ProjectVM()
            {
                Title = x.Title,
                CategoryName = x.Category.Name,
                Content = x.Content,
                ImagePath = x.ImagePath,
                ID = x.ID
            }).ToList();

            return View(model);
        }

        public ActionResult AddProject()
        {
            ProjectVM model = new ProjectVM();
            model.drpCategories = DrpImageServices.getDrpCategories();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddProject(ProjectVM model)
        {
            ProjectVM vmodel = new ProjectVM();
            vmodel.drpCategories = DrpImageServices.getDrpCategories();

            string filename = "";
            foreach (string name in Request.Files)
            {
                model.PostImage = Request.Files[name];
                string ext = Path.GetExtension(model.PostImage.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG")
                {
                    string uniqnumber = Guid.NewGuid().ToString();
                    filename = uniqnumber + model.PostImage.FileName;
                    model.PostImage.SaveAs(Server.MapPath("~/Areas/Admin/Content/Site/images/project/" + filename));
                }

            }

            if (ModelState.IsValid)
            {
                Project project = new Project();
                project.CategoryID = model.CategoryID;
                project.Title = model.Title;
                project.Content = model.Content;
                project.ImagePath = filename;

                db.Projects.Add(project);
                db.SaveChanges();

                ViewBag.IslemDurum = 1;
                return RedirectToAction("Index", "Project");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }

        }

        public ActionResult UpdateProject(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.ID == id);
            ProjectVM model = new ProjectVM();
            model.CategoryID = project.CategoryID;
            model.Title = project.Title;
            model.Content = project.Content;
            model.ImagePath = project.ImagePath;
            model.drpCategories = DrpImageServices.getDrpCategories();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateProject(ProjectVM model)
        {
            ProjectVM vmodel = new ProjectVM();
            vmodel.drpCategories = DrpImageServices.getDrpCategories();

            string filename = "";
            foreach (string name in Request.Files)
            {
                model.PostImage = Request.Files[name];
                string ext = Path.GetExtension(model.PostImage.FileName);
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".JPG" || ext == ".JPEG" || ext == ".PNG")
                {
                    string uniqnumber = Guid.NewGuid().ToString();
                    filename = uniqnumber + model.PostImage.FileName;
                    model.PostImage.SaveAs(Server.MapPath("~/Areas/Admin/Content/Site/images/project/" + filename));
                }

            }

            if (ModelState.IsValid)
            {
                Project project = db.Projects.FirstOrDefault(x => x.ID == model.ID);
                project.CategoryID = model.CategoryID;
                project.Title = model.Title;
                project.Content = model.Content;
                project.ImagePath = filename;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;

                return RedirectToAction("Index", "Project");
            }
            else
            {
                ViewBag.IslemDurum = 2;

                return View(vmodel);

            }
        }

        public JsonResult DeleteProject(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.ID == id);
            project.IsDeleted = true;
            project.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }
    }
}