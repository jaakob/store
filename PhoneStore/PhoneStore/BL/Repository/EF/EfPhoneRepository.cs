using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.DAL.EF;

namespace PhoneStore.BL.Repository.EF
{
    public class EfPhoneRepository : IPhoneRepository
    {
        public void Add(Phone phone)
        {
           using (PhoneStoreContext context = new PhoneStoreContext())
            {
                PhoneEntity phoneEntity = (PhoneEntity)new PhoneEntity().FromApplicationModel(phone);
                context.Phones.Add(phoneEntity);
                context.SaveChanges();
            }
        }



        public IEnumerable<Phone> GetAllPhones()
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                IEnumerable<PhoneEntity> listPhonesEntity = context.Phones.Include("Images");

                return listPhonesEntity.Count() == 0 ? null : listPhonesEntity.Select(e => e.ConvertToApplicationModel()).ToList();
            }
        }

        public int GetPhoneId(Phone phone)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                return context.Phones.FirstOrDefault(e => e.Model == phone.Model).PhoneId;
            }
        }
    }
}