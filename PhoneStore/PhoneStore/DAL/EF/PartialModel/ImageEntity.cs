using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models;
using PhoneStore.BL.Service;

namespace PhoneStore.DAL.EF
{
    public partial class ImageEntity
    {
        public ApplicationImage ConvertToApplicationModel()
        {
            ApplicationImage appImage = new ApplicationImage
            {
                ImageId = this.ImageId,
                Image = this.Image,
                PhoneId = this.PhoneId
            };

            return appImage;
        }

        public IStorageModel<ApplicationImage> FromApplicationModel(ApplicationImage model)
        {
            if (model == null)
                return null;

            ImageEntity imageEntity = new ImageEntity()
            {
                Image = model.Image,
                PhoneId = model.PhoneId
            };

            return imageEntity;
        }
    }
}