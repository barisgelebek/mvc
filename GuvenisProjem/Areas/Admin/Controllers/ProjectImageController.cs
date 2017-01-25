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
    public class ProjectImageController : BaseController
    {
        public ActionResult Index()
        {
            List<ProjectImageVM> model = db.ProjectImages.Where(x => x.IsDeleted == false).OrderBy(x => x.ProjectID).Select(x => new ProjectImageVM()
            {
                Name = x.Name,
                ProjectTitle = x.Project.Title,
                Description = x.Description,
                Project = x.Project.Title,
                ImagePath = x.ImagePath,
                ID = x.ID
            }).ToList();

            return View(model);
        }

        public ActionResult AddProjectImage()
        {
            ProjectImageVM model = new ProjectImageVM();
            model.drpProject = DrpServicesProjectImage.getDrpProjects();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddProjectImage(ProjectImageVM model)
        {
            ProjectImageVM vmodel = new ProjectImageVM();
            model.drpProject = DrpServicesProjectImage.getDrpProjects();

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
                ProjectImage projectimage = new ProjectImage();
                projectimage.ProjectID = model.ProjectID;
                projectimage.Name = model.Name;
                projectimage.Description = model.Description;
                projectimage.ImagePath = filename;

                db.ProjectImages.Add(projectimage);
                db.SaveChanges();

                ViewBag.IslemDurum = 1;
                return View(model);
                //return RedirectToAction("Index", "ProjectImage");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }

        }

        public ActionResult UpdateProjectImage(int id)
        {
            ProjectImage projectimage = db.ProjectImages.FirstOrDefault(x => x.ID == id);
            ProjectImageVM model = new ProjectImageVM();
            model.ProjectID = projectimage.ProjectID;
            model.Name = projectimage.Name;
            model.Description = projectimage.Description;
            model.ImagePath = projectimage.ImagePath;
            model.drpProject = DrpServicesProjectImage.getDrpProjects();

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateProjectImage(ProjectImageVM model)
        {
            ProjectImageVM vmodel = new ProjectImageVM();
            vmodel.drpProject = DrpServicesProjectImage.getDrpProjects();

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
                ProjectImage projectimage = db.ProjectImages.FirstOrDefault(x => x.ID == model.ID);
                projectimage.ProjectID = model.ProjectID;
                projectimage.Name = model.Name;
                projectimage.Description = model.Description;
                projectimage.ImagePath = filename;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View(vmodel);
                //return RedirectToAction("Index", "ProjectImage");
            }
            else
            {
                ViewBag.IslemDurum = 2;

                return View(vmodel);

            }
        }

        public JsonResult DeleteProjectImage(int id)
        {
            //ProjectImage projectimage = db.ProjectImages.FirstOrDefault(x => x.ID == id);
            ProjectImage projectimage = db.ProjectImages.FirstOrDefault(x => x.ID == id);
            projectimage.IsDeleted = true;
            projectimage.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }
    }
}