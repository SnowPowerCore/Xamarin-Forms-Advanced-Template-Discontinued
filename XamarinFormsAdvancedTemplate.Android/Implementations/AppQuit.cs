using Android.App;
using $ext_safeprojectname$.Services.Interfaces;

namespace XamarinFormsAdvancedTemplate.Droid.Implementations
{
    public class AppQuit : IAppQuit
    {
        public void Quit()
        {
            ((Activity)Xamarin.Forms.Forms.Context).FinishAffinity();
        }
    }
}