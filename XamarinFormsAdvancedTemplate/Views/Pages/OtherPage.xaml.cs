using AppHosting.Xamarin.Forms.Attributes;
using XamarinFormsAdvancedTemplate.ViewModels;

namespace XamarinFormsAdvancedTemplate.Views.Pages
{
    [BindingContext(typeof(WelcomeViewModel))]
    public partial class OtherPage
    {
        public OtherPage() =>
            InitializeComponent();
    }
}