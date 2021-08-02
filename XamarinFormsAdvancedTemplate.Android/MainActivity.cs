using Android.App;
using Android.Content.PM;
using Android.OS;
using AppHosting.Abstractions;
using AppHosting.Hosting;
using AppHosting.Hosting.Extensions;
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
                .CreateDefaultAppBuilder(default)
                .ConfigureServices(ConfigureNativeServices)
                .UseStartup<Startup>();

        private void ConfigureNativeServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILocalizeService), typeof(LocalizeService));
            services.AddSingleton(typeof(IAppQuit), typeof(AppQuit));
            services.AddSingleton(typeof(IToast), typeof(Toast));
            services.AddSingleton(typeof(IKeyboard), typeof(Keyboard));
        }

        public override void OnBackPressed() =>
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
    }
}