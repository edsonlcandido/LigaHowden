using System.Text.Json.Serialization;

namespace LigaHowden.Data.ApiModels
{
    public class Auth
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("leagues")]
        public List<string>? Leagues { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("username")]
        public string? Username { get; set; }
    }
}
