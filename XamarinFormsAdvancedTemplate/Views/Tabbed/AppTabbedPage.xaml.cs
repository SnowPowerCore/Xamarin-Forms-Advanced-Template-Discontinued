using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Services.Processors;

namespace XamarinFormsAdvancedTemplate.Views.Tabbed
{
    public partial class AppTabbedPage
    {
        public AppTabbedPage(IAppVisualProcessor appVisualProcessor) : base(appVisualProcessor) =>
            InitializeComponent();
    }
}