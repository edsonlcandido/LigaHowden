using System.Security;
using System.Text.Json.Serialization;

namespace LigaHowden.Responses.ApiResponses
{
    public class LeagueCreateResponse
    {
        [JsonPropertyName("collectionId")]
        public string CollectionId { get; set; } = string.Empty;
        [JsonPropertyName("collectionName")]
        public string ColectionName { get; set; } = string.Empty;
        [JsonPropertyName("created")]
        public string Created { get; set; } = string.Empty;
        [JsonPropertyName("updated")]
        public string Updated { get; set; } = string.Empty;
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("slug")]
        public string Slug { get; set; } = string.Empty;
        [JsonPropertyName("teams")]
        public List<string> Teams { get; set; } = new List<string>();
    }
}