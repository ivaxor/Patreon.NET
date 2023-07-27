using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    public class PatreonResponseLinks
    {
        [JsonRequired]
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
