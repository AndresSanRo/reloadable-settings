using Microsoft.Extensions.Options;
using ReloadableSettings.Models;

namespace ReloadableSettings.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly Settings _settings;
        public SettingsService(IOptionsSnapshot<Settings> options)
        {
            _settings = options.Value;
        }
        public string GetHelloWorldSetting()
        {
            return _settings.HelloWorld;
        }
    }
}
