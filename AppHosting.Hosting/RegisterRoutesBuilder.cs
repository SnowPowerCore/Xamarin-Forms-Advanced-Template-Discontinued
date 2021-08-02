using System;
using System.Reflection;

namespace AppHosting.Hosting
{
    internal class RegisterRoutesBuilder
    {
        public MethodInfo MethodInfo { get; }

        public RegisterRoutesBuilder(MethodInfo registerRoutesMethod)
        {
            MethodInfo = registerRoutesMethod;
        }

        public Action Build(object instance) => () => Invoke(instance);

        private void Invoke(object instance) =>
            MethodInfo.InvokeWithoutWrappingExceptions(instance, Array.Empty<object>());
    }
}