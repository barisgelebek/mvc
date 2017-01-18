using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Entity
{
    public class SafeBox : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(20)]
        public string Cash { get; set; }

        public decimal Purchase { get; set; }

        public decimal Debt { get; set; }

        public string Payment { get; set; }

    }
}