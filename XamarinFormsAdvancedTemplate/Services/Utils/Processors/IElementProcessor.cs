using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Processors
{
    public interface IElementProcessor
    {
        TElement AssignElementData<TElement>(TElement shell) where TElement : Element;
    }
}