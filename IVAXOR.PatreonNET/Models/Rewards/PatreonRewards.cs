using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models.Rewards
{
    public class PatreonRewards
    {
        [JsonPropertyName("name")]
        public PatreonReward[] Data { get; set; }
    }
}
