using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;
using PhoneStore.BL.Service;

namespace PhoneStore.BL.Repository
{
    public interface IUserRepository<T>
    {
        void Add(T user);
        T GetUser(Login login);
        T GetUserByCookies(string cookie);
        void UpdateCookies(T user, string cookie);
        void MakeActive(T user);
        bool IsAlreadyRegister(T user);        
    }
}
