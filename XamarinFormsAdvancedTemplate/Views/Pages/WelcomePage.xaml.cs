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
        commandCanExecuteDelegateName: nameof(WelcomeViewModel.InterestingCommandCanExecute),
        commandObjectName: nameof(WelcomeViewModel.Hello))]
    public partial class WelcomePage
    {
        public WelcomePage() =>
            InitializeComponent();
    }
}