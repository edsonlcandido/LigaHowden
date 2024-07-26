namespace LigaHowden.Extensions
{
    public static class Extensions
    {
        public static string Slugify(this string value)
        {
            return value.ToLower()
                .Replace(" ", "-")
                .Replace(".", "") // Remove pontuação
                .Replace(",", "") // Remove pontuação
                .Replace("!", "") // Remove pontuação
                .Replace("?", "") // Remove pontuação
                .Replace("á", "a") // Remove acentuação
                .Replace("à", "a") // Remove acentuação
                .Replace("ã", "a") // Remove acentuação
                .Replace("â", "a") // Remove acentuação
                .Replace("é", "e") // Remove acentuação
                .Replace("ê", "e") // Remove acentuação
                .Replace("í", "i") // Remove acentuação
                .Replace("ó", "o") // Remove acentuação
                .Replace("õ", "o") // Remove acentuação
                .Replace("ô", "o") // Remove acentuação
                .Replace("ú", "u") // Remove acentuação
                .Replace("ü", "u") // Remove acentuação
                .Replace("ç", "c"); // Remove acentuação
        }
    }
}
