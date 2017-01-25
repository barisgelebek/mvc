using GuvenisProjem.Areas.Admin.Models.DTO;
using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        public ActionResult Index()
        {
            List<ServiceVM> model = db.Services.Where(x => x.IsDeleted == false).OrderBy(x => x.ID).Select(x => new ServiceVM()
            {
                Name = x.Name,
                Description = x.Description,
                icon = x.icon,
                ID = x.ID,
                AddDate = x.AddDate,
            }).ToList();

            return View(model);
        }

        public ActionResult AddService()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddService(ServiceVM model)
        {

            if (ModelState.IsValid)
            {
                Service service = new Service();
                service.Name = model.Name;
                service.icon = model.icon;
                service.Description = model.Description;

                db.Services.Add(service);
                db.SaveChanges();
                ViewBag.IslemDurum = 1;

                return View();
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }

        public ActionResult UpdateService(int id)
        {
            //önce  güncellenecek kategoryi bulup ekrana yazdırıyoruz
            Service service = db.Services.FirstOrDefault(x => x.ID == id);
            ServiceVM model = new ServiceVM();
            model.Name = service.Name;
            model.Description = service.Description;
            model.icon = service.icon;

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateService(ServiceVM model)
        {
            if (ModelState.IsValid)
            {
                //güncellenecek kategoriler yakalanır ve yeni veriler update edilir
                Service service = db.Services.FirstOrDefault(x => x.ID == model.ID);
                service.Name = model.Name;
                service.Description = model.Description;
                service.icon = model.icon;
                ViewBag.IslemDurum = 1;

                db.SaveChanges();

                return View();
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }

        public JsonResult DeleteService(int id)
        {
            Service service = db.Services.FirstOrDefault(x => x.ID == id);
            service.IsDeleted = true;
            service.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }

    }
}