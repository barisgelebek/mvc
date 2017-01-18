using GuvenisProjem.Areas.Admin.Models.DTO;
using GuvenisProjem.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private SiteContext db = new SiteContext();
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.AdminUsers.Any(x => x.Name == model.Name && x.Password == model.Password && x.IsDeleted == false))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");

                }

                else
                {
                    return View();
                }
            }

            else
            {
                return View();
            }

        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}