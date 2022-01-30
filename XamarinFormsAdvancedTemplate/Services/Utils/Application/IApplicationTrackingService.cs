using Microsoft.Extensions.Logging;
using XamarinFormsAdvancedTemplate.Services.Utils.Analytics;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Application
{
    public interface IApplicationTrackingService
    {
        ILogger ApplicationLogger { get; }

        IAnalyticsService Analytics { get; }
    }
}