using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}