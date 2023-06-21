using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OpenTelemetry;
using Otel.Demo.DataApi.Services.Interfaces;

namespace Otel.Demo.DataApi.Controllers
{
    [Route("assetdata")]
    [ApiController]
    public class AssetDataController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ITelemetryService _telemetryService;
        private readonly IAssetDataService _assetDataService;

        public AssetDataController(ILogger<AssetDataController> logger, ITelemetryService telemetryService, IAssetDataService assetDataService)
        {
            _logger = logger;
            _telemetryService = telemetryService;
            _assetDataService = assetDataService;
        }

        [HttpGet("GetAssetDetails/{assetId}")]
        public async Task<IActionResult> GetAssetDetails(string assetId = "4de1208e-d1b7-46a1-9743-8f2b39c3ad39")
        {
            _logger.LogInformation($"Entering GetAssetDetails : {assetId}");
            _telemetryService.GetAssetDetailsReqCounter().Add(1,
                new("Action", nameof(GetAssetDetails)),
                new("Controller", nameof(AssetDataController)));

            var contextId = Baggage.GetBaggage("ContextId");
            if (string.IsNullOrEmpty(contextId))
            {
                contextId = Guid.NewGuid().ToString();
            }
            using var activity_GetAssetData = _telemetryService.GetActivitySource().StartActivity("GetAssetDetails");
            activity_GetAssetData?.SetTag("AssetId", assetId);
            activity_GetAssetData?.SetTag("ContextId", contextId);
            Baggage.SetBaggage("ContextId", contextId);

            try
            {
                var result = await _assetDataService.GetAssetDetails(assetId);
                _telemetryService.GetAssetDetailsReqSuccesCounter().Add(1,
                  new("Action", nameof(GetAssetDetails)),
                  new("Controller", nameof(AssetDataController)));
                _logger.LogInformation($"Exiting GetAssetDetails : {assetId}");
                return Ok(result);
            }
            catch (Exception)
            {
                _telemetryService.GetAssetDetailsReqFailureCounter().Add(1,
                  new("Action", nameof(GetAssetDetails)),
                  new("Controller", nameof(AssetDataController)));
                throw;
            }
        }
    }
}
