using Microsoft.Net.Http.Headers;

namespace Movies.WebApp.HttpClients;

public class IdentityServerHttpClient
{
    public HttpClient Client { get; private set; }

    public IdentityServerHttpClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://localhost:5005");
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        
        Client = httpClient;
    }
}
