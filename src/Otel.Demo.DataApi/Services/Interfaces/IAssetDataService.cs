using Otel.Demo.DataApi.Models;
using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Services.Interfaces
{
    public interface IAssetDataService
    {
        Task<AssetModel?> GetAssetDetails(string? assetId);
    }
}
