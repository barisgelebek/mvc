using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class ProjectImageVM : BaseVM
    {
        [Required(ErrorMessage = "Lütfen Resim Adı Giriniz!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ProjectID { get; set; }

        [Display(Name = "Ana resim")]
        public HttpPostedFileBase PostImage { get; set; }

        public string ImagePath { get; set; }

        public string ProjectTitle { get; set; }

        public IEnumerable<SelectListItem> drpProject { get; set; }

        public string Project { get; set; }


    }
}