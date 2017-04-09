using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;


namespace PhoneStore.Models
{
    public class Login : IApplicationModel
    {
        [Required (ErrorMessage = "Email не заполнен")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Email не менее 5 и не более 256 символов")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Пароль не заполнен")]
        [StringLength(15, ErrorMessage = "Пароль не менее 5 и не более 15 символов ", MinimumLength = 5)]
        public string Password { get; set; }
    }
}