using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PredictiveMaintenance.Api.HealthChecks;

public sealed class MlServiceHealthCheck(HttpClient httpClient) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            using HttpResponseMessage response = await httpClient.GetAsync("/health", cancellationToken);

            return response.IsSuccessStatusCode
                ? HealthCheckResult.Healthy("ML Service is running.")
                : HealthCheckResult.Unhealthy($"ML Service returned status code {(int)response.StatusCode}.");
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy("ML Service is unavailable.", exception);
        }
    }
}
