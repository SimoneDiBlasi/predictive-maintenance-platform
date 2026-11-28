
using PredictiveMaintenance.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Register application services
builder.Services.AddApplicationHealthChecks();

// Register controllers
builder.Services.AddControllers();

// Register Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure Swagger
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "PredictiveMaintenance API v1");

        options.RoutePrefix = "swagger";
    });
}

// Configure middleware
app.UseHttpsRedirection();

app.UseApplicationHealthChecks();

app.UseAuthorization();

// Map endpoints
app.MapControllers();

app.Run();
