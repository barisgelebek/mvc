using GuvenisProjem.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Models.Services.HTMLDataSourceServices
{
    public class DrpServicesExpense
    {
        public static IEnumerable<SelectListItem> getDrpExpense()
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
        internal static IEnumerable<SelectListItem> getgetDrpExpense()
        {
            throw new NotImplementedException();
        }
    }
}