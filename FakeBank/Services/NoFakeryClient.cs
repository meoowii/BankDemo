using System.Net.Http.Json;

namespace FakeBank.Services;

public class NoFakeryClient : INoFakeryClient
{
    private readonly HttpClient _httpClient;

    public NoFakeryClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task RegisterDocumentAsync(RegisterDocumentRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/api/documents", request);

            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"NoFakery returned {response.StatusCode}: {body}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("NoFakery exception:", ex);
        }
    }

}