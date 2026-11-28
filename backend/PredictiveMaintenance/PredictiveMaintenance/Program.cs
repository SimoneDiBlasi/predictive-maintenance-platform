
using PredictiveMaintenance.Api.Extensions;
using PredictiveMaintenance.Extensions;
using Serilog;

LoggingExtensions.ConfigureBootstrapLogging();

try
{
    Log.Information("Starting PredictiveMaintenance API");

    var builder = WebApplication.CreateBuilder(args);

    // Configure logging
    builder.Host.UseApplicationLogging();

    // Register application services
    builder.Services.AddApplicationHealthChecks();

    // Register controllers
    builder.Services.AddControllers();

    // Register Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // HTTP request logging
    app.UseSerilogRequestLogging();

    // Swagger
    if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Middleware
    app.UseHttpsRedirection();
    app.UseApplicationHealthChecks();
    app.UseAuthorization();

    // Map endpoints
    app.MapControllers();

    Log.Information("Application started in {Environment}", app.Environment.EnvironmentName);

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
