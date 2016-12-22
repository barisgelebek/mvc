using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int CategoryID { get; set; }

        public string ImagePath { get; set; }

        [ForeinKey("CategoryID")]
        public virtual Category Category { get; set; }

        public virtual List<ProjectImage> ProjectImages { get; set; }
    }
}