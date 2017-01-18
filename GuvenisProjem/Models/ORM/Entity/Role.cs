using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Models.ORM.Entity
{
    public class Role
    {
        public int ID { get; set; }

        public string RoleName { get; set; }

        public virtual List<AdminUser> AdminUsers { get; set; }
    }
}