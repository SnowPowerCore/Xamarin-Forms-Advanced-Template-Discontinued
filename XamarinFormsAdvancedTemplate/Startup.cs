using AppHosting.Abstractions.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Services.Utils.Analytics;
using XamarinFormsAdvancedTemplate.Services.Utils.App;
using XamarinFormsAdvancedTemplate.Services.Utils.Language;
using XamarinFormsAdvancedTemplate.Services.Utils.Message;
using XamarinFormsAdvancedTemplate.Services.Utils.Navigation;
using XamarinFormsAdvancedTemplate.Services.Utils.Processors;
using XamarinFormsAdvancedTemplate.Services.Utils.Settings;
using XamarinFormsAdvancedTemplate.ViewModels;
using XamarinFormsAdvancedTemplate.Views.Pages;
using XamarinFormsAdvancedTemplate.Views.Tabbed;

namespace XamarinFormsAdvancedTemplate
{
    /// <summary>
    /// We create application and all deps throughout this class
    /// </summary>
    public class Startup : IAppStartup
    {
        /// <summary>
        /// Cross-platform services configuration
        /// </summary>
        /// <param name="services">Services collection</param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            #region Services
            services
                .AddSingleton<IApplicationService, ApplicationService>()
                .AddSingleton<IAnalyticsService, AnalyticsService>()
                .AddSingleton<ILanguageService, LanguageService>()
                .AddSingleton<IMessageService, MessageService>()
                .AddSingleton<INavigationService, LegacyTabbedNavigationService>()
                .AddSingleton<IElementProcessor, ElementProcessor>()
                .AddSingleton<IShellProcessor, ShellProcessor>()
                .AddSingleton<IPageProcessor, PageProcessor>()
                .AddSingleton<ISettingsService, SettingsService>()
            #endregion

            #region ViewModels
                .AddSingleton<WelcomeViewModel>()
            #endregion

            #region Application
                .AddSingleton<App>()
                .AddSingleton<AppTabbedPage>();
            #endregion

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Registers routes for navigation
        /// </summary>
        public void RegisterRoutes()
        {
            //Routes
            Routing.RegisterRoute("welcomePage", typeof(WelcomePage));
            Routing.RegisterRoute("otherPage", typeof(OtherPage));
        }
    }
}