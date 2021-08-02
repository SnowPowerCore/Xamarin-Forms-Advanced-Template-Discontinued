using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Navigation
{
    public interface IModalNavigation
    {
        Task OpenModalAsync(Page modal, bool animated = true);

        Task CloseModalAsync(bool animated = true);
    }
}