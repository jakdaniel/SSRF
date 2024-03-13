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
}