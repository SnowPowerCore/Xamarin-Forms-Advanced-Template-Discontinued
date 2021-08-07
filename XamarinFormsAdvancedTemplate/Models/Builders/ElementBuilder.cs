using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Attributes;

namespace XamarinFormsAdvancedTemplate.Models.Builders
{
    public class ElementBuilder
    {
        private Element _element;

        private ElementBuilder() { }

        public static ElementBuilder Init(Element originalElement) =>
            new ElementBuilder { _element = originalElement };

        public ElementBuilder AddBindingContext(
            IServiceProvider services,
            BindingContextAttribute[] bindingContextAttrs)
        {
            var xfElementType = _element.GetType();

            var elementBindingContext = bindingContextAttrs.LastOrDefault(
                       x => string.IsNullOrEmpty(x.PropertyName));

            if (elementBindingContext != default)
            {
                var bindingContext = services.GetService(elementBindingContext.BindingContextType);
                _element.BindingContext = bindingContext;
            }

            return this;
        }

        public ElementBuilder AddChildrenBindingContexts(
            IServiceProvider services,
            BindingContextAttribute[] bindingContextAttrs)
        {
            var xfElementType = _element.GetType();

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
                    var bindableProperty = (BindableObject)field.GetValue(_element);
                    var bindingContext = services.GetService(x.BindingContextType);
                    bindableProperty.BindingContext = bindingContext;
                }

                return x;
            });

            return this;
        }

        public static implicit operator Element(ElementBuilder builder) =>
            builder._element;
    }
}