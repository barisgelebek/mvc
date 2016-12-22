using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class ProjectVM : BaseVM
    {
        [Required(ErrorMessage = "Lütfen Proje Adı Giriniz!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen Detay Giriniz!")]
        public string Content { get; set; }

        public string CategoryName { get; set; }

        [Display(Name ="Ana resim")]
        public HttpPostedFileBase PostImage { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string Project { get; set; }

        public IEnumerable<SelectListItem>  drpCategories { get; set; }
    }
}