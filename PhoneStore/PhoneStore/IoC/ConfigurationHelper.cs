using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using PhoneStore.BL.Repository;
using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;
using PhoneStore.BL.Service;
using PhoneStore.BL.Service.Image;


namespace PhoneStore.IoC
{
    public class ConfigurationHelper
    {
        public static void ConfigureDependies(ConfigurationExpression temp)
        {
            temp.For<IUserRepository>().Use<EfUserRepository>();
            temp.For<IUserManager>().Use<UserManager>();
            temp.For<IPhoneManager>().Use<PhoneManager>();
            temp.For<IPhoneRepository>().Use<EfPhoneRepository>();
            temp.For<IImageRepository>().Use<EfImageRepository>();
            temp.For<IImageManager>().Use<ImageManager>();
        }
    }
}