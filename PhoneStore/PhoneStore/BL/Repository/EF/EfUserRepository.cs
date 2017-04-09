using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.DAL.EF;
using PhoneStore.Models;
using System.Data.Entity.Validation;

namespace PhoneStore.BL.Repository.EF
{
    public class EfUserRepository : IUserRepository
    {
        public void Add(User user)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                UserEntity userEntity = (UserEntity)new UserEntity().FromApplicationModel(user);
                context.Users.Add(userEntity);
                    context.SaveChanges();
            }
        }

        public User GetUser(Login login)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                UserEntity userEntity = context.Users.FirstOrDefault(e => e.Email == login.Email && e.Password == login.Password);

                return userEntity != null ? userEntity.ConvertToApplicationModel() : null;
            }
        }

        public bool IsAlreadyRegister (User user)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                return context.Users.SingleOrDefault(e => e.Email == user.Email) == null ;
            }
        }

        public User GetUserByCookies(string cookie)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                UserEntity userEntity = context.Users.FirstOrDefault(e => e.Cookie == cookie);

                return userEntity != null ? userEntity.ConvertToApplicationModel() : null;
            }
        }

        public void UpdateIsActive(User user, bool value)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                UserEntity userResult = context.Users.SingleOrDefault(e => e.Cookie == user.Cookie);
                if (userResult != null)
                {
                    userResult.IsActive = value;
                    context.SaveChanges();
                }
            }
        }

        public void UpdateCookies(User user, string cookie)
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