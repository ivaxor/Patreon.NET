using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Responses
{
    public class PatreonResponseLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
