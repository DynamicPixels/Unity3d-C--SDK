using System.Collections.Generic;
using Newtonsoft.Json;

namespace DynamicPixels.GameService.Services.Table.Models
{
    public class AggregationParams
    {
        public string TableId { get; set; }
        public string[] Stack { get; set; }
    }

    public class FindParams
    {
        public string tableId { get; set; }
        public FindOptions options { get; set; }
    }

    public class FindByIdParams
    {
        public string TableId { get; set; } 
        public int RowId { get; set; }
    }

    public class FindByIdAndDeleteParams
    {
        public string TableId { get; set; } 
        public int RowId { get; set; }
    }
    
    public class FindByIdAndUpdateParams
    {
        public string TableId { get; set; } 
        public int RowId { get; set; }
        public dynamic Data { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class InsertParams
    {
        public string TableId { get; set; }
        [JsonProperty("data")]
        public dynamic Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class InsertManyParams
    {
        public string TableId { get; set; }
        [JsonProperty("data")]
        public List<dynamic> Data { get; set; }
        
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class UpdateManyParams 
    {
        public string TableId { get; set; }
        public UpdateOptions Options { get; set; }
    }

    public class DeleteParams
    {
        public string TableId { get; set; }
        [JsonProperty("ids")]
        public int[] RowIds { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class DeleteManyParams
    {
        public string TableId { get; set; }
        public DeleteOptions Options { get; set; }
    }
}