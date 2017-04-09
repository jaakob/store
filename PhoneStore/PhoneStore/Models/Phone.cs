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

        [Required(ErrorMessage = "Укажите модель")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Укажите производителя")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Укажите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        //[RegularExpression(@"^\d{0,5}\.{0,1}\d{1,2}$", ErrorMessage = "Неправильная цена")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Неправильная цена")]
        [Range(0, 99999.99, ErrorMessage = "Цена не может быть меньше нуля и больше 100000")]        
        public decimal Price { get; set; }

        public int UserId { get; set; }
        public List<string> Images { get; set; }        

    }
}