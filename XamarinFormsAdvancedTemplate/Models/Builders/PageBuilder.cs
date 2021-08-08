using AsyncAwaitBestPractices;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsAdvancedTemplate.Attributes;
using XamarinFormsAdvancedTemplate.Models.Utils;

namespace XamarinFormsAdvancedTemplate.Models.Builders
{
    public class PageBuilder
    {
        private Page _page;

        private PageBuilder() { }

        public static PageBuilder Init(Page page) =>
            new PageBuilder { _page = page };

        public PageBuilder AddPageAppearing(PageAppearingAttribute pageAppearingAttr)
        {
            if (string.IsNullOrEmpty(pageAppearingAttr.PageAppearingTaskName))
                return this;

            var methodInvoke = GetPageActionFromBindingContext(
                _page.BindingContext, pageAppearingAttr.PageAppearingTaskName);

            _page.Appearing += (o, e) => methodInvoke();

            return this;
        }

        public PageBuilder AddPageDisappearing(PageDisappearingAttribute pageDisappearingAttr)
        {
            if (string.IsNullOrEmpty(pageDisappearingAttr.PageDisappearingTaskName))
                return this;

            var methodInvoke = GetPageActionFromBindingContext(
                _page.BindingContext, pageDisappearingAttr.PageDisappearingTaskName);

            _page.Disappearing += (o, e) => methodInvoke();

            return this;
        }

        public PageBuilder AddCommands(CommandAttribute[] commandAttrs)
        {
            foreach (var commandAttr in commandAttrs)
            {
                if (string.IsNullOrEmpty(commandAttr.CommandDelegateName))
                    continue;

                var desiredControl = GetControlData(_page, commandAttr.ControlName,
                    out var desiredControlType, out var bindingContextType);

                AssignCommandParameter(
                    desiredControl, desiredControlType, bindingContextType, commandAttr);

                AssignCommand(
                    desiredControl, _page.BindingContext,
                    desiredControlType, bindingContextType,
                    commandAttr);
            }
            return this;
        }

        public PageBuilder AddAsyncCommands(AsyncCommandAttribute[] commandAttrs)
        {
            foreach (var commandAttr in commandAttrs)
            {
                if (string.IsNullOrEmpty(commandAttr.CommandDelegateName))
                    continue;

                var desiredControl = GetControlData(_page, commandAttr.ControlName,
                    out var desiredControlType, out var bindingContextType);

                AssignCommandParameter(
                    desiredControl, desiredControlType, bindingContextType, commandAttr);

                AssignAsyncCommand(
                    desiredControl, _page.BindingContext,
                    desiredControlType, bindingContextType,
                    commandAttr);
            }
            return this;
        }

        public static implicit operator Page(PageBuilder builder) =>
            builder._page;

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

                var canExecuteMethod = bindingContextType
                    .GetMethod(commandAttr.CommandCanExecuteDelegateName);

                var command = new RelayCommand<object>(
                    obj => method.Invoke(
                        bindingContext,
                        new object[] { obj }),
                    () => (bool)canExecuteMethod?.Invoke(
                        bindingContext,
                        new object[0]));

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

                var command = new AsyncRelayCommand<object>(
                    obj =>
                    {
                        return method.GetParameters().Count() <= 0
                            ? (Task)method.Invoke(bindingContext, new object[] { })
                            : (Task)method.Invoke(bindingContext, new object[] { obj });
                    },
                    onException: obj => exceptionMethod?.Invoke(bindingContext, new object[] { obj }),
                    continueOnCapturedContext: commandAttr.ContinueOnCapturedContext);

                commandProp.SetValue(control, command);
            }
        }
    }
}