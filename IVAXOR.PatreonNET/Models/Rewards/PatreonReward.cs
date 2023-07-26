using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Rewards
{
    public class PatreonReward
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
