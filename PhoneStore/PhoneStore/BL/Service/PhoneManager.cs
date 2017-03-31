using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;

namespace PhoneStore.BL.Service
{
    public class PhoneManager
    {
        EfPhoneRepository phoneRepository = new EfPhoneRepository(); // fix
        EfImageRepository imageRepository = new EfImageRepository(); // fix

        public Phone GetPhone(int id)
        {
            PhoneEntity phoneEntity = new PhoneEntity();
            Phone phone = phoneRepository.GetPhone(id).ConvertToApplicationModel();
            phone.Images = GetImagesForPhone(phone);
            return phone;
        }

        public void Add(Phone phone)
        {
            PhoneEntity phoneEntity = new PhoneEntity();
            phoneEntity = (PhoneEntity)phoneEntity.FromApplicationModel(phone);
            phoneRepository.Add(phoneEntity);
        }

        public void AddImage(Image image)
        {
            ImageEntity imageEntity = new ImageEntity();
            imageEntity = (ImageEntity)imageEntity.FromApplicationModel(image);
            imageRepository.Add(imageEntity);
        }

        public List<string> GetImagesForPhone(Phone phone)
        {
            if (phone != null)
            {
                List<string> images = new List<string>();
                List<ImageEntity> imageEntity = imageRepository.GetImagesForPhone(phone);
                foreach (ImageEntity i in imageEntity)
                {
                    images.Add(i.Image);
                }
                return images;
            }
            return null;
        }

        public List<Phone> GetPhones(int from, int to)
        {
            if (from > 0 && to >= from)
            {
                List<Phone> phones = new List<Phone>();
                List<PhoneEntity> entityPhones = phoneRepository.GetPhones(from, to);
                foreach (PhoneEntity phone in entityPhones)
                {
                    var tempPhone = phone.ConvertToApplicationModel();
                    var tempImg = GetImagesForPhone(tempPhone);
                    if (tempImg != null)
                    {
                        tempPhone.Images = tempImg;
                    }                    
                    phones.Add(tempPhone);
                }
                return phones;
            }                
            else
                return null;
        }

    }
}