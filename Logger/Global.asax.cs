using Autofac;
using Autofac.Integration.Mvc;
using Logger.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Logger
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //autofac自动注入
            var builder = Register();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            var m = new Logger.App_Start.Monitor();
            m.BeginMonitor();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

           
        }

        private ContainerBuilder Register()
        {
            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var AllServices = assemblys
                .SelectMany(s => s.GetTypes())
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType);
            builder.RegisterControllers(assemblys.ToArray()).PropertiesAutowired();
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope().PropertiesAutowired();
            return builder;
        }
    }
}
