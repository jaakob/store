using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;
using PhoneStore.BL.Repository;

namespace PhoneStore.BL.Service
{
    public class UserManager : IUserManager
    {
        private IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user)); //ArgumentNull....

            userRepository.Add(user);

        }

        public User GetUser(Login login)
        {
            if (login == null)
                return null;

           return userRepository.GetUser(login);
        }

        public User GetUserByCookies(string cookie)
        {
            if (cookie == null)
                return null;

           return userRepository.GetUserByCookies(cookie);
        }

        public void UpdateCookies(User user, string cookie)
        {
            if (user == null || cookie == null)
                throw new NullReferenceException();

            userRepository.UpdateCookies(user, cookie);
        }

        public void UpdateIsActive(User user)
        {
            if (user == null)
                throw new NullReferenceException(nameof(user));

            userRepository.UpdateIsActive(user, user.IsActive);
        }

        public bool IsAlreadyRegister(User user)
        {
            if (user == null)
                throw new NullReferenceException(nameof(user));

            return userRepository.IsAlreadyRegister(user);
        }
    }
}