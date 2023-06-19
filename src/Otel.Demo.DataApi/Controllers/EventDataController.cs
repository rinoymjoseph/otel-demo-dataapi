using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;
using Otel.Demo.DataApi.Services.Interfaces;

namespace Otel.Demo.DataApi.Controllers
{
    [Route("eventdata")]
    [ApiController]
    public class EventDataController : ControllerBase
    {
        private ILogger _logger;
        private readonly ITelemetryService _telemetryService;
        private readonly IEventDataService _eventDataService;

        public EventDataController(ILogger<EventDataController> logger, ITelemetryService telemetryService, IEventDataService eventDataService)
        {
            _logger = logger;
            _telemetryService = telemetryService;
            _eventDataService = eventDataService;
        }

        [HttpGet("GetEvents/{assetId}")]
        public async Task<IActionResult> GetEvents(string assetId = "4de1208e-d1b7-46a1-9743-8f2b39c3ad39")
        {
            _logger.LogInformation("Entering GetEvents");
            _telemetryService.GetEventsReqCounter().Add(1,
                new("Action", nameof(GetEvents)),
                new("Controller", nameof(EventDataController)));

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
            var result = await _eventDataService.GetEvents(assetId);
            _logger.LogInformation("Exiting GetEvents");
            return Ok(result);
        }
    }
}
