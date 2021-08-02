using Microsoft.Extensions.DependencyInjection;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Controls;
using XamarinFormsAdvancedTemplate.Extensions;
using XamarinFormsAdvancedTemplate.Services.Utils.Processors;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Navigation
{
    public class ShellNavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IShellProcessor _shellProcessor;
        private readonly IPageProcessor _pageProcessor;

        public ShellNavigationService(IServiceProvider serviceProvider,
                                      IShellProcessor shellProcessor,
                                      IPageProcessor pageProcessor)
        {
            _serviceProvider = serviceProvider;
            _shellProcessor = shellProcessor;
            _pageProcessor = pageProcessor;
        }

        public Task SwitchMainPageAsync<TPage>(TPage page) where TPage : Page
        {
            if (page is Shell shell)
            {
                Shell.Current.FlyoutIsPresented = false;
                var updatedShell = _shellProcessor.AssignShellData(shell);
                return CloseModalAsync()
                    .ContinueWith(t =>
                        Device.InvokeOnMainThreadAsync(() => Application.Current.MainPage = shell),
                            TaskContinuationOptions.OnlyOnRanToCompletion);
            }

            return Task.CompletedTask;
        }

        public void DetermineAndSetMainPage<TPage>() where TPage : Page
        {
            var shell = _serviceProvider.GetService<TPage>() as HostedShell;
            var updatedShell = _shellProcessor.AssignShellData(shell);
            Application.Current.MainPage = updatedShell;
        }

        public Task OpenModalAsync(Page modal, bool animated = true)
        {
            var updatedModal = _pageProcessor.AssignPageData(modal);
            return Device.InvokeOnMainThreadAsync(
                () => Shell.Current.Navigation.PushModalAsync(updatedModal, animated));
        }

        public Task CloseModalAsync(bool animated = true) =>
            Shell.Current.Navigation.ModalStack.Count > 0
                ? Device.InvokeOnMainThreadAsync(
                    () => Shell.Current.Navigation.PopModalAsync(animated))
                : Task.CompletedTask;

        public Task OpenPopupAsync(string routeWithParams, bool animated = true)
        {
            var popupPage = routeWithParams.GetElementFromRouting<PopupPage>();
            var updatedPopupPage = _pageProcessor.AssignPageData(popupPage);
            return Device.InvokeOnMainThreadAsync(
                () => PopupNavigation.Instance.PushAsync(updatedPopupPage, animated));
        }

        public Task ClosePopupAsync(bool animated = true) =>
            PopupNavigation.Instance.PopupStack.Count > 0
                ? Device.InvokeOnMainThreadAsync(
                    () => PopupNavigation.Instance.PopAsync(animated))
                : Task.CompletedTask;

        public Task NavigateToPageAsync(string routeWithParams, bool animated = true)
        {
            Shell.Current.FlyoutIsPresented = false;
            var page = routeWithParams.GetElementFromRouting<Page>();
            var updatedPage = _pageProcessor.AssignPageData(page);
            return Device.InvokeOnMainThreadAsync(
                () => Shell.Current.Navigation.PushAsync(updatedPage, animated));
        }

        public Task NavigateBackAsync(bool animated = true) =>
            Shell.Current.Navigation.NavigationStack.Count > 1
                ? Device.InvokeOnMainThreadAsync(
                    () => Shell.Current.Navigation.PopAsync(animated))
                : Task.CompletedTask;

        public Task NavigateToRootAsync(bool animated = true)
        {
            Shell.Current.FlyoutIsPresented = false;
            return Device.InvokeOnMainThreadAsync(
                () => Shell.Current.Navigation.PopToRootAsync(animated));
        }

        public Task SwitchItemAsync(int index) =>
            Device.InvokeOnMainThreadAsync(
                () => Shell.Current.CurrentItem = Shell.Current.Items.ElementAtOrDefault(index));
    }
}