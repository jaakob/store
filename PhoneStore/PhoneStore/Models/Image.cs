using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore.Models
{
    public class Image : IApplicationModel
    {
        public int ID { get; set; }
        public string ImageURL { get; set; }
        public int PhoneId { get; set; }
    }
}