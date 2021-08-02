using Microsoft.Extensions.DependencyInjection;
using System;

namespace AppHosting.Abstractions
{
    public interface IAppStartup
    {
        IServiceProvider ConfigureServices(IServiceCollection services);

        void RegisterRoutes();
    }
}