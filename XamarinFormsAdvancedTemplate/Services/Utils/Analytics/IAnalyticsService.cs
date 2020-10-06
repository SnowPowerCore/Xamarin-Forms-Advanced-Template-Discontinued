using System;
using System.Collections.Generic;

namespace XamarinFormsAdvancedTemplate.Services.Utils.Analytics
{
    public interface IAnalyticsService
    {
        void TrackEvent(string name, Dictionary<string, string> keys = null, string additional = null);

        void TrackError(Exception ex, Dictionary<string, string> keys = null, string additional = null);
    }
}