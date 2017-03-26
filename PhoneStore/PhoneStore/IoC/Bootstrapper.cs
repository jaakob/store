using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using System.Web.Mvc;

namespace PhoneStore.IoC
{
    public class Bootstrapper
    {
        public static void ConfigureStructureMap(Action<ConfigurationExpression> configurationAction)
        {
            IContainer container = new Container(configurationAction);
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
        }
    }
}