using XamarinFormsAdvancedTemplate.Controls;
using XamarinFormsAdvancedTemplate.Services.Utils.Processors;

namespace XamarinFormsAdvancedTemplate.Views.Shell
{
    public partial class AppShell : HostedShell
    {
        public AppShell(IPageProcessor pageProcessor) : base(pageProcessor) =>
            InitializeComponent();
    }
}