using Android.Widget;
using Xamarin.Forms;
using $ext_safeprojectname$.Services.Interfaces;
using Application = Android.App.Application;
using AToast = Android.Widget.Toast;

namespace XamarinFormsAdvancedTemplate.Droid.Implementations
{
    public class Toast : IToast
    {
        public void ShowToast(string message) =>
            Device.InvokeOnMainThreadAsync(() =>
                AToast.MakeText(Application.Context, message, ToastLength.Short).Show());
    }
}