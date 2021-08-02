using XamarinFormsAdvancedTemplate.Attributes;
using XamarinFormsAdvancedTemplate.ViewModels;

namespace XamarinFormsAdvancedTemplate.Views.Pages
{
    [BindingContext(typeof(WelcomeViewModel))]
    [BindingContext(nameof(lbl), typeof(WelcomeViewModel))]
    [PageAppearing(nameof(WelcomeViewModel.HelloMethodAsync))]
    [PageDisappearing(nameof(WelcomeViewModel.GoodbyeMethodAsync))]
    [AsyncCommand(
        controlName: nameof(btn),
        commandTaskName: nameof(WelcomeViewModel.InterestingCommandAsync),
        commandObjectName: nameof(WelcomeViewModel.Hello),
        onException: nameof(WelcomeViewModel.HandleException))]
    public partial class WelcomePage
    {
        public WelcomePage() =>
            InitializeComponent();
    }
}