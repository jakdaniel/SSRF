using System.Text.RegularExpressions;

namespace WebApplication2;

public interface ISsrfService
{
    Task<string> SsrfTokenAsync(string domain);
}

public class SsrfService(IHttpClientFactory httpClientFactory) : ISsrfService
{
    public async Task<string> SsrfTokenAsync(string domain)
    {
        var httpClient = httpClientFactory.CreateClient("demo");
        var url = $"todos/{domain}";
        var response = await httpClient.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    static bool IsValidDomain(string input)
    {
        string pattern = @"^(https?:\/\/)?[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
        return Regex.IsMatch(input, pattern);
    }

    // Liste blanche de domaines autorisés
    var allowedDomains = new[] { "example.com", "example.org" };

    // Méthode pour valider l'identifiant de message
    private bool ValidateMessageId(string messageId)
    {
        return !string.IsNullOrWhiteSpace(messageId) && messageId.Length <= 10;
    }

    // Exemple d'utilisation de la méthode de validation et de UriBuilder
    string messageId = "abc123";
if (ValidateMessageId(messageId))
{
    var uriBuilder = new UriBuilder("https://example.com");
    uriBuilder.Path = $"/messages/{messageId}";

    // Vérification que le domaine appartient à la liste blanche de domaines autorisés
    if (allowedDomains.Contains(uriBuilder.Host))
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(uriBuilder.Uri);
    // Traitement de la réponse...
}
    }
    else
{
    // Le domaine n'est pas autorisé, vous devez retourner une erreur ou arrêter le traitement
}
}
else
{
    // L'identifiant de message n'est pas valide, vous devez retourner une erreur ou arrêter le traitement
}
}