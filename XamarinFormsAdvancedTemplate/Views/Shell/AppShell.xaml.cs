using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Services.Processors;

namespace XamarinFormsAdvancedTemplate.Views.Shell
{
    public partial class AppShell
    {
        public AppShell(IAppVisualProcessor appVisualProcessor) : base(appVisualProcessor) =>
            InitializeComponent();
    }
}