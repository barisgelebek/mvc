using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class ServiceVM : BaseVM
    {
        [Required(ErrorMessage = "Lütfen Hizmet Adı Giriniz!")]
        [Display(Name="Ad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Hizmet Açıklama Giriniz!")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "icon")]
        public string icon { get; set; }

        public DateTime AddDate { get; set; }
    }
}