using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneStore.Models;

namespace PhoneStore.BL.Service
{
   public interface IUserManager
    {
        void Add(User user);
        User GetUser(Login login);
        User GetUserByCookies(string cookie);
        void UpdateCookies(User user, string cookie);
        void UpdateIsActive(User user);
        bool IsAlreadyRegister(User user);
    }
}
