using AppHosting.Abstractions;
using AppHosting.Hosting;
using AppHosting.Hosting.Extensions;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using UIKit;
using XamarinFormsAdvancedTemplate.iOS.Implementations;
using XamarinFormsAdvancedTemplate.Services.Interfaces;

namespace XamarinFormsAdvancedTemplate.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();
            Xamarin.Forms.Nuke.FormsHandler.Init();
            Rg.Plugins.Popup.Popup.Init();
            XamEffects.iOS.Effects.Init();

            var appHost = CreateMobileHostBuilder().Build();
            LoadApplication(appHost.Start<App>());
            return base.FinishedLaunching(app, options);
        }

        public IAppHostBuilder CreateMobileHostBuilder() =>
            AppHost
                .CreateDefaultAppBuilder(null)
                .ConfigureServices(ConfigureNativeServices)
                .UseStartup<Startup>();

        private void ConfigureNativeServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILocalizeService), typeof(LocalizeService));
            services.AddSingleton(typeof(IAppQuit), typeof(AppQuit));
            services.AddSingleton(typeof(IToast), typeof(Toast));
            services.AddSingleton(typeof(IKeyboard), typeof(Keyboard));
        }
    }
}