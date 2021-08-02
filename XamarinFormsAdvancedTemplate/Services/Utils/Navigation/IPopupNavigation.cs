using System.Threading.Tasks;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Navigation
{
    public interface IPopupNavigation
    {
        Task OpenPopupAsync(string routeWithParams, bool animated = true);

        Task ClosePopupAsync(bool animated = true);
    }
}