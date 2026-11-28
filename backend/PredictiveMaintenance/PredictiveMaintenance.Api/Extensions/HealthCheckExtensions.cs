
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PredictiveMaintenance.Api.HealthChecks;

namespace PredictiveMaintenance.Api.Extensions;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddApplicationHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        var mlServiceBaseUrl = configuration["MlService:BaseUrl"];

        if (!Uri.TryCreate(mlServiceBaseUrl, UriKind.Absolute, out var mlServiceUri))
        {
            throw new InvalidOperationException("MlService:BaseUrl is missing or invalid.");
        }

        services.AddHttpClient<MlServiceHealthCheck>(client =>
        {
            client.BaseAddress = mlServiceUri;
            client.Timeout = TimeSpan.FromSeconds(5);
        });

        services.AddHealthChecks()
            .AddCheck(
                "self",
                () => HealthCheckResult.Healthy(
                    "Application is running."),
                tags: ["live", "ready"])
            .AddCheck<MlServiceHealthCheck>(
                "ml-service",
                tags: ["ready"]);

        return services;
    }

    public static IApplicationBuilder UseApplicationHealthChecks(
        this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.UseHealthChecks("/health/live", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("live")
        });

        app.UseHealthChecks("/health/ready", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("ready")
        });

        return app;
    }
}
