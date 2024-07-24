public class UserSession
{
    public string UserName { get; set; } = "anonymous";
    public string Role { get; set; } = "";
    public string Token { get; set; } = "";
    public string Name { get; set; } = "anonymous";
    public List<string>Leagues { get; set; } = new List<string>();
}
