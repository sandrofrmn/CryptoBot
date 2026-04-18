using CryptoBot.Domain.Configuration;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace CryptoBot.Bitvavo;

public class BitvavoClient(IOptions<BitvavoOptions> options, HttpClient httpClient)
{
    private readonly IOptions<BitvavoOptions> _options = options;
    private readonly HttpClient _httpClient = httpClient;

    private HttpRequestMessage BuildRequest(HttpMethod method, string path, string body)
    {
        var apiKey = _options.Value.ApiKey;
        var secret = _options.Value.ApiSecret;
        var baseUrl = _options.Value.BaseUrl;
        var timestamp = BitvavoAuth.GetTimeStamp();

        var signature = BitvavoAuth.CreateSignature(secret, timestamp, method.Method, path, body);

        var httpRequestMessage = new HttpRequestMessage(method, path);

        if (!string.IsNullOrEmpty(body))
            httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");

        httpRequestMessage.Headers.Add("Bitvavo-Access-Key", apiKey);
        httpRequestMessage.Headers.Add("Bitvavo-Access-Timestamp", timestamp.ToString());
        httpRequestMessage.Headers.Add("Bitvavo-Access-Signature", signature);
        httpRequestMessage.Headers.Add("Bitvavo-Access-Window", 10000.ToString());

        return httpRequestMessage;
    }

    private async Task<T> SendAsync<T>(HttpRequestMessage httpRequestMessage)
    {
        var response = await _httpClient.SendAsync(httpRequestMessage);

        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"{response.StatusCode}: {body}");
        }

        return JsonSerializer.Deserialize<T>(body, _jsonOptions)!;
    }

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}
