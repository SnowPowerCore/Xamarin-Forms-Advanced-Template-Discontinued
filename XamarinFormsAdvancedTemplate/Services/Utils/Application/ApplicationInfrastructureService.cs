using AppHosting.Xamarin.Forms.Abstractions.Interfaces.Services.Navigation;
using XamarinFormsAdvancedTemplate.Services.Utils.Language;
using XamarinFormsAdvancedTemplate.Services.Utils.Message;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Application
{
    public class ApplicationInfrastructureService : IApplicationInfrastructureService
    {
        public IMessageService Message { get; }

        public INavigationService Navigation { get; }

        public ILanguageService Language { get; }

        public ApplicationInfrastructureService(ILanguageService language,
                                                IMessageService message,
                                                INavigationService navigation)
        {
            Language = language;
            Message = message;
            Navigation = navigation;
        }
    }
}