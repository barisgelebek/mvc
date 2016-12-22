using GuvenisProjem.Areas.Admin.Models.Attributes;
using GuvenisProjem.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Controllers
{
    [LoginControl]
    public class BaseController : Controller
    {
        public SiteContext db;

        public BaseController()
        {
            db = new SiteContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}