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
        private readonly Counter<long> _getAssetDetailsReqSuccessCounter;
        private readonly Counter<long> _getAssetDetailsReqFailureCounter;
        private readonly Counter<long> _getEventsReqCounter;
        private readonly Counter<long> _getEventsReqSuccessCounter;
        private readonly Counter<long> _getEventsReqFailureCounter;
        private readonly Counter<long> _getUserameReqCounter;
        private readonly Counter<long> _getUsernameReqSuccessCounter;
        private readonly Counter<long> _getUsernameReqFailureCounter;
        private readonly Counter<long> _getVariableValueReqCounter;
        private readonly Counter<long> _getVariableValueReqSuccessCounter;
        private readonly Counter<long> _getVariableValueReqFailureCounter;

        public TelemetryService()
        {
            _activitySource = new ActivitySource(AppConstants.OTEL_SERVCICE_NAME);
            _getAssetDetailsReqCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_ASSET_DETAILS_REQUESTS);
            _getAssetDetailsReqSuccessCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_ASSET_DETAILS_REQUESTS_SUCCESS);
            _getAssetDetailsReqFailureCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_ASSET_DETAILS_REQUESTS_FAILURE);
            _getEventsReqCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_EVENTS_REQUESTS);
            _getEventsReqSuccessCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_EVENTS_REQUESTS_SUCCESS);
            _getEventsReqFailureCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_EVENTS_REQUESTS_FAILURE);
            _getUserameReqCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_USERNAME_REQUESTS);
            _getUsernameReqSuccessCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_USERNAME_REQUESTS_SUCCESS);
            _getUsernameReqFailureCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_USERNAME_REQUESTS_FAILURE);
            _getVariableValueReqCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_VARIABLE_VALUE_REQUESTS);
            _getVariableValueReqSuccessCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_VARIABLE_REQUESTS_SUCCESS);
            _getVariableValueReqFailureCounter = _meter.CreateCounter<long>(AppConstants.COUNTER_DATA_API_GET_VARIABLE_REQUESTS_FAILURE);
        }

        public ActivitySource GetActivitySource()
        {
            return _activitySource;
        }

        public Counter<long> GetAssetDetailsReqCounter()
        {
            return _getAssetDetailsReqCounter;
        }

        public Counter<long> GetAssetDetailsReqSuccesCounter()
        {
            return _getAssetDetailsReqSuccessCounter;
        }

        public Counter<long> GetAssetDetailsReqFailureCounter()
        {
            return _getAssetDetailsReqFailureCounter;
        }

        public Counter<long> GetEventsReqCounter()
        {
            return _getEventsReqCounter;
        }
        public Counter<long> GetEventsReqSuccessCounter()
        {
            return _getEventsReqSuccessCounter;
        }

        public Counter<long> GetEventsReqFailureCounter()
        {
            return _getEventsReqFailureCounter;
        }

        public Counter<long> GetUsernameReqCounter()
        {
            return _getUserameReqCounter;
        }
        public Counter<long> GetUsernameReqSuccessCounter()
        {
            return _getUsernameReqSuccessCounter;
        }

        public Counter<long> GetUsernameReqFailureCounter()
        {
            return _getUsernameReqFailureCounter;
        }

        public Counter<long> GetVariableValueReqCounter()
        {
            return _getVariableValueReqCounter;
        }
        public Counter<long> GetVariableValueReqSuccessCounter()
        {
            return _getVariableValueReqSuccessCounter;
        }

        public Counter<long> GetVariableValueReqFailureCounter()
        {
            return _getVariableValueReqFailureCounter;
        }
    }
}
