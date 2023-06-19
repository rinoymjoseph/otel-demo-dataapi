using Otel.Demo.DataApi.Services.Interfaces;

namespace Otel.Demo.DataApi.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly ITelemetryService _telemetryService;
        private readonly IJsonDataService _jsonDataService;

        public UserDataService(IHostEnvironment hostEnvironment, ITelemetryService telemetryService,
            IJsonDataService jsonDataService)
        {
            _telemetryService = telemetryService;
            _jsonDataService = jsonDataService;
        }

        public string GetUserName()
        {
            return _jsonDataService.GetUserName();
        }
    }
}
