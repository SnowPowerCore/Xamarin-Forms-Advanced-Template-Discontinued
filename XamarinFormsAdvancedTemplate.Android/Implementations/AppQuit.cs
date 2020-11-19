using Android.App;
using XamarinFormsAdvancedTemplate.Services.Interfaces;

namespace XamarinFormsAdvancedTemplate.Android.Implementations
{
    public class AppQuit : IAppQuit
    {
        public void Quit()
        {
            ((Activity)Xamarin.Forms.Forms.Context).FinishAffinity();
        }
    }
}