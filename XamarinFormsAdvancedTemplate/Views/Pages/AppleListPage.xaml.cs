using AppHosting.Xamarin.Forms.Attributes;
using XamarinFormsAdvancedTemplate.ViewModels;

namespace XamarinFormsAdvancedTemplate.Views.Pages
{
    [BindingContext(typeof(AppleViewModel))]
    [PageAppearing(nameof(AppleViewModel.ApplesPageAppearingAsync))]
    [PageDisappearing(nameof(AppleViewModel.ApplesPageDisappearingAsync))]
    public partial class AppleListPage
    {
        public AppleListPage() =>
            InitializeComponent();
    }
}