using AppHosting.Xamarin.Forms.Abstractions.Interfaces;
using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Builders;
using AppHosting.Xamarin.Forms.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Services.Apple;
using XamarinFormsAdvancedTemplate.Services.Utils.Analytics;
using XamarinFormsAdvancedTemplate.Services.Utils.Application;
using XamarinFormsAdvancedTemplate.Services.Utils.Language;
using XamarinFormsAdvancedTemplate.Services.Utils.Message;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddVisualProcessingCore();

            services
                .AddSingleton<IApplicationService, ApplicationService>()
                .AddSingleton<IApplicationInfrastructureService, ApplicationInfrastructureService>()
                .AddSingleton<IApplicationTrackingService, ApplicationTrackingService<App>>()
                .AddSingleton<IAnalyticsService, AnalyticsService>()
                .AddSingleton<ILanguageService, LanguageService>()
                .AddSingleton<IMessageService, MessageService>()
                .AddSingleton<ISettingsService, SettingsService>()
                .AddSingleton<IAppleService, AppleService>()

                .AddSingleton<AppleViewModel>()

                .AddSingleton<App>()
                .AddSingleton<AppTabbedPage>();
        }

        public void ConfigurePage(IPageBuilder pageProcessing)
        {
            pageProcessing
                .AssignPageAppearing()
                .AssignPageDisappearing();

            pageProcessing.ProcessPageElements();
        }

        public void ConfigureElement(IElementBuilder elementProcessing)
        {
            elementProcessing
                .AssignBindingContext()
                .AssignChildrenBindingContext();

            elementProcessing
                .AssignAttachedAsyncCommands()
                .AssignAttachedCommands()
                .AssignAsyncCommands()
                .AssignCommands();
        }

        /// <summary>
        /// Registers routes for navigation
        /// </summary>
        public void RegisterRoutes()
        {
            //Routes
            Routing.RegisterRoute("appleListPage", typeof(AppleListPage));
            Routing.RegisterRoute("appleDetailPage", typeof(AppleDetailPage));
            Routing.RegisterRoute("otherPage", typeof(OtherPage));
        }
    }
}