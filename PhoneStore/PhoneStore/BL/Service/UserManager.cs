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
    public class UserManager
    {
        EfUserRepository userRepository = new EfUserRepository(); // fix

        public void Add(User user)
        {
            UserEntity userEntity = new UserEntity();
            userEntity = (UserEntity)userEntity.FromApplicationModel(user);
            userRepository.Add(userEntity);
        }

        public User GetUser(Login login)
        {
            UserEntity userEntity = userRepository.GetUser(login);
            
            if (userEntity == null)
                return null;

            return userEntity.ConvertToApplicationModel();
        }

        public User GetUserByCookies(string cookie)
        {
            UserEntity userEntity = userRepository.GetUserByCookies(cookie);

            if (userEntity == null)
                return null;

            return userEntity.ConvertToApplicationModel();
        }

        public void UpdateCookies(User user, string cookie)
        {
            UserEntity userEntity = new UserEntity();
            userEntity = (UserEntity)userEntity.FromApplicationModel(user);
            userRepository.UpdateCookies(userEntity, cookie);
        }

        public void MakeActive(User user)
        {
            UserEntity userEntity = new UserEntity();
            userEntity = (UserEntity)userEntity.FromApplicationModel(user);
            userRepository.MakeActive(userEntity);
        }

        public bool IsAlreadyRegister(User user)
        {
            UserEntity userEtity = new UserEntity();
            userEtity = (UserEntity)userEtity.FromApplicationModel(user);
            return userRepository.IsAlreadyRegister(userEtity);
        }
    }
}