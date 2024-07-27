namespace LigaHowden.Data
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<string> Leagues { get; set; } = new List<string>();

    }
}
