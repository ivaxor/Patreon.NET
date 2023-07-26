using System.Text.Json.Serialization;

namespace IVAXOR.PatreonNET.Models
{
    public class PatreonRewards
    {
        [JsonPropertyName("name")]
        public PatreonReward[] Data { get; set; }        
    }
}
