using PropertyChanged;
using System;
using System.Threading.Tasks;
using XamarinFormsAdvancedTemplate.Services.Utils.Navigation;

namespace XamarinFormsAdvancedTemplate.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WelcomeViewModel
    {
        private readonly INavigationService _navigation;

        public string Hello { get; set; } = "Hello welcome";

        public WelcomeViewModel(INavigationService navigation)
        {
            _navigation = navigation;
        }

        public Task HelloMethodAsync()
        {
            Console.WriteLine("Page's appearing");
            return Task.CompletedTask;
        }

        public Task GoodbyeMethodAsync()
        {
            Console.WriteLine("Page's disappearing");
            return Task.CompletedTask;
        }

        public async Task InterestingCommandAsync(string hello)
        {
            await _navigation.NavigateToPageAsync("otherPage").ConfigureAwait(false);
        }

        public void HandleException(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}