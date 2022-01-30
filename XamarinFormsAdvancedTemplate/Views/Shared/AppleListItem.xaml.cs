using AppHosting.Xamarin.Forms.Attributes;
using XamarinFormsAdvancedTemplate.ViewModels;

namespace XamarinFormsAdvancedTemplate.Views.Shared
{
    [AttachedAsyncCommand(
        commandTaskName: nameof(AppleViewModel.NavigateToAppleDetailPageAsync),
        onException: nameof(AppleViewModel.HandleException))]
    public partial class AppleListItem
    {
        public AppleListItem() =>
            InitializeComponent();
    }
}