using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyEvernote.WebApp.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Username"), Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Username { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(70, ErrorMessage = "{0} max. {1} karakter olmalı."),
         EmailAddress(ErrorMessage = "Please type a valid email.")]
        public string Email { get; set; }

        [DisplayName("Password"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı.")]
        public string Password { get; set; }

        [DisplayName("Retype Password"),
            Required(ErrorMessage = "{0} alanı boş geçilemez."),
            DataType(DataType.Password),
            StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalı."),
            Compare("Password", ErrorMessage = "{0} and {1} doesn't match.")]
        public string RePassword { get; set; }
    }
}