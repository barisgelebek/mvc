using GuvenisProjem.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Models.Services.HTMLDataSourceServices
{
    public class DrpServicesProjectImage
    {
        public static IEnumerable<SelectListItem> getDrpProjects()
        {
            using (SiteContext db = new SiteContext())
            {
                IEnumerable<SelectListItem> DrpServices = db.Projects.Select(x => new SelectListItem()
                {
                    Text = x.Title,
                    Value = x.ID.ToString()
                }).ToList();

                return DrpServices;
            }

        }
    }
}