using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WebApiInterface.Models;
using Microsoft.Practices.ServiceLocation;

namespace WebApiInterface
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IFoo, Foo>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            //Used by json .net to find the type, this allows us to use interfaces in our action methods
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IocCustomCreationConverter<IActionParameter>());

            var locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}