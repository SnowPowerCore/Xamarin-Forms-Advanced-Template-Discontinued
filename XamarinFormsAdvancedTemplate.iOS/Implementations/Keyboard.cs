using UIKit;
using $ext_safeprojectname$.Services.Interfaces;

namespace XamarinFormsAdvancedTemplate.iOS.Implementations
{
    public class Keyboard : IKeyboard
    {
        public void HideKeyboard() =>
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
    }
}