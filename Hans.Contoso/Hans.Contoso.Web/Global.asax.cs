using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Hans.Contoso.Core;
using Hans.Contoso.Core.Domains;
using Hans.Contoso.Core.Persistence;
using Hans.Contoso.Core.Utils;
using Hans.MvcKnockout.Core.Commons;
using NHibernate;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hans.Contoso.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BuildContainer();
        }

        private void BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register ISessionFactory as Singleton 
            builder.Register(x => new PersistentConfiguration().Initialize()).SingleInstance();
            // register ISession as instance per web request
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerRequest();
            // register controllers
            builder.RegisterControllers(Assembly.Load(AssemblyType.Web)).PropertiesAutowired();
            // register apis
            builder.RegisterApiControllers(Assembly.Load(AssemblyType.Web)).PropertiesAutowired();
            // register repositories
            builder.RegisterType<Repository<Customer>>().As<IRepository<Customer>>();

            // register services
            //builder.RegisterType<CurrentUserService>().As<ICurrentUserService>();

            //builder.RegisterType<HomeController>().OnActivated(x => x.Instance.DinnerRepository = x.Context.Resolve<IRepository<Dinner>>());
            //builder.RegisterType<HomeController>().OnActivated(x => x.Instance.CurrentUserService = x.Context.Resolve<ICurrentUserService>());

            // sets up all API and regular controllers while injecting all the properties
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // override default dependency resolver to use Autofac
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
