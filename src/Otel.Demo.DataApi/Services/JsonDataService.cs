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
        private JsonArray adjectives;
        private JsonArray persons;
        private JsonArray equipments;
        private JsonArray properties;

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

            var adjectives_filepath = Path.Combine(_projectRootPath, "assets//adjectives.json");
            var adjectives_json_data = System.IO.File.ReadAllText(adjectives_filepath);
            adjectives = JsonNode.Parse(adjectives_json_data)!.AsArray();

            var persons_filepath = Path.Combine(_projectRootPath, "assets//persons.json");
            var persons_json_data = System.IO.File.ReadAllText(persons_filepath);
            persons = JsonNode.Parse(persons_json_data)!.AsArray();

            var equipments_filepath = Path.Combine(_projectRootPath, "assets//equipments.json");
            var equipments_data = System.IO.File.ReadAllText(equipments_filepath);
            equipments = JsonNode.Parse(equipments_data)!.AsArray();

            var properties_filepath = Path.Combine(_projectRootPath, "assets//properties.json");
            var properties_data = System.IO.File.ReadAllText(properties_filepath);
            properties = JsonNode.Parse(properties_data)!.AsArray();
        }

        public JsonArray GetFirstNames()
        {
            return firstNames;
        }

        public JsonArray GetMiddleNames()
        {
            return middleNames;
        }

        public string GetUsername()
        {
            Random random = new Random();
            var firstNamescount = firstNames.Count;
            int firstNameIndex = random.Next(0, firstNamescount - 1);
            string firstName = firstNames[firstNameIndex]!.ToString();

            var middleNamescount = middleNames.Count;
            int middleNamesIndex = random.Next(0, middleNamescount - 1);
            string middleName = firstNames[middleNamesIndex]!.ToString();

            int time_millis = DateTime.Now.Millisecond;
            int mod_val = time_millis % 10;

            if (mod_val == 0)
            {
                throw new Exception("Error while fetching Username");
            }
            else
            {
                return $"{firstName} {middleName}";
            }
        }

        public string GetAssetName()
        {
            Random random = new Random();
            var adjectivesCount = adjectives.Count;
            int adjectivesIndex = random.Next(0, adjectivesCount - 1);
            string adjective = adjectives[adjectivesIndex]!.ToString();

            var personsCount = persons.Count;
            int personIndex = random.Next(0, personsCount - 1);
            string person = persons[personIndex]!.ToString();

            return $"{adjective} {person}";
        }

        public string GetPropertyName()
        {
            Random random = new Random();
            var equipmentsCount = equipments.Count;
            int equipmentsIndex = random.Next(0, equipmentsCount - 1);
            string equipment = equipments[equipmentsIndex]!.ToString();

            var propertiesCount = properties.Count;
            int propertiesIndex = random.Next(0, propertiesCount - 1);
            string property = properties[propertiesIndex]!.ToString();

            return $"{equipment} {property}";
        }
    }
}
