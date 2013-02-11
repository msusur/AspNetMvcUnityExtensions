using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

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
        }

        public void End()
        {
            throw new NotImplementedException();
        }
    }
}
