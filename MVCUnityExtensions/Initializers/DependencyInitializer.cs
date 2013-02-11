using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

namespace MVCUnityExtensions
{
    public class DependencyInitializer
    {
        private static readonly Lazy<IUnityContainer> Lazycontainer =
            new Lazy<IUnityContainer>(() => new UnityContainer(), true);

        public static IUnityContainer CurrentContainer
        {
            get { return Lazycontainer.Value; }
        }

        public void Begin()
        {
            DependencyResolver.SetResolver(new UnityDependencyResolver(CurrentContainer));
            DynamicModuleUtility.RegisterModule(typeof(RequestLifetimeHttpModule));
        }

        public void End()
        {
            throw new NotImplementedException();
        }
    }
}
