using AsyncAwaitBestPractices;
using AsyncAwaitBestPractices.MVVM;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Attributes;

namespace XamarinFormsAdvancedTemplate.Extensions
{
    public static class PageExtensions
    {
        public static TPage AssignPageAppearing<TPage>(
            this TPage page, PageAppearingAttribute pageAppearingAttr) where TPage : Page
        {
            if (string.IsNullOrEmpty(pageAppearingAttr.PageAppearingTaskName))
                return page;

            var methodInvoke = GetPageActionFromBindingContext(
                page.BindingContext, pageAppearingAttr.PageAppearingTaskName);

            page.Appearing += (o, e) => methodInvoke();

            return page;
        }

        public static TPage AssignPageDisappearing<TPage>(
            this TPage page, PageDisappearingAttribute pageDisappearingAttr) where TPage : Page
        {
            if (string.IsNullOrEmpty(pageDisappearingAttr.PageDisappearingTaskName))
                return page;

            var methodInvoke = GetPageActionFromBindingContext(
                page.BindingContext, pageDisappearingAttr.PageDisappearingTaskName);

            page.Disappearing += (o, e) => methodInvoke();

            return page;
        }

        public static TPage AssignCommands<TPage>(
            this TPage page, CommandAttribute[] commandAttrs) where TPage : Page
        {
            foreach (var commandAttr in commandAttrs)
            {
                if (string.IsNullOrEmpty(commandAttr.CommandDelegateName))
                    continue;

                var desiredControl = GetControlData(page, commandAttr.ControlName,
                    out var desiredControlType, out var bindingContextType);

                AssignCommandParameter(
                    desiredControl, desiredControlType, bindingContextType, commandAttr);

                AssignCommand(
                    desiredControl, page.BindingContext,
                    desiredControlType, bindingContextType,
                    commandAttr);
            }
            return page;
        }

        public static TPage AssignAsyncCommands<TPage>(
            this TPage page, AsyncCommandAttribute[] commandAttrs) where TPage : Page
        {
            foreach (var commandAttr in commandAttrs)
            {
                if (string.IsNullOrEmpty(commandAttr.CommandDelegateName))
                    continue;

                var desiredControl = GetControlData(page, commandAttr.ControlName,
                    out var desiredControlType, out var bindingContextType);

                AssignCommandParameter(
                    desiredControl, desiredControlType, bindingContextType, commandAttr);

                AssignAsyncCommand(
                    desiredControl, page.BindingContext,
                    desiredControlType, bindingContextType,
                    commandAttr);
            }
            return page;
        }

        private static Action GetPageActionFromBindingContext(object bindingContext, string taskName)
        {
            var method = bindingContext
                .GetType()
                .GetMethod(taskName);

            return () => ((Task)method.Invoke(bindingContext, Array.Empty<object>()))
                .SafeFireAndForget();
        }

        private static BindableObject GetControlData<TPage>(
            TPage parent, string controlName, out Type controlType, out Type bindingContextType) where TPage : Page
        {
            var desiredControl = (BindableObject)parent.FindByName(controlName);
            controlType = desiredControl.GetType();
            bindingContextType = parent.BindingContext.GetType();

            return desiredControl;
        }

        private static void AssignCommandParameter(
            BindableObject control, Type controlType, Type bindingContextType, CommandAttribute commandAttr)
        {
            if (controlType.GetProperty("CommandParameter") is PropertyInfo)
            {
                var @object = bindingContextType
                    .GetProperty(commandAttr.CommandObjectName);

                if (@object != default)
                {
                    control.SetBinding(
                        (BindableProperty)controlType.GetField("CommandParameterProperty").GetValue(control),
                        commandAttr.CommandObjectName);
                }
            }
        }

        private static void AssignCommand(
            BindableObject control, object bindingContext,
            Type controlType, Type bindingContextType,
            CommandAttribute commandAttr)
        {
            if (controlType.GetProperty("Command") is PropertyInfo commandProp)
            {
                var method = bindingContextType
                    .GetMethod(commandAttr.CommandDelegateName);

                var command = new Command(obj =>
                    method.Invoke(
                        bindingContext,
                        new object[] { obj }));

                commandProp.SetValue(control, command);
            }
        }

        private static void AssignAsyncCommand(
            BindableObject control, object bindingContext,
            Type controlType, Type bindingContextType,
            AsyncCommandAttribute commandAttr)
        {
            if (controlType.GetProperty("Command") is PropertyInfo commandProp)
            {
                var method = bindingContextType
                    .GetMethod(commandAttr.CommandDelegateName);

                var exceptionMethod = bindingContextType
                    .GetMethod(commandAttr.OnException);

                var command = exceptionMethod is default(MethodInfo)
                    ? new AsyncCommand<object>(obj =>
                    {
                        return method.GetParameters().Count() <= 0
                        ? (Task)method.Invoke(bindingContext, new object[] { })
                        : (Task)method.Invoke(bindingContext, new object[] { obj });
                    }, continueOnCapturedContext: commandAttr.ContinueOnCapturedContext)
                    : new AsyncCommand<object>(obj =>
                    {
                        return method.GetParameters().Count() <= 0
                        ? (Task)method.Invoke(bindingContext, new object[] { })
                        : (Task)method.Invoke(bindingContext, new object[] { obj });
                    }, onException: obj => exceptionMethod.Invoke(bindingContext, new object[] { obj }),
                       continueOnCapturedContext: commandAttr.ContinueOnCapturedContext);

                commandProp.SetValue(control, command);
            }
        }
    }
}