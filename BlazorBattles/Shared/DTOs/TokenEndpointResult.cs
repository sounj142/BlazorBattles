using System.Text.Json.Serialization;

namespace BlazorBattles.Shared.DTOs
{
    public class TokenEndpointResult
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
