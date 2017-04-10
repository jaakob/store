using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;

namespace PhoneStore.BL.Service
{
    public interface IPhoneManager
    {
        IEnumerable<Phone> GetAllPhones();
        void Add(Phone phone);
        int GetPhoneId(Phone phone);
    }
}