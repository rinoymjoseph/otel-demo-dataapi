using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;
using Otel.Demo.DataApi.Services.Interfaces;

namespace Otel.Demo.DataApi.Controllers
{
    [Route("userdata")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private ILogger _logger;
        private readonly ITelemetryService _telemetryService;
        private readonly IUserDataService _userDataService;

        public UserDataController(ILogger<UserDataController> logger, ITelemetryService telemetryService, IUserDataService userDataService)
        {
            _logger = logger;
            _telemetryService = telemetryService;
            _userDataService = userDataService;
        }

        [HttpGet("GetUsername")]
        public IActionResult GetUsername()
        {
            _logger.LogInformation("Entering GetUsername");
            _telemetryService.GetEventsReqCounter().Add(1,
                new("Action", nameof(GetUsername)),
                new("Controller", nameof(UserDataController)));

            var contextId = Baggage.GetBaggage("ContextId");
            if (string.IsNullOrEmpty(contextId))
            {
                contextId = Guid.NewGuid().ToString();
            }
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetUsername");
            activity_GetEvents?.SetTag("ContextId", contextId);
            Baggage.SetBaggage("ContextId", contextId);
            var result = _userDataService.GetUsername();
            _logger.LogInformation("Exiting GetUserName");
            return Ok(result);
        }
    }
}
