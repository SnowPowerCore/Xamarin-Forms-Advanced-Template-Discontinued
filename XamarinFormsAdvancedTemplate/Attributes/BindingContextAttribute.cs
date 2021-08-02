using System;

namespace XamarinFormsAdvancedTemplate.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class BindingContextAttribute : Attribute
    {
        public Type BindingContextType { get; } = typeof(object);

        public string PropertyName { get; } = string.Empty;

        public BindingContextAttribute(Type bindingContextType)
        {
            BindingContextType = bindingContextType;
        }

        public BindingContextAttribute(string propertyName, Type bindingContextType)
        {
            PropertyName = propertyName;
            BindingContextType = bindingContextType;
        }
    }
}