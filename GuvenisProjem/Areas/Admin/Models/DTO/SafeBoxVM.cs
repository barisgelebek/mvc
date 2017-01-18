using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class SafeBoxVM : BaseVM
    {
        //internal IEnumerable<SelectListItem> drpCategories;

        [Required(ErrorMessage = "Lütfen Evran No Giriniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Açıklama Giriniz!")]
        public string Description { get; set; }

        public string Cash { get; set; }

        public decimal Purchase { get; set; }

        public decimal Debt { get; set; }

        public string Payment { get; set; }

        public DateTime? DeleteDate { get; set; }


    }
}