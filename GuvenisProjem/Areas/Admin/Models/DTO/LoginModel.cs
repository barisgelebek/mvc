using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class LoginModel
    {
        
        [EmailAddress(ErrorMessage = "Lütefen Geçerli bir E-Mail Adresi Giriniz!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Parolanızı Giriniz!")]
        public string Password { get; set; }

        public bool Remember { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz!")]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Job { get; set; }
    }
}