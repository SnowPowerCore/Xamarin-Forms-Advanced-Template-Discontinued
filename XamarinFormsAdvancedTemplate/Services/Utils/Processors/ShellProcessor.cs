using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Processors
{
    public class ShellProcessor : IShellProcessor
    {
        private readonly IPageProcessor _pageProcessor;

        public ShellProcessor(IPageProcessor pageProcessor)
        {
            _pageProcessor = pageProcessor;
        }

        public TShell AssignShellData<TShell>([NotNull] TShell shell) where TShell : Shell =>
            _pageProcessor.AssignPageData(shell);
    }
}