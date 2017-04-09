using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore.UI
{
    public class PagingInfo
    {
        public int TotalPhone { get; set; } // общее кол телефонов
        public int PhoneCurrentPage { get; set; } // кол телефонов на текущей странице
        public int CurrentPage { get; set; } // текущая страница

        // количество страниц
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalPhone / PhoneCurrentPage);
            }
        }
    }
}