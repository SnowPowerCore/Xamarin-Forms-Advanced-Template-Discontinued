using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Services.Navigation;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinFormsAdvancedTemplate.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class WelcomeViewModel
    {
        private readonly INavigationService _navigation;

        public string Hello { get; set; } = "Hello welcome";

        public List<string> Strings { get; set; } =
            new List<string>();

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

        public void InterestingCommand()
        {
            for (var i = 0; i < 100000; i++)
            {
                var str = $"This is item #{ i }";
                Strings.Add(str);
                if (i % 1000 == 0)
                    Console.WriteLine($"{ str } | Count is { Strings.Count }");
            }
        }

        public async Task InterestingCommandAsync()
        {
            await _navigation.NavigateToPageAsync("otherPage");
        }

        public bool InterestingCommandCanExecute() =>
            true;

        public void HandleException(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}