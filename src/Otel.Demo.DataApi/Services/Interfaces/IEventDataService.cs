using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Services.Interfaces
{
    public interface IEventDataService
    {
        Task<JsonArray?> GetEvents(string? assetId);
    }
}
