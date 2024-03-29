using System;
using System.Collections.Generic;
using System.Numerics;
using models.dto;
using Newtonsoft.Json;

namespace models.outputs
{
    public class RowListResponse
    {
        [JsonProperty("list")]
        public List<Row> List { get; set; } = new List<Row>();
        [JsonProperty("totalCount")]
        public Int64 TotalCount { get; set; }
    }
    
    public class RowListResponse<T>
    {
        [JsonProperty("list")]
        public List<T> List { get; set; } = new List<T>();
        [JsonProperty("totalCount")]
        public Int64 TotalCount { get; set; }
    }

    public class RowResponse
    {
        public Row Row { get; set; }
    }

    public class RowResponse<T>
    {
        [JsonProperty("row")]
        public T Row { get; set; }
    }
    public class ActionResponse
    {
        public int Affected { get; set; }
    }
}