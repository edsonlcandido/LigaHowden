using LigaHowden.Data;

namespace LigaHowden.Responses
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public Record Record { get; set; } = new Record();
    }
}
