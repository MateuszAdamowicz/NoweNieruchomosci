using System.Configuration;

namespace Services.ApplicationSettingsService.Implementation
{
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        public string GetKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}