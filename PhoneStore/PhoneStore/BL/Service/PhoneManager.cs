using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;
using PhoneStore.BL.Repository;

namespace PhoneStore.BL.Service
{
    public class PhoneManager : IPhoneManager
    {
        private IPhoneRepository<PhoneEntity> phoneRepository;
        private IImageRepository<ImageEntity> imageRepository;      
        
        public PhoneManager(IPhoneRepository<PhoneEntity> phoneRepository, IImageRepository<ImageEntity> imageRepository)
        {
            this.phoneRepository = phoneRepository;
            this.imageRepository = imageRepository;
        }
        
        public Phone GetPhone(int id)
        {
            PhoneEntity phoneEntity = new PhoneEntity();
            Phone phone = phoneRepository.GetPhone(id).ConvertToApplicationModel();
            phone.Images = GetImagesForPhone(phone);
            return phone;
        }
        
        public int GetPhoneId(Phone phone)
        {
            if (phone != null)
            {
                PhoneEntity phoneEntity = new PhoneEntity();
                phoneEntity = (PhoneEntity)phoneEntity.FromApplicationModel(phone);
                return phoneRepository.GetPhoneId(phoneEntity);
            }
            return 0;
        }


        public List<Phone> FindPhones(string searchString)
        {
            if (searchString != null)
            {
                List<Phone> phones = new List<Phone>();
                List<PhoneEntity> entityPhones = phoneRepository.FindPhones(searchString);
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
            return null;
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
            /*
            PhoneEntity phoneEntity = new PhoneEntity();
            phoneEntity.PhoneId = 1;
            ICollection<ImageEntity> s = phoneEntity.Images.Where(e => e.PhoneId == 1).ToList();
            */
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