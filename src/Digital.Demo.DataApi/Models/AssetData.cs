﻿using System.Text.Json.Nodes;

namespace Otel.Demo.DataApi.Models
{
    public class AssetData
    {
        public string? AssetId { get; set; }
        public string? AssetName { get; set; }
        public JsonArray? VariableData { get; set; }
        public JsonArray? AlarmData { get; set; }
        public JsonArray? EventData { get; set; }
    }
}
