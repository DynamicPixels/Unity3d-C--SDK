using Newtonsoft.Json;

namespace models.outputs
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
    }
}