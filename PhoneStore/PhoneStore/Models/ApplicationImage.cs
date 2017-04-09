using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore.Models
{
    public class ApplicationImage : IApplicationModel
    {
        public int ImageId { get; set; }
        public string Image { get; set; }
        public int PhoneId { get; set; }
    }
}