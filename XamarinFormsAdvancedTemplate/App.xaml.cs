using AppHosting.Abstractions.Internal;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using XamarinFormsAdvancedTemplate.Services.Utils.App;
using XamarinFormsAdvancedTemplate.Views.Tabbed;
using Application = Xamarin.Forms.Application;

namespace XamarinFormsAdvancedTemplate
{
    public partial class App : Application
    {
        private readonly IApplicationService _application;
        private readonly IAppHostLifetime _appHostLifetime;

        public App(IApplicationService application,
                   IAppHostLifetime appHostLifetime)
        {

            _application = application;
            _appHostLifetime = appHostLifetime;

            InitApp();
        }

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

            _application.InitializeApplication<AppTabbedPage>();
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
    }
}