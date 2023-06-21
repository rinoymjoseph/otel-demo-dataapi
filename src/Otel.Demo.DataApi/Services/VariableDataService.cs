using Otel.Demo.DataApi.Services.Interfaces;

namespace Otel.Demo.DataApi.Services
{
    public class VariableDataService : IVariableDataService
    {
        private ILogger _logger;
        private readonly ITelemetryService _telemetryService;

        public VariableDataService(ILogger<VariableDataService> logger, ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
            _logger = logger;
        }

        public async Task<double> GetVariableValue(string variableName)
        {
            _logger.LogInformation($"Entering GetVariableValue : {variableName}");
            using var activity_GetVariableValue = _telemetryService.GetActivitySource().StartActivity("GetVariableValue");
            Random random = new Random();
            int delay = random.Next(250, 2500);
            await Task.Delay(delay);
            int time_millis = DateTime.Now.Millisecond;
            int mod_val = time_millis % 20;
            if (mod_val == 0)
            {
                throw new Exception($"Error while fetching variable value for variableName");
            }
            else
            {
                _logger.LogInformation($"Exiting GetVariableValue : {variableName}");
                return random.NextDouble() * 10;
            }
        }
    }
}
