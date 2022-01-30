using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Resources;
using XamarinFormsAdvancedTemplate.Services.Interfaces;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Message
{
    public class MessageService : IMessageService
    {
        private readonly IToast _toast;
        private bool _displayingError = false;

        public MessageService(IToast toast)
        {
            _toast = toast;
        }

        public Task<bool> DisplayConfirmationAsync(string dialogName,
            string dialogDesc, string confirmLabel, string denyLabel) =>
            Device.InvokeOnMainThreadAsync(() =>
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert(dialogName, dialogDesc, confirmLabel, denyLabel));

        public Task DisplayErrorDescOnlyAsync(string errorDesc)
        {
            if (_displayingError)
                return Task.CompletedTask;

            _displayingError = true;

            return Device.InvokeOnMainThreadAsync(() =>
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", errorDesc, AppResources.cancel)
                    .ContinueWith(t => _displayingError = false));
        }

        public Task DisplayInfoAsync(string message) =>
            Device.InvokeOnMainThreadAsync(() =>
               Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", message, AppResources.cancel));

        public Task<string> DisplayInputAsync(string title = "",
            string message = "", string inputText = "", string inputPlaceholder = "") =>
                Device.InvokeOnMainThreadAsync(() =>
                    Xamarin.Forms.Application.Current.MainPage.DisplayPromptAsync(title, message,
                        initialValue: inputText, placeholder: inputPlaceholder));

        public void DisplayToast(string info) =>
            Device.BeginInvokeOnMainThread(() => _toast.ShowToast(info));
    }
}