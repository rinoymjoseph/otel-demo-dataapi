﻿namespace Otel.Demo.DataApi
{
    public class AppConstants
    {
        public const string OTEL_SERVCICE_NAME = "DataApi";
        public const string OTEL_EXPORTER_URL = "otel_exporter_url";

        public const string COUNTER_DATA_GET_ASSET_DETAILS = "data_api_get_asset_details_requests";
        public const string COUNTER_DATA_GET_EVENTS = "data_api_get_events_requests";

        public static readonly string HTTP_STATUS_CODE_403_ERROR = "Response status code does not indicate success: 403 (Forbidden).";
        public static readonly string HTTP_STATUS_CODE_401_ERROR = "Response status code does not indicate success: 401 (Unauthorized).";
    }
}
