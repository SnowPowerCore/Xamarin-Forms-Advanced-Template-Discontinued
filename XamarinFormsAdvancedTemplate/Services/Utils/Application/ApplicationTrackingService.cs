using Microsoft.Extensions.Logging;
using XamarinFormsAdvancedTemplate.Services.Utils.Analytics;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Application
{
    public class ApplicationTrackingService<T> : IApplicationTrackingService
    {
        public ILogger ApplicationLogger { get; }

        public IAnalyticsService Analytics { get; }

        public ApplicationTrackingService(ILoggerFactory loggerFactory,
                                          IAnalyticsService analytics)
        {
            ApplicationLogger = loggerFactory.CreateLogger<T>();
            Analytics = analytics;
        }
    }
}