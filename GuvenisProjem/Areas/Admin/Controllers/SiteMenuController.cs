using GuvenisProjem.Areas.Admin.Models.DTO;
using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    public class SiteMenuController : BaseController
    {
        public object SiteMenu { get; private set; }

        public ActionResult Index()
        {
            List<SiteMenuVM> model = db.SiteMenus.Where(x => x.IsDeleted == false).OrderBy(x => x.ID).Select(x => new SiteMenuVM()
            {
                Name = x.Name,
                Url = x.Url,
                CssClass = x.CssClass,
                ID = x.ID
            }).ToList();

            return View(model);
        }

        public ActionResult AddSiteMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSiteMenu(SiteMenuVM model)
        {
            if (ModelState.IsValid)
            {
                SiteMenu sitemenu = new SiteMenu();
                sitemenu.Name = model.Name;
                sitemenu.Url = model.Url;
                sitemenu.CssClass = model.CssClass;

                db.SiteMenus.Add(sitemenu);
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

        public ActionResult UpdateSiteMenu(int id)
        {
            //önce  güncellenecek Menüyü bulup ekrana yazdırıyoruz
            SiteMenu sitemenu = db.SiteMenus.FirstOrDefault(x => x.ID == id);
            SiteMenuVM model = new SiteMenuVM();
            model.Name = sitemenu.Name;
            model.Url = sitemenu.Url;
            model.CssClass = sitemenu.CssClass;

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateSiteMenu(SiteMenuVM model)
        {
            if (ModelState.IsValid)
            {
                //güncellenecek menüler yakalanır ve yeni veriler update edilir
                SiteMenu sitemenu = db.SiteMenus.FirstOrDefault(x => x.ID == model.ID);
                sitemenu.Name = model.Name;
                sitemenu.Url = model.Url;
                sitemenu.CssClass = model.CssClass;
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

        public JsonResult DeleteSiteMenu(int id)
        {
            SiteMenu sitemenu = db.SiteMenus.FirstOrDefault(x => x.ID == id);
            sitemenu.IsDeleted = true;
            sitemenu.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }

    }
}