using PhoneStore.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore.BL.Repository.EF
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository(User user, PhoneStoreEntities ps)
        {
            ps.Users.Add(user);
            ps.SaveChanges();
        }
    }
}