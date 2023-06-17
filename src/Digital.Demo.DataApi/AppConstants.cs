﻿namespace Otel.Demo.DataApi
{
    public class AppConstants
    {
        public const string OTEL_SERVCICE_NAME = "DataApi";

        public const string URL_OTEL_EXPORTER = "otel_exporter_url";
        public const string URL_ASSETDB_API = "assetdb_api_url";
        public const string URL_VARIABLE_API = "varialbe_api_url";
        public const string URL_EVENT_API = "event_api_url";
        public const string URL_ALARM_API = "alarm_api_url";

        public const string REQUEST_GET_ASSET_DETAILS = "/assetdb/GetAssetDetails";
        public const string REQUEST_GET_VARIABLE_DATA = "/variable/GetVariableData";
        public const string REQUEST_GET_EVENT_DATA = "/event/GetEventsOfAsset";

        public const string COUNTER_ASSET_GET_ASSET_DATA = "asset_api_get_asset_data_requests";
        public const string COUNTER_ASSET_GET_ASSET_DATA_SEQ = "asset_api_get_asset_data_seq_requests";
    }
}
