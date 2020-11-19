using UIKit;
using XamarinFormsAdvancedTemplate.Services.Interfaces;

namespace XamarinFormsAdvancedTemplate.iOS.Implementations
{
    public class Keyboard : IKeyboard
    {
        public void HideKeyboard() =>
            UIApplication.SharedApplication.KeyWindow.EndEditing(true);
    }
}