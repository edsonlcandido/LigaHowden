namespace LigaHowden.Data
{
    public class League
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public List<string> Teams { get; set; } = new List<string>();

    }
}
