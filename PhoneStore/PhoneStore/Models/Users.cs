using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneStore.Models
{
    public class Users
    {
        [Required(ErrorMessage ="Введите имя")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        public string LastName { get; set; }

        [StringLength(10, MinimumLength = 3, ErrorMessage = "Пароль должен быть не менее 3 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите E-Mail")]
        public string Email { get; set; }

    }
}