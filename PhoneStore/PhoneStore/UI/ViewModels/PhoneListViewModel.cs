using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;

namespace PhoneStore.UI.ViewModels
{
    public class PhoneListViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Phone Phone { get; set; }
    }
}