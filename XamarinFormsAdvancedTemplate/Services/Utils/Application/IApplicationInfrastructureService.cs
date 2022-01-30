using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Services.Navigation;
using XamarinFormsAdvancedTemplate.Services.Utils.Language;
using XamarinFormsAdvancedTemplate.Services.Utils.Message;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Application
{
    public interface IApplicationInfrastructureService
    {
        public IMessageService Message { get; }

        public INavigationService Navigation { get; }

        public ILanguageService Language { get; }
    }
}
