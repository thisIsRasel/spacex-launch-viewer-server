using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

    public static IServiceCollection AddHttpClients(
        this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var spaceXOptions = serviceProvider
            .GetRequiredService<IOptions<SpaceXOptions>>().Value;

        services.AddHttpClient(SpaceXOptions.SpaceX, (httpClient) =>
        {
            httpClient.BaseAddress = new Uri(spaceXOptions.BaseUrl);
        });

        return services;
    }
}
