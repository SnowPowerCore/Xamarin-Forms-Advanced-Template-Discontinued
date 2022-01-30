using System.Collections.Generic;
using System.Globalization;

namespace XamarinFormsAdvancedTemplate.Models
{
    public class AppSettings
    {
        public string ProjectName { get; set; }

        public string SupportNumber { get; set; }

        public string SupportEmail { get; set; }

        public string DefaultApiUri { get; set; }

        public string AppCenterAndroidKey { get; set; }

        public string AppCenteriOSKey { get; set; }

        public string DBName { get; set; }

        public string WebsiteDomain { get; set; }

        public Dictionary<string, CultureInfo> LanguageCulturePairs { get; set; } =
            new Dictionary<string, CultureInfo>();
    }
}