using Otel.Demo.DataApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;

namespace Otel.Demo.DataApi.Controllers
{
    [Route("data")]
    [ApiController]
    public class AssetDBController : ControllerBase
    {
        private readonly ITelemetryService _telemetryService;
        private readonly IAssetDBService _assetDBService;

        public AssetDBController(IConfiguration configuration, IHttpClientFactory httpClientFactory,
           ITelemetryService telemetryService, IAssetDBService assetDBService)
        {
            _telemetryService = telemetryService;
            _assetDBService = assetDBService;
        }

        [HttpGet("GetAssetDetails/{assetId}")]
        public async Task<IActionResult> GetAssetDetails(string assetId= "4de1208e-d1b7-46a1-9743-8f2b39c3ad39")
        {
            _telemetryService.GetAssetDetailsReqCounter().Add(1,
                new("Action", nameof(GetAssetDetails)),
                new("Controller", nameof(AssetDBController)));

            var contextId = Baggage.GetBaggage("ContextId");
            if (string.IsNullOrEmpty(contextId))
            {
                contextId = Guid.NewGuid().ToString();
            }
            using var activity_GetAssetData = _telemetryService.GetActivitySource().StartActivity("GetAssetDetails");
            activity_GetAssetData?.SetTag("AssetId", assetId);
            activity_GetAssetData?.SetTag("ContextId", contextId);
            activity_GetAssetData?.AddEvent(new("GetAssetDetails"));
            Baggage.SetBaggage("ContextId", contextId);
            var result = await _assetDBService.GetAssetDetails(assetId);
            return Ok(result);
        }

        [HttpGet("GetEvents/{assetId}")]
        public async Task<IActionResult> GetEvents(string assetId = "4de1208e-d1b7-46a1-9743-8f2b39c3ad39")
        {
            _telemetryService.GetEventsReqCounter().Add(1,
                new("Action", nameof(GetEvents)),
                new("Controller", nameof(AssetDBController)));

            var contextId = Baggage.GetBaggage("ContextId");
            if (string.IsNullOrEmpty(contextId))
            {
                contextId = Guid.NewGuid().ToString();
            }
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetEvents");
            activity_GetEvents?.SetTag("AssetId", assetId);
            activity_GetEvents?.SetTag("ContextId", contextId);
            activity_GetEvents?.AddEvent(new("GetEvents"));
            Baggage.SetBaggage("ContextId", contextId);
            var result = await _assetDBService.GetEvents(assetId);
            return Ok(result);
        }
    }
}
