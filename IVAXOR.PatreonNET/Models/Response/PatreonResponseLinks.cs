using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Response
{
    public class PatreonResponseLinks
    {
        [JsonPropertyName("self")]
        public string Self { get; set; }
    }
}
