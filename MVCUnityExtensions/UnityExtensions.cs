using Microsoft.Practices.Unity;

namespace MVCUnityExtensions
{
    public static class UnityExtensions
    {
        public static IUnityContainer RegisterType<TFrom, TTo>(this IUnityContainer container)
            where TTo : TFrom
        {
            return container.RegisterType(typeof(TFrom), typeof(TTo));
        }
        public static IUnityContainer RegisterType<TFrom, TTo>(this IUnityContainer container, string name)
            where TTo : TFrom
        {
            return container.RegisterType(typeof(TFrom), typeof(TTo), name);
        }
    }
}
