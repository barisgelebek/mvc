using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class UnitVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<SelectListItem> drpUnits { get; set; }
    }
}