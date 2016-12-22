using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Entity
{
    public class ProjectImage : BaseEntity
    {
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ProjectID { get; set; }

        public string ImagePath { get; set; }

        [ForeinKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}