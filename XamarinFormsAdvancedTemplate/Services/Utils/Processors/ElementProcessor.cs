using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Extensions;
using XamarinFormsAdvancedTemplate.Models.Builders;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Processors
{
    public class ElementProcessor : IElementProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly List<Guid> _processedItems = new List<Guid>();

        public ElementProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TElement AssignElementData<TElement>([NotNull] TElement xfElement) where TElement : Element
        {
            if (_processedItems.Contains(xfElement.Id))
                return xfElement;

            var bindingContextAttrs = xfElement.GetElementBindingContextAttributes();

            xfElement = (TElement)ElementBuilder
                .Init(xfElement)
                .AddBindingContext(_serviceProvider, bindingContextAttrs)
                .AddChildrenBindingContexts(_serviceProvider, bindingContextAttrs);

            _processedItems.Add(xfElement.Id);
            return xfElement;
        }
    }
}