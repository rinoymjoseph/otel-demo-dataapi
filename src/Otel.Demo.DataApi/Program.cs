using Otel.Demo.DataApi;
using Otel.Demo.DataApi.Services;
using Otel.Demo.DataApi.Services.Interfaces;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITelemetryService, TelemetryService>();
builder.Services.AddScoped<IAssetDataService, AssetDataService>();

string otel_exporter_url = builder.Configuration.GetValue<string>(AppConstants.OTEL_EXPORTER_URL);

builder.Services.AddOpenTelemetry()
    .ConfigureResource(builder => builder
    .AddService(serviceName: AppConstants.OTEL_SERVCICE_NAME))
    .WithTracing(builder => builder
        .AddSource(AppConstants.OTEL_SERVCICE_NAME)
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddConsoleExporter()
        .AddOtlpExporter(options =>
        {
            options.Endpoint = new Uri(otel_exporter_url);
        }))
    .WithMetrics(metricsProviderBuilder => metricsProviderBuilder
        .ConfigureResource(resource => resource
        .AddService(AppConstants.OTEL_SERVCICE_NAME))
        .AddMeter(TelemetryService._meter.Name)
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddConsoleExporter()
        .AddOtlpExporter(options =>
        {
            options.Endpoint = new Uri(otel_exporter_url);
        }));
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
