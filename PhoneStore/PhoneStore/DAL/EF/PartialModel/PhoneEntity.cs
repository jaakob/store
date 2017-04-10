using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Service;

namespace PhoneStore.DAL.EF
{
    public partial class PhoneEntity
    {
        public Phone ConvertToApplicationModel()
        {
            Phone phone = new Phone
            {
                PhoneId = this.PhoneId,
                Model = this.Model,
                Brand = this.Brand,
                Description = this.Description,
                Price = this.Price,
                UserId = this.UserId,
            };

            if (Images.Count != 0)
            {
                foreach (var i in Images)
                {
                    phone.Images.Value.Add(i.ConvertToApplicationModel());
                }
            }

            return phone;
        }

        public IStorageModel<Phone> FromApplicationModel(Phone model)
        {
            if (model == null)
                return null;

            PhoneEntity phoneEntity = new PhoneEntity
            {
                Model = model.Model,
                Brand = model.Brand,
                Description = model.Description,
                Price = model.Price,
                UserId = model.UserId
            };

            return phoneEntity;
        }
    }
}