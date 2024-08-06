using System.Text.Json.Serialization;

namespace LigaHowden.Services
{
    internal class TeamResponse
    {
        // criar uma classe com essas propriedades e atribuir rotulos de propriedades
        // {
        //     "id": "RECORD_ID",
        //     "collectionId": "e40oxht0pcucmny",
        //     "collectionName": "teams",
        //     "created": "2022-01-01 01:00:00.123Z",
        //     "updated": "2022-01-01 23:59:59.456Z",
        //     "team_id": "test",
        //     "name": "test",
        //     "slug": "test",
        //     "cartola": "test",
        //     "user_id": "RELATION_RECORD_ID"
        // }
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("collectionId")]
        public string CollectionId { get; set; } = string.Empty;
        [JsonPropertyName("collectionName")]
        public string CollectionName { get; set; } = string.Empty;
        [JsonPropertyName("created")]
        public string Created { get; set; } = string.Empty;
        [JsonPropertyName("updated")]
        public string Updated { get; set; } = string.Empty;
        [JsonPropertyName("team_id")]
        public string TeamId { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("slug")]
        public string Slug { get; set; } = string.Empty;
        [JsonPropertyName("cartola")]
        public string Cartola { get; set; } = string.Empty;
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = string.Empty;
    }
}