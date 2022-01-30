using Xamarin.Forms;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Application
{
    public class ApplicationService : IApplicationService
    {
        public IApplicationTrackingService Tracking { get; }

        public IApplicationInfrastructureService Infrastructure { get; }


        public ApplicationService(IApplicationTrackingService applicationTracking,
                                  IApplicationInfrastructureService applicationInfrastructure)
        {
            Tracking = applicationTracking;
            Infrastructure = applicationInfrastructure;
        }

        public void InitializeApplication<TInitPage>()
        {
            Infrastructure.Language.DetermineAndSetLanguage();
            if (typeof(TInitPage).IsSubclassOf(typeof(Page)))
                Infrastructure.Navigation.DetermineAndSetMainPage<TInitPage>();
            Tracking.Analytics.TrackEvent("App started.");
        }
    }
}