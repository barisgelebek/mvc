using GuvenisProjem.Areas.Admin.Models.Attributes;
using GuvenisProjem.Areas.Admin.Models.DTO;
using GuvenisProjem.Models.ORM.Context;
using GuvenisProjem.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    [LoginControl]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}