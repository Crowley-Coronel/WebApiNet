//using BusinessServices;
using Resolver;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
//using Unity.WebApi;

namespace AplicacionWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            ComponentLoader.LoadContainer(container, ".\\bin", "WebPrueba.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "BussinessServices.dll");

            //container.RegisterType<IProductServices, ProductServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            // DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

        }
    }
}