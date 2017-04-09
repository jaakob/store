using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;
using PhoneStore.BL.Service;

namespace PhoneStore.BL.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetUser(Login login);
        User GetUserByCookies(string cookie);
        void UpdateCookies(User user, string cookie);
        bool IsAlreadyRegister(User user);
        void UpdateIsActive(User user, bool value);
    }
}
