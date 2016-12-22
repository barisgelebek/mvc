using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuvenisProjem.Areas.Admin.Models.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Lütfen E-Mail Adresi Giriniz!")]
        [EmailAddress(ErrorMessage = "Lütefen Geçerli bir E-Mail Adresi Giriniz!")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Parolanızı Giriniz!")]
        public string Password { get; set; }
    }
}