using System.Text.Json.Serialization;

namespace LigaHowden.Responses.ApiResponses
{
    public class LeaguesViewResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("collectionId")]
        public string CollectionId { get; set; }
        [JsonPropertyName("collectionName")]
        public string Collectionname { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("teams")]
        public List<string> Teams { get; set; }
        [JsonPropertyName("owner")]
        public string Owner { get; set; }
    }
}