
using Serilog;
using PredictiveMaintenance.Logging;

namespace PredictiveMaintenance.Extensions;

public static class LoggingExtensions
{
    public static void ConfigureBootstrapLogging()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console(
                theme: CustomConsoleTheme.Theme,
                outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateBootstrapLogger();
    }

    public static IHostBuilder UseApplicationLogging(
        this IHostBuilder hostBuilder)
    {
        ArgumentNullException.ThrowIfNull(hostBuilder);

        hostBuilder.UseSerilog((context, services, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext();
        });

        return hostBuilder;
    }
}
