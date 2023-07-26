using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    public abstract class PatreonResponseBase
    {
        [JsonPropertyName("included")]
        public PatreonIncludeData[]? Included { get; set; }

        [JsonPropertyName("links")]
        public PatreonResponseLinks? Links { get; set; }
    }
}
