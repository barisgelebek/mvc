using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Entity
{
    public class Expense : BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Unit { get; set; }

        [StringLength(10)]
        public string Quantity { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public int ProjectID { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        


    }
}