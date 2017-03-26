using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.DAL.EF;
using PhoneStore.Models;

namespace PhoneStore.BL.Repository.EF
{
    public class EfUserRepository : IUserRepository<UserEntity>
    {
        public void Add(UserEntity user)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public UserEntity GetUser(Login login)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                return context.Users.FirstOrDefault(e => e.Email == login.Email && e.Password == login.Password);
            }
        }

        public bool IsAlreadyRegister (UserEntity user)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                return context.Users.FirstOrDefault(e => e.Email != user.Email) == null ;
            }
        }

        public UserEntity GetUserByCookies(string cookie)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                return context.Users.FirstOrDefault(e => e.Cookie == cookie);
            }
        }

        public void UpdateCookies(UserEntity user, string cookie)
        {
            if (user != null)
            {
                using (PhoneStoreContext context = new PhoneStoreContext())
                {
                    UserEntity userResult = context.Users.SingleOrDefault(e => e.Cookie == user.Cookie);
                    if (userResult != null)
                    {
                        userResult.Cookie = cookie;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}