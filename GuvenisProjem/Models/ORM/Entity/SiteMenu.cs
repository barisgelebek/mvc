using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Entity
{
    public class SiteMenu : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public string CssClass { get; set; }
    }
}