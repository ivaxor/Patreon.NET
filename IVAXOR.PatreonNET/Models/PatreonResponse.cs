using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonResponse<TData>
        where TData : class
    {
        [JsonPropertyName("data")]
        public TData Data { get; set; }

        [JsonIgnore]
        [JsonPropertyName("included")]
        public object Included { get; set; }

        [JsonIgnore]
        [JsonPropertyName("links")]
        public object Links { get; set; }
    }
}
