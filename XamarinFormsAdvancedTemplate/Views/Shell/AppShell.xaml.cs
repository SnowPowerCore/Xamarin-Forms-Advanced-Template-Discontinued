using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Services.Processors;
using AppHosting.Xamarin.Forms.Controls;

namespace XamarinFormsAdvancedTemplate.Views.Shell
{
    public partial class AppShell : HostedShell
    {
        public AppShell(IAppVisualProcessor appVisualProcessor) : base(appVisualProcessor) =>
            InitializeComponent();
    }
}