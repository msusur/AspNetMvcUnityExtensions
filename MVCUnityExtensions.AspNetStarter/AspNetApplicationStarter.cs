using System.Web;
using Cronom.WebServer.ModularityUI.Modules.AspNetModuleHost;
using MVCUnityExtensions;

[assembly: PreApplicationStartMethod(typeof(AspNetApplicationStarter), "Start")]


namespace Cronom.WebServer.ModularityUI.Modules.AspNetModuleHost
{
    /// <summary>
    /// Initializes the application when the Asp.Net Host started.
    /// </summary>
    public class AspNetApplicationStarter
    {
        private static bool _applicationInitialized;
        private static readonly object SyncRoot = new object();

        private static readonly ApplicationLifeManager LifeManager
            = new ApplicationLifeManager(OnApplicationShutdown, OnApplicationStart);

        private static readonly DependencyInitializer Initializer = new DependencyInitializer();

        /// <summary>
        /// Starts the application. This method executes by the <see cref="PreApplicationStartMethodAttribute"/>.
        /// </summary>
        public static void Start()
        {
            if (_applicationInitialized) return;
            lock (SyncRoot)
            {
                if (_applicationInitialized) return;
                LifeManager.InitializeManager();
                _applicationInitialized = true;
            }
        }

        private static void OnApplicationStart()
        {
            Initializer.Begin();
            
        }

        private static void OnApplicationShutdown()
        {
            Initializer.End();
        }
    }
}