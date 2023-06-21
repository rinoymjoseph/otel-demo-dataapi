namespace Otel.Demo.DataApi
{
    public class AppConstants
    {
        public const string OTEL_SERVCICE_NAME = "DataApi";
        public const string OTEL_EXPORTER_URL = "Otel:ExporterUrl";
        public const string OTEL_ENABLE_LOGGING = "Otel:EnableLogging";
        public const string OTEL_ENABLE_TRACING = "Otel:EnableTracing";
        public const string OTEL_ENABLE_METRICS = "Otel:EnableMetrics";

        public const string COUNTER_DATA_API_GET_ASSET_DETAILS_REQUESTS = "data_api_get_asset_details_requests";
        public const string COUNTER_DATA_API_GET_ASSET_DETAILS_REQUESTS_SUCCESS = "data_api_get_asset_details_requests_success";
        public const string COUNTER_DATA_API_GET_ASSET_DETAILS_REQUESTS_FAILURE = "data_api_get_asset_details_requests_failure";
        
        public const string COUNTER_DATA_API_GET_EVENTS_REQUESTS = "data_api_get_events_requests";
        public const string COUNTER_DATA_API_GET_EVENTS_REQUESTS_SUCCESS = "data_api_get_events_requests_success";
        public const string COUNTER_DATA_API_GET_EVENTS_REQUESTS_FAILURE = "data_api_get_events_requests_failure";

        public const string COUNTER_DATA_API_GET_USERNAME_REQUESTS = "data_api_get_username_requests";
        public const string COUNTER_DATA_API_GET_USERNAME_REQUESTS_SUCCESS = "data_api_get_username_requests_success";
        public const string COUNTER_DATA_API_GET_USERNAME_REQUESTS_FAILURE = "data_api_get_username_requests_failure";

        public const string COUNTER_DATA_API_GET_VARIABLE_VALUE_REQUESTS = "data_api_get_variable_value_requests";
        public const string COUNTER_DATA_API_GET_VARIABLE_REQUESTS_SUCCESS = "data_api_get_variable_value_requests_success";
        public const string COUNTER_DATA_API_GET_VARIABLE_REQUESTS_FAILURE = "data_api_get_variable_value_requests_failure";

        public static readonly string HTTP_STATUS_CODE_403_ERROR = "Response status code does not indicate success: 403 (Forbidden).";
        public static readonly string HTTP_STATUS_CODE_401_ERROR = "Response status code does not indicate success: 401 (Unauthorized).";
    }
}
