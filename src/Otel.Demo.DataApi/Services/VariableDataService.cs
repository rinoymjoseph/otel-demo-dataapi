using Otel.Demo.DataApi.Services.Interfaces;

namespace Otel.Demo.DataApi.Services
{
    public class VariableDataService : IVariableDataService
    {
        private readonly ITelemetryService _telemetryService;

        public VariableDataService(ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
        }

        public async Task<double> GetVariableValue(string variableName)
        {
            using var activity_GetVariableValue = _telemetryService.GetActivitySource().StartActivity("GetVariableValue");
            Random random = new Random();
            int delay = random.Next(250, 2500);
            await Task.Delay(delay);
            return random.NextDouble() * 10;
        }
    }
}
