using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Otel.Demo.DataApi.Services.Interfaces
{
    public interface ITelemetryService
    {
        ActivitySource GetActivitySource();

        Counter<long> GetAssetDataReqCounter();

        Counter<long> GetAssetDataSeqReqCounter();
    }
}
