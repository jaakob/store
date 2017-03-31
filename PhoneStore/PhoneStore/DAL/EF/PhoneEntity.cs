//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneStore.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using PhoneStore.Models;
    using PhoneStore.BL.Service;

    public partial class PhoneEntity : IStorageModel<Phone>
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhoneEntity()
        {
            this.Images = new HashSet<ImageEntity>();
        }
    
        public int PhoneId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageEntity> Images { get; set; }
        public virtual UserEntity Users { get; set; }

        public virtual ICollection<PhoneEntity> Phones { get; set; }

        public Phone ConvertToApplicationModel()
        {
            Phone phone = new Phone()
            {
                PhoneId = this.PhoneId,                
                Model = this.Model,
                Brand = this.Brand,
                Description = this.Description,
                Price = this.Price,
                UserId = this.UserId,
                //Images = (HashSet<Image>)this.Images // ???
            };
            return phone;
        }

        public IStorageModel<Phone> FromApplicationModel(Phone model)
        {
            if (model == null)
                return null;
            PhoneEntity phoneEntity = new PhoneEntity()
            {
                PhoneId = model.PhoneId,
                Model = model.Model,
                Brand = model.Brand,
                Description = model.Description,
                Price = model.Price,
                UserId = model.UserId,
            };
            return phoneEntity;
        }
    }
}
