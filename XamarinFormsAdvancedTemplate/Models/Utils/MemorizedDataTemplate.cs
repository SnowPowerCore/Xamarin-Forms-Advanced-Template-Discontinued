using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Models.Utils
{
    public class MemorizedDataTemplate : DataTemplate
    {
        private static readonly Dictionary<Type, object> _createdContents =
            new Dictionary<Type, object>();

        public MemorizedDataTemplate() { }

        public MemorizedDataTemplate(TypeWrapper typeWrapper) : base(() =>
        {
            var type = typeWrapper.Type;
            if (_createdContents.ContainsKey(type))
                return _createdContents[type];

            var data = Activator.CreateInstance(type);
            _createdContents.Add(type, data);
            return data;
        })
        { }
    }
}