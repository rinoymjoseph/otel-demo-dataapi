﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTelemetry;
using Otel.Demo.DataApi.Services.Interfaces;

namespace Otel.Demo.DataApi.Controllers
{
    [Route("variabledata")]
    [ApiController]
    public class VariableDataController : ControllerBase
    {
        private ILogger _logger;
        private readonly ITelemetryService _telemetryService;
        private readonly IVariableDataService _variableDataService;

        public VariableDataController(ILogger<UserDataController> logger, ITelemetryService telemetryService, IVariableDataService variableDataService)
        {
            _logger = logger;
            _telemetryService = telemetryService;
            _variableDataService = variableDataService;
        }

        [HttpGet("GetVariableValue/{variableName}")]
        public async Task<IActionResult> GetVariableValue(string variableName = "test")
        {
            _logger.LogInformation($"Entering GetVariableValue : {variableName}");
            _telemetryService.GetVariableValueReqCounter().Add(1,
                new("Action", nameof(GetVariableValue)),
                new("Controller", nameof(VariableDataController)));

            var contextId = Baggage.GetBaggage("ContextId");
            if (string.IsNullOrEmpty(contextId))
            {
                contextId = Guid.NewGuid().ToString();
            }
            using var activity_GetEvents = _telemetryService.GetActivitySource().StartActivity("GetVariableValue");
            activity_GetEvents?.SetTag("ContextId", contextId);
            Baggage.SetBaggage("ContextId", contextId);

            try
            {
                var result = await _variableDataService.GetVariableValue(variableName);
                _telemetryService.GetVariableValueReqSuccessCounter().Add(1,
                    new("Action", nameof(GetVariableValue)),
                    new("Controller", nameof(VariableDataController)));
                _logger.LogInformation($"Exiting GetVariableValue : {variableName}");
                return Ok(result);
            }
            catch (Exception) 
            {
                _telemetryService.GetVariableValueReqFailureCounter().Add(1,
                    new("Action", nameof(GetVariableValue)),
                    new("Controller", nameof(VariableDataController)));
                throw;
            }
        }
    }
}
