using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class ExpenseVM : BaseVM
    {
        [Required(ErrorMessage = "Lütfen Masraf Adı Giriniz!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

        public string Quantity { get; set; }

        public decimal Amount { get; set; }

        public int ProjectID { get; set; }

        public string ProjectTitle { get; set; }
        
        public IEnumerable<SelectListItem> drpProject { get; set; }
        
        public string Project { get; set; }

        public DateTime AddDate { get; set; }
    }
}