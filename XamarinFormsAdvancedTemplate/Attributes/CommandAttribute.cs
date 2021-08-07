using System;

namespace XamarinFormsAdvancedTemplate.Attributes
{
    /// <summary>
    /// Please, use it on a page class. You can consume this multiple times.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CommandAttribute : Attribute
    {
        public string ControlName { get; } = string.Empty;

        public string CommandDelegateName { get; } = string.Empty;

        public string CommandCanExecuteDelegateName { get; } = string.Empty;

        public string CommandObjectName { get; }

        public CommandAttribute(
            string controlName,
            string commandDelegateName,
            string commandObjectName = "",
            string commandCanExecuteDelegateName = "")
        {
            ControlName = controlName;
            CommandDelegateName = commandDelegateName;
            CommandObjectName = commandObjectName;
            CommandCanExecuteDelegateName = commandCanExecuteDelegateName;
        }
    }

    /// <summary>
    /// Please, use it on a page class. You can consume this multiple times.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AsyncCommandAttribute : CommandAttribute
    {
        public bool ContinueOnCapturedContext { get; }

        public string OnException { get; }

        public AsyncCommandAttribute(
            string controlName,
            string commandTaskName,
            string commandObjectName = "",
            string commandCanExecuteDelegateName = "",
            bool continueOnCapturedContext = false,
            string onException = "")
            : base(controlName, commandTaskName,
                  commandObjectName, commandCanExecuteDelegateName)
        {
            ContinueOnCapturedContext = continueOnCapturedContext;
            OnException = onException;
        }
    }
}