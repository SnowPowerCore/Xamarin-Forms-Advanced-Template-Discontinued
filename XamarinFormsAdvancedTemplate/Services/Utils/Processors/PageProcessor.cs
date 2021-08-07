using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Extensions;
using XamarinFormsAdvancedTemplate.Models.Builders;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Processors
{
    public class PageProcessor : IPageProcessor
    {
        private readonly IElementProcessor _elementManager;

        private readonly List<Guid> _processedItems = new List<Guid>();

        public PageProcessor(IElementProcessor elementManager)
        {
            _elementManager = elementManager;
        }

        public TPage AssignPageData<TPage>([NotNull] TPage page) where TPage : Page
        {
            if (_processedItems.Contains(page.Id))
                return page;

            var modifiedPage = _elementManager.AssignElementData(page);

            if (modifiedPage.BindingContext != default)
            {
                var pageAppearingAttr = modifiedPage.GetElementPageAppearingAttribute();
                var pageDisappearingAttr = modifiedPage.GetElementPageDisappearingAttribute();
                var commandAttrs = modifiedPage.GetElementCommandAttributes();
                var asyncCommandAttrs = modifiedPage.GetElementAsyncCommandAttributes();

                modifiedPage = (TPage)PageBuilder
                    .Init(modifiedPage)
                    .AddPageAppearing(pageAppearingAttr)
                    .AddPageDisappearing(pageDisappearingAttr)
                    .AddCommands(commandAttrs)
                    .AddAsyncCommands(asyncCommandAttrs);
            }

            _processedItems.Add(modifiedPage.Id);
            return modifiedPage;
        }
    }
}