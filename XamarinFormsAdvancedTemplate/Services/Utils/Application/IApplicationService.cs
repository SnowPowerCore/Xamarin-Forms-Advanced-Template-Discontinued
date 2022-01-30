namespace XamarinFormsAdvancedTemplate.Services.Utils.Application
{
    public interface IApplicationService
    {
        IApplicationTrackingService Tracking { get; }

        IApplicationInfrastructureService Infrastructure { get; }

        void InitializeApplication<TInitPage>();
    }
}