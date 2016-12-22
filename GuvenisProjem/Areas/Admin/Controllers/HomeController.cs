using GuvenisProjem.Areas.Admin.Models.Attributes;
using GuvenisProjem.Models.ORM.Context;
using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    [LoginControl]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //SiteContext db = new SiteContext();
            //string email = HttpContext.User.Identity.Name;
            //AdminUser adminuser = db.AdminUsers.FirstOrDefault(x => x.EMail == email);
            //string name = adminuser.Name;
            //string surname = adminuser.Surname;


            return View();
        }
    }
}