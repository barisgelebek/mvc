using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class SiteMenuVM : BaseVM
    {
        [Required(ErrorMessage = "Lütfen Menu Adı Giriniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Menu URL Giriniz!")]
        public string Url { get; set; }

        public string CssClass { get; set; }
    }
}