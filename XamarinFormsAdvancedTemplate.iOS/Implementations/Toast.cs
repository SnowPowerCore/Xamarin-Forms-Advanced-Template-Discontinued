using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormsAdvancedTemplate.iOS.Controls;
using XamarinFormsAdvancedTemplate.Services.Interfaces;

namespace XamarinFormsAdvancedTemplate.iOS.Implementations
{
    public class Toast : IToast
    {
        public void ShowToast(string message) =>
            Device.InvokeOnMainThreadAsync(() =>
            {
                var snackbar = new SnackBar
                {
                    Message = message,
                    LeftMargin = 25f,
                    RightMargin = 25f,
                    BottomMargin = 25f,
                    BackgroundColor = Color.Gray.ToUIColor(),
                    Duration = TimeSpan.FromSeconds(3),
                    AnimationType = SnackbarAnimationType.FadeInFadeOut
                };
                snackbar.Show();
            });
    }
}