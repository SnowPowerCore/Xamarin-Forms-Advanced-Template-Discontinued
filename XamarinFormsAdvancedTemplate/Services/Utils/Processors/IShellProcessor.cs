using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Processors
{
    public interface IShellProcessor
    {
        TShellType AssignShellData<TShellType>(TShellType shell)
            where TShellType : Shell;
    }
}