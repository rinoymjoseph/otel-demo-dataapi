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

        [HttpGet("GetUserName")]
        public IActionResult GetUserName()
        {
            _logger.LogInformation("Entering GetUserName");
            _telemetryService.GetEventsReqCounter().Add(1,
                new("Action", nameof(GetUserName)),
                new("Controller", nameof(UserDataController)));

            var contextId = Baggage.GetBaggage("ContextId");
            if (string.IsNullOrEmpty(contextId))
            {
                contextId = Guid.NewGuid().ToString();
            }
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetUserName");
            activity_GetEvents?.SetTag("ContextId", contextId);
            activity_GetEvents?.AddEvent(new("GetUserName"));
            Baggage.SetBaggage("ContextId", contextId);
            var result = _userDataService.GetUserName();
            _logger.LogInformation("Exiting GetUserName");
            return Ok(result);
        }
    }
}
