using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Services.Interfaces
{
    public interface IAssetDataService
    {
        Task<JsonObject?> GetAssetDetails(string? assetId);

        Task<JsonArray?> GetEvents(string? assetId);
    }
}
