using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class CategoryVM : BaseVM
    {
        [Required(ErrorMessage ="Lütfen Kategori Adı Giriniz!")]
        [Display(Name="Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Kategori Açıklama Giriniz!")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "icon")]
        public string icon { get; set; }
    }
}