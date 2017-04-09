using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Repository;
using PhoneStore.BL.Repository.EF;

namespace PhoneStore.BL.Service.Image
{
    public class ImageManager : IImageManager
    {
        private IImageRepository repository;

        public ImageManager(IImageRepository repository)
        {
            this.repository = repository;
        }

        public void Add(ApplicationImage image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            repository.Add(image);
        }
    }
}