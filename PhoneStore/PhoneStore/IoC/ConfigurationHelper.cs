﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using PhoneStore.BL.Repository;
using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;
using PhoneStore.BL.Service;

namespace PhoneStore.IoC
{
    public class ConfigurationHelper
    {
        public static void ConfigureDependencies(ConfigurationExpression temp)
        {
            temp.For<IUserRepository<UserEntity>>().Use<EfUserRepository>();
            temp.For<IPhoneRepository<PhoneEntity>>().Use<EfPhoneRepository>();
            temp.For<IImageRepository<ImageEntity>>().Use<EfImageRepository>();
            temp.For<IPhoneManager>().Use<PhoneManager>();
            temp.For<IUserManager>().Use<UserManager>();           
        }
    }
}