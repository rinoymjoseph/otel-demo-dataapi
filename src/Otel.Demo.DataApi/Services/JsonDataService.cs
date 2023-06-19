using Otel.Demo.DataApi.Services.Interfaces;
using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Services
{
    public class JsonDataService : IJsonDataService
    {
        private string _projectRootPath;
        private readonly ITelemetryService _telemetryService;

        private JsonArray firstNames;
        private JsonArray middleNames;

        public JsonDataService(IHostEnvironment hostEnvironment, ITelemetryService telemetryService)
        {
            _projectRootPath = hostEnvironment.ContentRootPath;
            _telemetryService = telemetryService;

            var first_names_filepath = Path.Combine(_projectRootPath, "assets//first_names.json");
            var first_names_jsonData = System.IO.File.ReadAllText(first_names_filepath);
            firstNames = JsonNode.Parse(first_names_jsonData)!.AsArray();

            var middle_names_filepath = Path.Combine(_projectRootPath, "assets//middle_names.json");
            var middle_names_jsonData = System.IO.File.ReadAllText(middle_names_filepath);
            middleNames = JsonNode.Parse(middle_names_jsonData)!.AsArray();
        }

        public JsonArray GetFirstNames()
        {
            return firstNames;
        }

        public JsonArray GetMiddleNames()
        {
            return middleNames;
        }

        public string GetUserName()
        {
            Random random = new Random();
            var firstNamescount = firstNames.Count;
            int firstNameIndex = random.Next(0, firstNamescount - 1);
            string firstName = firstNames[firstNameIndex]!.ToString();

            var middleNamescount = middleNames.Count;
            int middleNamesIndex = random.Next(0, middleNamescount - 1);
            string middleName = firstNames[middleNamesIndex]!.ToString();

            return $"{firstName} {middleName}";
        }
    }
}
