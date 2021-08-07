using AppHosting.Abstractions.Internal;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using XamarinFormsAdvancedTemplate.Services.Utils.Analytics;
using XamarinFormsAdvancedTemplate.Services.Utils.Language;
using XamarinFormsAdvancedTemplate.Services.Utils.Navigation;
using XamarinFormsAdvancedTemplate.Views.Shell;
using Application = Xamarin.Forms.Application;

namespace XamarinFormsAdvancedTemplate
{
    public partial class App : Application
    {
        #region Fields
        private readonly ILanguageService _language;
        private readonly INavigationService _navigation;
        private readonly IAnalyticsService _analytics;
        private readonly IAppHostLifetime _appHostLifetime;
        #endregion

        #region Constructor
        public App(ILanguageService language,
                   INavigationService navigation,
                   IAnalyticsService analytics,
                   IAppHostLifetime appHostLifetime)
        {

            _language = language;
            _navigation = navigation;
            _analytics = analytics;
            _appHostLifetime = appHostLifetime;

            InitApp();
        }
        #endregion

        #region Methods
        private void InitApp()
        {
            InitializeComponent();
            Current
                .On<Android>()
                .UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }

        protected override void OnStart()
        {
            base.OnStart();

            _language.DetermineAndSetLanguage();
            _navigation.DetermineAndSetMainPage<AppShell>();
            _analytics.TrackEvent("App started.");
        }

        protected override void OnResume()
        {
            _appHostLifetime.NotifyResuming();
            base.OnResume();
        }

        protected override void OnSleep()
        {
            _appHostLifetime.NotifySleeping();
            base.OnSleep();
        }
        #endregion
    }
}