using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Entity
{
    public class AdminUser : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string EMail { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }

        [Required]
        [StringLength(15)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Surname { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(150)]
        public string Photo { get; set; }

        [StringLength(20)]
        public string Job { get; set; }

        [StringLength(100)]
        public string Adress { get; set; }

        public int RoleID { get; set; }
        public List<Role> Roles { get; set; }

        private bool _isActive = false;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;

            }
        }
    }
}