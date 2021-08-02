using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Navigation
{
    public interface IPageNavigation
    {
        void DetermineAndSetMainPage<TPage>() where TPage : Page;

        Task SwitchMainPageAsync<TPage>(TPage page) where TPage : Page;

        Task NavigateToPageAsync(string routeWithParams, bool animated = true);

        Task NavigateBackAsync(bool animated = true);

        Task NavigateToRootAsync(bool animated = true);
    }
}