using System.Linq;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Services.Utils.Processors;

namespace XamarinFormsAdvancedTemplate.Controls
{
    public class HostedTabbedPage : TabbedPage
    {
        private readonly IPageProcessor _pageProcessor;

        private HostedTabbedPage() : base() { }

        public HostedTabbedPage(IPageProcessor pageProcessor) : base()
        {
            _pageProcessor = pageProcessor;
        }

        protected override void OnAppearing()
        {
            ReplaceChildren();
            base.OnAppearing();
        }

        private void ReplaceChildren()
        {
            var pageItems = Children.ToList();
            Children.Clear();
            foreach (var page in pageItems)
            {
                if (page is NavigationPage navigationPage)
                {
                    var routePage = (Page)Routing
                        .GetOrCreateContent(Routing.GetRoute(navigationPage.CurrentPage));
                    if (routePage != default)
                        _ = _pageProcessor.AssignPageData(routePage);
                    Children.Add(new NavigationPage(routePage));
                }
                else
                {
                    var routePage = (Page)Routing.GetOrCreateContent(Routing.GetRoute(page));
                    if (routePage != default)
                        _ = _pageProcessor.AssignPageData(routePage);
                    Children.Add(routePage);
                }
            }
        }
    }
}