using ReloadableSettings.Models;
using ReloadableSettings.Services;

namespace ReloadableSettings.Api.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<Settings>(configuration.GetSection(nameof(Settings)));
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ISettingsService, SettingsService>();
        }
    }
}
