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
    public class SafeBoxController : BaseController
    {
        public ActionResult Index()
        {
            List<SafeBoxVM> model = db.SafeBoxes.Where(x => x.IsDeleted == false).OrderByDescending(x => x.AddDate).Select(x => new SafeBoxVM()
            {
                Name = x.Name,
                Payment = x.Payment,
                Description = x.Description,
                Cash = x.Cash,
                Debt = x.Debt,
                Purchase = x.Purchase,
                ID = x.ID

            }).ToList();

            return View(model);
        }

        public ActionResult AddSafeBox()
        {
            SafeBoxVM model = new SafeBoxVM();
            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddSafeBox(SafeBoxVM model)
        {
            SafeBoxVM vmodel = new SafeBoxVM();

            if (ModelState.IsValid)
            {
                SafeBox safebox = new SafeBox();
                safebox.Name = model.Name;
                safebox.Description = model.Description;
                safebox.Purchase = model.Purchase;
                safebox.Cash = model.Cash;
                safebox.Debt = model.Debt;
                safebox.Payment = model.Payment;

                db.SafeBoxes.Add(safebox);
                db.SaveChanges();

                ViewBag.IslemDurum = 1;

                return RedirectToAction("Index", "SafeBox");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }

        }

        public ActionResult UpdateSafeBox(int id)
        {
            SafeBox safebox = db.SafeBoxes.FirstOrDefault(x => x.ID == id);
            SafeBoxVM model = new SafeBoxVM();
            model.Payment = safebox.Payment;
            model.Name = safebox.Name;
            model.Description = safebox.Description;
            model.Purchase = safebox.Purchase;
            model.Cash = safebox.Cash;
            model.Debt = safebox.Debt;

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateSafeBox(SafeBoxVM model)
        {
            if (ModelState.IsValid)
            {
                SafeBox safebox = db.SafeBoxes.FirstOrDefault(x => x.ID == model.ID);
                safebox.Name = model.Name;
                safebox.Description = model.Description;
                safebox.Purchase = model.Purchase;
                safebox.Cash = model.Cash;
                safebox.Debt = model.Debt;
                safebox.Payment = model.Payment;

                db.SaveChanges();
                ViewBag.IslemDurum = 1;

                return View(model);
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return RedirectToAction("Index", "SafeBox");
            }

        }

        public JsonResult DeleteSafeBox(int id)
        {
            SafeBox safebox = db.SafeBoxes.FirstOrDefault(x => x.ID == id);
            safebox.IsDeleted = true;
            safebox.DeleteDate = DateTime.Now;
            db.SaveChanges();

            return Json("");
        }

        public ActionResult ListOfDeleted()
        {
            List<SafeBoxVM> model = db.SafeBoxes.Where(x => x.IsDeleted == true).OrderBy(x => x.AddDate).Select(x => new SafeBoxVM()
            {
                Name = x.Name,
                Payment = x.Payment,
                Description = x.Description,
                Cash = x.Cash,
                Debt = x.Debt,
                Purchase = x.Purchase,
                ID = x.ID,
                DeleteDate = x.DeleteDate,
                

            }).ToList();

            return View(model);
        }

        public JsonResult Activate(int id)
        {
            SafeBox safebox = db.SafeBoxes.FirstOrDefault(x => x.ID == id);
            safebox.IsDeleted = false;
            safebox.DeleteDate = null;
            db.SaveChanges();

            return Json("");
        }
    }
}

//project - category - Imageproject - Expense tablolarına - silinen öğeleri listeleme ve activate etme işlemini uygulayacağız