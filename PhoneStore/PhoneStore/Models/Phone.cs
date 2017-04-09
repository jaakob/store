using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Models
{
    public class Phone : IApplicationModel
    {
        public int PhoneId { get; set; }
        
        [Required(ErrorMessage = "Модель обязательно для заполнения")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "Модель более 1 символа и не более 45")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Производитель обязателен для заполнения")]
        [StringLength(15, MinimumLength = 1, ErrorMessage = "Производитель более 1 символа и не более 15")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Описание обязательно для заполнения")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Описание не менее 10 символов и не более 250")]
        public string Description { get; set; }

        [Range(typeof(Decimal), "1", "1000000", ErrorMessage = "Цена должна быть в диапазоне от 1$ до 1000000$")]
        public decimal Price { get; set; }

        public int UserId { get; set; }

        public Lazy<List<ApplicationImage>> Images = new Lazy<List<ApplicationImage>>();
    }
}