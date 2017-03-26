using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using PhoneStore.BL.Repository;
using PhoneStore.BL.Repository.EF;
using PhoneStore.DAL.EF;

namespace PhoneStore.IoC
{
    public class ConfigurationHelper
    {
        public static void ConfigureDependies(ConfigurationExpression temp)
        {
            temp.For<IUserRepository<UserEntity>>().Use<EfUserRepository>();
        }
    }
}