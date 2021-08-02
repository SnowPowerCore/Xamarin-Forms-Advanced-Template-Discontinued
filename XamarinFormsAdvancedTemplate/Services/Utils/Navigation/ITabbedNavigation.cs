using System.Threading.Tasks;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Navigation
{
    public interface ITabbedNavigation
    {
        Task SwitchItemAsync(int index);
    }
}