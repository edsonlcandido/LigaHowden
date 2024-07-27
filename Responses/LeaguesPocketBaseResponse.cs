using System.Text.Json.Serialization;

namespace LigaHowden.Responses
{
    public class LeaguesPocketBaseResponse
    {
        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("teams")]
        public List<string> Teams { get; set; }
    }
}
