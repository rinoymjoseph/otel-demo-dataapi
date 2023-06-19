using Otel.Demo.DataApi.Models;
using Otel.Demo.DataApi.Services.Interfaces;
using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Services
{
    public class AssetDataService : IAssetDataService
    {
        private readonly ILogger _logger;
        private string _projectRootPath;
        private readonly ITelemetryService _telemetryService;
        private readonly IJsonDataService _jsonDataService;

        public AssetDataService(ILogger<AssetDataService> logger, IHostEnvironment hostEnvironment,
            ITelemetryService telemetryService, IJsonDataService jsonDatService)
        {
            _logger = logger;
            _projectRootPath = hostEnvironment.ContentRootPath;
            _telemetryService = telemetryService;
            _jsonDataService = jsonDatService;
        }

        public async Task<JsonArray?> GetEvents(string? assetId)
        {
            _logger.LogInformation("Entering GetEvents");
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetEvents");
            Random random = new Random();
            int delay = random.Next(200, 2000);
            await Task.Delay(delay);
            var filepath = Path.Combine(_projectRootPath, "assets//events.json");
            var jsonData = System.IO.File.ReadAllText(filepath);
            var data = JsonNode.Parse(jsonData)?.AsArray();
            _logger.LogInformation("Exiting GetEvents");
            return data;
        }

        public async Task<AssetModel?> GetAssetDetails(string? assetId)
        {
            _logger.LogInformation("Entering GetAssetDetails");
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetAssetDetails");
            Random random = new Random();
            int delay = random.Next(200, 2000);
            await Task.Delay(delay);

            AssetModel assetModel = new AssetModel();
            assetModel.AssetId = assetId;
            assetModel.AssetName = _jsonDataService.GetAssetName();
            List<string> properties = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                properties.Add(_jsonDataService.GetPropertyName());
            }
            assetModel.Variables = properties;

            _logger.LogInformation("Exiting GetAssetDetails");
            return assetModel;
        }
    }
}
