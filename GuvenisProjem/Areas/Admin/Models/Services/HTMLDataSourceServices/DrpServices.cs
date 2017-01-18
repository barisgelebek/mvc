using GuvenisProjem.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Models.Services.HTMLDataSourceServices
{
    public class DrpImageServices
    {
        public static IEnumerable<SelectListItem> getDrpCategories()
        {
            using (SiteContext db = new SiteContext())
            {
            IEnumerable<SelectListItem> drpcategories = db.Categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.ID.ToString()
            }).ToList();

            return drpcategories;
            }

        }

        internal static IEnumerable<SelectListItem> getDrpProjects()
        {
            throw new NotImplementedException();
        }

        internal static IEnumerable<SelectListItem> getDrpSafeBoxes()
        {
            throw new NotImplementedException();
        }
    }
}