using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.DAL.EF;

namespace PhoneStore.BL.Repository.EF
{
    public class EfPhoneRepository : IPhoneRepository<PhoneEntity>
    {
        public PhoneEntity GetPhone(int id)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
                return context.Phones.SingleOrDefault(e => e.PhoneId == id);                
        }

        public List<PhoneEntity> GetPhones(int fromId, int toId)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                var phones = from p in context.Phones
                             where p.PhoneId >= fromId
                             where p.PhoneId <= toId
                             select p;
                return phones.ToList();
            }
        }

        public void Add(PhoneEntity phone)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                context.Phones.Add(phone);
                context.SaveChanges();
            }
        }
    }
}