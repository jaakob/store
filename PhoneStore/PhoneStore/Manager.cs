using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;
using PhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore
{
    public class Manager
    {
        public Manager(UserApp data)
        {
            PhoneStoreEntities ps = new PhoneStoreEntities();
            User user = new User()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Password = data.Password,
                Email = data.Email,
                RegDate = DateTime.Now.Date,
                IsActive = false,
                Cookies = "aaa"
            };

            UsersRepository usrep = new UsersRepository(user, ps);
            
        }
    }
}