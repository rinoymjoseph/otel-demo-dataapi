using Otel.Demo.DataApi.Services.Interfaces;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Otel.Demo.DataApi.Services
{
    public class TelemetryService : ITelemetryService
    {
        private readonly ActivitySource _activitySource;
        public static Meter _meter = new(AppConstants.OTEL_SERVCICE_NAME);
        private readonly Counter<long> _getAssetDetailsReqCounter;
        private readonly Counter<long> _getEventsReqCounter;

        public TelemetryService()
        {
            _activitySource = new ActivitySource(AppConstants.OTEL_SERVCICE_NAME);
            _getAssetDetailsReqCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_ASSETDB_GET_ASSET_DETAILS);
            _getEventsReqCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_ASSETDB_GET_EVENTS);

        }

        public ActivitySource GetActivitySource()
        {
            return _activitySource;
        }

        public Counter<long> GetAssetDetailsReqCounter()
        {
            return _getAssetDetailsReqCounter;
        }

        public Counter<long> GetEventsReqCounter()
        {
            return _getEventsReqCounter;
        }
    }
}
