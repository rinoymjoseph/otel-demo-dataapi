using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Models
{
    public class AssetModel
    {
        public string? AssetId { get; set; }
        public string? AssetName { get; set; }
        public List<string>? Variables { get; set; }
    }
}
