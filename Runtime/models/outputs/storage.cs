using Newtonsoft.Json;

namespace DynamicPixels.GameService.Models.outputs
{
    public class FileMetadata
    {
        [JsonProperty("name")]
        public string Name = "";
        [JsonProperty("hash")]
        public string Hash = "";
        [JsonProperty("content_type")]
        public string ContentType = "";
        [JsonProperty("size")]
        public int Size = 0;
        [JsonProperty("last_modify")]
        public string LastModify = "";
        [JsonProperty("expire")]
        public string Expire = "";
        [JsonProperty("version_id")]
        public int VersionId = 0;
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
    public class FileMetaForUpload
    {
        [JsonProperty("file_name")]
        public string Name = "";
        [JsonProperty("content_type")]
        public string ContentType = "";
        
        public string row { get; set; }
        
        public byte[] FileContent { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    
}