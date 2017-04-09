using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Service;

namespace PhoneStore.DAL.EF
{
    public partial class UserEntity
    {
        public User ConvertToApplicationModel()
        {
            User user = new User()
            {
                UserId = this.UserId,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Password = this.Password,
                Email = this.Email,
                ContactPhone = this.ContactPhone,
                IsActive = this.IsActive,
                Cookie = this.Cookie,
                RegDate = this.RegDate
            };

            return user;
        }

        public IStorageModel<User> FromApplicationModel(User model)
        {
            if (model == null)
                return null;
            UserEntity userEntity = new UserEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Email = model.Email,
                ContactPhone = model.ContactPhone,
                IsActive = model.IsActive,
                Cookie = model.Cookie,
                RegDate = model.RegDate
            };

            return userEntity;
        }
    }
}