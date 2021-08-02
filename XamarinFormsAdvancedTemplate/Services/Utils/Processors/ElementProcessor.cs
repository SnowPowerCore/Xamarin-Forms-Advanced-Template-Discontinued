using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Attributes;
using XamarinFormsAdvancedTemplate.Extensions;

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
            if (bindingContextAttrs.Length > 0)
                AssignBindingContexts(xfElement, bindingContextAttrs);

            _processedItems.Add(xfElement.Id);
            return xfElement;
        }

        private void AssignBindingContexts<TElement>(
            TElement xfElement, BindingContextAttribute[] bindingContextAttrs) where TElement : Element
        {
            var xfElementType = xfElement.GetType();

            var elementBindingContext = bindingContextAttrs.LastOrDefault(
                       x => string.IsNullOrEmpty(x.PropertyName));

            if (elementBindingContext != default)
            {
                var bindingContext = _serviceProvider.GetService(elementBindingContext.BindingContextType);
                xfElement.BindingContext = bindingContext;
            }

            var childrenBindingContexts = bindingContextAttrs
                .Where(x => !string.IsNullOrEmpty(x.PropertyName));

            _ = childrenBindingContexts.Select(x =>
            {
                var field = xfElementType.GetField(x.PropertyName,
                    BindingFlags.NonPublic | BindingFlags.Instance);

                if (field is default(FieldInfo))
                    return default;

                if (field.FieldType.IsSubclassOf(typeof(BindableObject)))
                {
                    var bindableProperty = (BindableObject)field.GetValue(xfElement);
                    var bindingContext = _serviceProvider.GetService(x.BindingContextType);
                    bindableProperty.BindingContext = bindingContext;
                }

                return x;
            });
        }
    }
}