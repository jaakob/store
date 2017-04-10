using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.BL.Repository.EF;
using PhoneStore.Models;

namespace PhoneStore.BL.Service
{
    public class PhoneManager : IPhoneManager
    {
        private IPhoneRepository repository;

        public PhoneManager (IPhoneRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Phone> GetAllPhones()
        {
            IEnumerable<Phone> phones =  repository.GetAllPhones();
            return phones;
        }

        public void Add(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException(nameof(phone));

            repository.Add(phone);
        }

        public int GetPhoneId(Phone phone)
        {
            if (phone == null)
                throw new ArgumentNullException(nameof(phone));

            return repository.GetPhoneId(phone);
        }
    }
}