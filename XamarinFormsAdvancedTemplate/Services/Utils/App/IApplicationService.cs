using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.App
{
    public interface IApplicationService
    {
        void InitializeApplication<TInitPage>() where TInitPage : Page;
    }
}