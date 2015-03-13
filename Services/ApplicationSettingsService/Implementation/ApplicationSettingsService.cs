using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Services.ApplicationSettingsService.Implementation
{
    [ExcludeFromCodeCoverage]
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        public string GetKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}