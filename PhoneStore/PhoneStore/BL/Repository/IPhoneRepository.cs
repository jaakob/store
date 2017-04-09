using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;

namespace PhoneStore.BL.Repository.EF
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetAllPhones();
        void Add(Phone phone);
        int GetPhoneId(Phone phone);
    }
}
