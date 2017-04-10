using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.DAL.EF;

namespace PhoneStore.BL.Repository.EF
{
    public class EfImageRepository : IImageRepository
    {
        public void Add(ApplicationImage image)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                ImageEntity imageEntity = (ImageEntity)new ImageEntity().FromApplicationModel(image);
                context.Images.Add(imageEntity);
                context.SaveChanges();
            }
        }
    }
}