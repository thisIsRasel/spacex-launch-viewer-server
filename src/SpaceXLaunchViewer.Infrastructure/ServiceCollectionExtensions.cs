using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceXLaunchViewer.Infrastructure.Settings;

namespace SpaceXLaunchViewer.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSettings(
        this IServiceCollection services,
        ConfigurationManager config)
    {
        services
            .AddOptions<SpaceXOptions>()
            .Bind(config.GetSection(SpaceXOptions.SpaceX))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}
