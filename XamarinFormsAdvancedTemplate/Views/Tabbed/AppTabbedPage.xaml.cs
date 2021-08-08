using XamarinFormsAdvancedTemplate.Services.Utils.Processors;

namespace XamarinFormsAdvancedTemplate.Views.Tabbed
{
    public partial class AppTabbedPage
    {
        public AppTabbedPage(IPageProcessor pageProcessor) : base(pageProcessor) =>
            InitializeComponent();
    }
}