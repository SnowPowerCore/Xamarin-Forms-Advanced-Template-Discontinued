using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Processors
{
    public interface IPageProcessor
    {
        TPageType AssignPageData<TPageType>(TPageType page)
            where TPageType : Page;
    }
}