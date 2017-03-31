using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.DAL.EF;
using PhoneStore.Models;

namespace PhoneStore.BL.Repository.EF
{
    public class EfImageRepository
    {
        public ImageEntity GetImage(int id)
        {

                return null;
        }

        public List<ImageEntity> GetImagesForPhone(Phone phone)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                if (phone != null)
                {
                    IEnumerable<ImageEntity> images = context.Images.Where(i => i.PhoneId == phone.PhoneId);
                    return images.ToList();
                }
                //return context.Images.Where(i => i.PhoneId == phone.PhoneId).ToList();
                return null;
            }            
        }

        public void Add(ImageEntity image)
        {
            using (PhoneStoreContext context = new PhoneStoreContext())
            {
                context.Images.Add(image);
                context.SaveChanges();
            }
        }
    }
}