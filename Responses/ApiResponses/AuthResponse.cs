using LigaHowden.Data.ApiModels;
using LigaHowden.Data.DomainModels;
using System.Text.Json.Serialization;

namespace LigaHowden.Responses.ApiResponses
{
    public class AuthResponse
    {
        [JsonPropertyName("record")]
        public Auth? Auth { get; set; }
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
