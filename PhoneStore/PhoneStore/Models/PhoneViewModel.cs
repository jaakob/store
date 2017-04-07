using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore.Models
{
    public class PhoneViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}