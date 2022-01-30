using Android.App;
using Android.Content.PM;
using Android.OS;
using AppHosting.Abstractions.Interfaces;
using AppHosting.Hosting;
using AppHosting.Xamarin.Forms.Extensions;
using Microsoft.Extensions.DependencyInjection;
using XamarinFormsAdvancedTemplate.Android.Implementations;
using XamarinFormsAdvancedTemplate.Services.Interfaces;
using AGlide = Android.Glide;

namespace XamarinFormsAdvancedTemplate.Android
{
    [Activity(Label = "App", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            AGlide.Forms.Init(this);
            XamEffects.Droid.Effects.Init();
            Rg.Plugins.Popup.Popup.Init(this);

            var appHost = CreateMobileHostBuilder().Build();
            LoadApplication(
                await appHost.StartAsync<App>().ConfigureAwait(false));
        }

        public IAppHostBuilder CreateMobileHostBuilder() =>
            AppHost
                .CreateDefaultAppBuilder<Startup>(default)
                .ConfigureServices(ConfigureNativeServices)
                .UseAppVisualProcessor()
                .UseLegacyTabbedNavigation();

        private void ConfigureNativeServices(IServiceCollection services)
        {
            services.AddSingleton<ILocalizeService, LocalizeService>();
            services.AddSingleton<IAppQuit, AppQuit>();
            services.AddSingleton<IToast, Toast>();
            services.AddSingleton<IKeyboard, Keyboard>();
        }

        public override void OnBackPressed() =>
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
    }
}