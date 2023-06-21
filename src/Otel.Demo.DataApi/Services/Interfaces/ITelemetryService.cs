using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Otel.Demo.DataApi.Services.Interfaces
{
    public interface ITelemetryService
    {
        ActivitySource GetActivitySource();

        Counter<long> GetAssetDetailsReqCounter();

        Counter<long> GetAssetDetailsReqSuccesCounter();

        Counter<long> GetAssetDetailsReqFailureCounter();

        Counter<long> GetEventsReqCounter();

        Counter<long> GetEventsReqSuccessCounter();

        Counter<long> GetEventsReqFailureCounter();

        Counter<long> GetUsernameReqCounter();

        Counter<long> GetUsernameReqSuccessCounter();

        Counter<long> GetUsernameReqFailureCounter();

        Counter<long> GetVariableValueReqCounter();

        Counter<long> GetVariableValueReqSuccessCounter();

        Counter<long> GetVariableValueReqFailureCounter();
    }
}
