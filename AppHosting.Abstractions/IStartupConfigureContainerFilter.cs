using System;

namespace AppHosting.Abstractions
{
    /// <summary>
    /// This API supports the ASP.NET Core infrastructure and is not intended to be used
    /// directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [Obsolete]
    public interface IStartupConfigureContainerFilter<TContainerBuilder>
    {
        Action<TContainerBuilder> ConfigureContainer(Action<TContainerBuilder> container);
    }
}