using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models
{
    public class User : IApplicationModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Пароль обязателен для заполнения")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Пароль не менее 5 и не более 15 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Почта обязательная для заполнения")]
        [StringLength(256, MinimumLength = 5, ErrorMessage = "Электронный адрес не менее 5 и не более 256 символов")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string ContactPhone { get; set; }

        public DateTime RegDate { get; set; }

        public string Cookie { get; set; }

        public bool IsActive { get; set; }
    }
}