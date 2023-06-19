﻿using Otel.Demo.DataApi.Services.Interfaces;
using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Services
{
    public class AssetDataService : IAssetDataService
    {
        private readonly ILogger _logger;
        private string _projectRootPath;
        private readonly ITelemetryService _telemetryService;

        public AssetDataService(ILogger<AssetDataService> logger, IHostEnvironment hostEnvironment, ITelemetryService telemetryService)
        {
            _logger = logger;
            _projectRootPath = hostEnvironment.ContentRootPath;
            _telemetryService = telemetryService;
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

        public async Task<JsonObject?> GetAssetDetails(string? assetId)
        {
            _logger.LogInformation("Entering GetAssetDetails");
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetAssetDetails");
            Random random = new Random();
            int delay = random.Next(200, 2000);
            await Task.Delay(delay);
            var filepath = Path.Combine(_projectRootPath, "assets//assets.json");
            var jsonData = File.ReadAllText(filepath);
            var data = JsonNode.Parse(jsonData)?.AsArray();
            _logger.LogInformation("Exiting GetAssetDetails");
            return data?.First()?.AsObject();
        }
    }
}
