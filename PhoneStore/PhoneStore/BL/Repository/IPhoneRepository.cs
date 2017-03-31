using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;

namespace PhoneStore.BL.Repository
{
    public interface IPhoneRepository<T>
    {
        T GetPhone(int id);
        void Add(T phone);
    }
}
