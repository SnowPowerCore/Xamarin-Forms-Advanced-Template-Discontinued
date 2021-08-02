using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Extensions;
using XamarinFormsAdvancedTemplate.Services.Utils.Processors;

namespace XamarinFormsAdvancedTemplate.Controls
{
    public class HostedShell : Shell
    {
        private readonly IPageProcessor _pageProcessor;

        private HostedShell() : base() { }

        public HostedShell(IPageProcessor pageProcessor) : base()
        {
            _pageProcessor = pageProcessor;
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            var dest = args.Target.Location.OriginalString.GetDestinationRoute();

            var destShellContent = (ShellContent)FindByName(dest);
            if (destShellContent is default(ShellContent))
            {
                base.OnNavigating(args);
                return;
            }

            var currentPage = (Page)destShellContent.ContentTemplate.CreateContent();
            if (currentPage != default)
                _ = _pageProcessor.AssignPageData(currentPage);

            base.OnNavigating(args);
        }
    }
}