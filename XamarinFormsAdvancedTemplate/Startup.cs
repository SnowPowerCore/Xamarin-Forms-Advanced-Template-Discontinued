using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Services.Utils.Analytics;
using XamarinFormsAdvancedTemplate.Services.Utils.Language;
using XamarinFormsAdvancedTemplate.Services.Utils.Message;
using XamarinFormsAdvancedTemplate.Services.Utils.Navigation;
using XamarinFormsAdvancedTemplate.Services.Utils.Processors;
using XamarinFormsAdvancedTemplate.Services.Utils.Settings;
using XamarinFormsAdvancedTemplate.ViewModels;
using XamarinFormsAdvancedTemplate.Views.Pages;
using XamarinFormsAdvancedTemplate.Views.Shell;

namespace XamarinFormsAdvancedTemplate
{
    /// <summary>
    /// We create application and all deps throughout this class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Crossplatform services configuration
        /// </summary>
        /// <param name="services">Services collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            #region Services
            services
                .AddSingleton<IAnalyticsService, AnalyticsService>()
                .AddSingleton<ILanguageService, LanguageService>()
                .AddSingleton<IMessageService, MessageService>()
                .AddSingleton<INavigationService, ShellNavigationService>()
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
                .AddSingleton<AppShell>();
            #endregion
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