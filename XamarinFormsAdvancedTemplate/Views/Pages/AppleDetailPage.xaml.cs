using AppHosting.Xamarin.Forms.Attributes;
using XamarinFormsAdvancedTemplate.ViewModels;

namespace XamarinFormsAdvancedTemplate.Views.Pages
{
    [BindingContext(typeof(AppleViewModel))]
    public partial class AppleDetailPage
    {
        public AppleDetailPage() =>
            InitializeComponent();
    }
}