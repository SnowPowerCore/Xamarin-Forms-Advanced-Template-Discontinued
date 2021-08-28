using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Services.Navigation;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Services.Utils.Analytics;
using XamarinFormsAdvancedTemplate.Services.Utils.Language;

namespace XamarinFormsAdvancedTemplate.Services.Utils.App
{
    public class ApplicationService : IApplicationService
    {
        private readonly ILanguageService _language;
        private readonly INavigationService _navigation;
        private readonly IAnalyticsService _analytics;

        public ApplicationService(ILanguageService language,
                                  INavigationService navigation,
                                  IAnalyticsService analytics)
        {
            _language = language;
            _navigation = navigation;
            _analytics = analytics;
        }

        public void InitializeApplication<TInitPage>() where TInitPage : Page
        {
            _language.DetermineAndSetLanguage();
            _navigation.DetermineAndSetMainPage<TInitPage>();
            _analytics.TrackEvent("App started.");
        }
    }
}