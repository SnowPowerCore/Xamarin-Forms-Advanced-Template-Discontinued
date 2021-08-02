using Microsoft.Extensions.DependencyInjection;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Extensions;
using XamarinFormsAdvancedTemplate.Services.Utils.Processors;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Navigation
{
    public class LegacyTabbedNavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPageProcessor _pageProcessor;

        public LegacyTabbedNavigationService(IServiceProvider serviceProvider,
                                             IPageProcessor pageProcessor)
        {
            _serviceProvider = serviceProvider;
            _pageProcessor = pageProcessor;
        }

        public Task SwitchMainPageAsync<TPage>(TPage page) where TPage : Page =>
            CloseModalAsync()
                .ContinueWith(t =>
                    Device.InvokeOnMainThreadAsync(() => Application.Current.MainPage = page),
                        TaskContinuationOptions.OnlyOnRanToCompletion);

        public void DetermineAndSetMainPage<TPage>() where TPage : Page =>
            Application.Current.MainPage = _serviceProvider.GetService<TPage>();

        public Task OpenModalAsync(Page modal, bool animated = true)
        {
            var updatedModal = _pageProcessor.AssignPageData(modal);
            return Device.InvokeOnMainThreadAsync(
                () => Application.Current.MainPage.Navigation.PushModalAsync(updatedModal, animated));
        }

        public Task CloseModalAsync(bool animated = true) =>
            Application.Current.MainPage.Navigation.ModalStack.Count > 0
                ? Device.InvokeOnMainThreadAsync(
                    () => Application.Current.MainPage.Navigation.PopModalAsync(animated))
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
                ? Device.InvokeOnMainThreadAsync(() => PopupNavigation.Instance.PopAsync(animated))
                : Task.CompletedTask;

        public Task NavigateToPageAsync(string routeWithParams, bool animated = true)
        {
            var tabbedPage = (TabbedPage)Application.Current.MainPage;
            var page = routeWithParams.GetElementFromRouting<Page>();
            var updatedPage = _pageProcessor.AssignPageData(page);
            return Device.InvokeOnMainThreadAsync(
                () => tabbedPage.CurrentPage.Navigation.PushAsync(updatedPage, animated));
        }

        public Task NavigateBackAsync(bool animated = true)
        {
            var tabbedPage = (TabbedPage)Application.Current.MainPage;
            var currentTab = tabbedPage.CurrentPage;
            if (currentTab.Navigation.NavigationStack.Count > 1)
                return Device.InvokeOnMainThreadAsync(
                    () => currentTab.Navigation.PopAsync(animated));
            return Task.CompletedTask;
        }

        public Task NavigateToRootAsync(bool animated = true)
        {
            var tabbedPage = (TabbedPage)Application.Current.MainPage;
            return Device.InvokeOnMainThreadAsync(
                () => tabbedPage.CurrentPage.Navigation.PopToRootAsync(animated));
        }

        public Task SwitchItemAsync(int index) =>
            Device.InvokeOnMainThreadAsync(() =>
            {
                var tabbedPage = (TabbedPage)Application.Current.MainPage;
                tabbedPage.CurrentPage = tabbedPage.Children.ElementAtOrDefault(index);
            });
    }
}