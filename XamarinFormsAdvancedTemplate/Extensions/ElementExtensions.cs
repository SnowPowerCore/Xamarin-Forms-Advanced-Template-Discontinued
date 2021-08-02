using System;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Attributes;

namespace XamarinFormsAdvancedTemplate.Extensions
{
    public static class ElementExtensions
    {
        public static BindingContextAttribute[] GetElementBindingContextAttributes(this Element xfElement)
        {
            var bindingContextAttrs = (BindingContextAttribute[])Attribute.GetCustomAttributes(
                xfElement.GetType(),
                typeof(BindingContextAttribute));

            return bindingContextAttrs is default(BindingContextAttribute[])
                ? Array.Empty<BindingContextAttribute>()
                : bindingContextAttrs;
        }

        public static PageAppearingAttribute GetElementPageAppearingAttribute(this Element xfElement)
        {
            var pageAppearingAttr = (PageAppearingAttribute)Attribute.GetCustomAttribute(
                xfElement.GetType(),
                typeof(PageAppearingAttribute));

            return pageAppearingAttr is default(PageAppearingAttribute)
                ? default
                : pageAppearingAttr;
        }

        public static PageDisappearingAttribute GetElementPageDisappearingAttribute(this Element xfElement)
        {
            var pageAppearingAttr = (PageDisappearingAttribute)Attribute.GetCustomAttribute(
                xfElement.GetType(),
                typeof(PageDisappearingAttribute));

            return pageAppearingAttr is default(PageDisappearingAttribute)
                ? default
                : pageAppearingAttr;
        }

        public static CommandAttribute[] GetElementCommandAttributes(this Element xfElement)
        {
            var commandAttrs = (CommandAttribute[])Attribute.GetCustomAttributes(
                xfElement.GetType(),
                typeof(CommandAttribute));

            return commandAttrs is default(CommandAttribute[])
                ? Array.Empty<CommandAttribute>()
                : commandAttrs;
        }

        public static AsyncCommandAttribute[] GetElementAsyncCommandAttributes(this Element xfElement)
        {
            var commandAttrs = (AsyncCommandAttribute[])Attribute.GetCustomAttributes(
                xfElement.GetType(),
                typeof(AsyncCommandAttribute));

            return commandAttrs is default(AsyncCommandAttribute[])
                ? Array.Empty<AsyncCommandAttribute>()
                : commandAttrs;
        }
    }
}