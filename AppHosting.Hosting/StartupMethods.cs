using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;

namespace AppHosting.Hosting
{
    internal class StartupMethods
    {
        public object StartupInstance { get; }

        public Func<IServiceCollection, IServiceProvider> ConfigureServicesDelegate { get; }

        public Action RegisterRoutesDelegate { get; }

        public StartupMethods(
            object instance,
            Action registerRoutes,
            Func<IServiceCollection, IServiceProvider> configureServices)
        {
            Debug.Assert(configureServices != null);

            StartupInstance = instance;
            RegisterRoutesDelegate = registerRoutes;
            ConfigureServicesDelegate = configureServices;
        }
    }
}