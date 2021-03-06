﻿using System;
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

        public string ServiceName { get; set; }

        [Display(Name ="Ana resim")]
        public HttpPostedFileBase PostImage { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public int ServiceID { get; set; }

        public string Project { get; set; }

        public IEnumerable<SelectListItem>  drpServices { get; set; }
    }
}