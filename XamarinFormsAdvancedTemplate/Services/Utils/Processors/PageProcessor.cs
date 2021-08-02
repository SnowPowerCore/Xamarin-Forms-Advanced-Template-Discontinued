using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Extensions;

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
                if (pageAppearingAttr != default)
                    modifiedPage = modifiedPage.AssignPageAppearing(pageAppearingAttr);

                var pageDisappearingAttr = modifiedPage.GetElementPageDisappearingAttribute();
                if (pageDisappearingAttr != default)
                    modifiedPage = modifiedPage.AssignPageDisappearing(pageDisappearingAttr);

                var commandAttrs = modifiedPage.GetElementCommandAttributes();
                if (commandAttrs.Length > 0)
                    modifiedPage = modifiedPage.AssignCommands(commandAttrs);

                var asyncCommandAttrs = modifiedPage.GetElementAsyncCommandAttributes();
                if (asyncCommandAttrs.Length > 0)
                    modifiedPage = modifiedPage.AssignAsyncCommands(asyncCommandAttrs);
            }

            _processedItems.Add(modifiedPage.Id);
            return modifiedPage;
        }
    }
}