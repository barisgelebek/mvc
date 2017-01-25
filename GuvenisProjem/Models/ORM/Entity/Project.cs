using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Entity
{
    public class Project : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int ServiceID { get; set; }

        public string ImagePath { get; set; }

        [ForeignKey("ServiceID")]
        public virtual Service Service { get; set; }

        public virtual List<ProjectImage> ProjectImages { get; set; }
    }
}