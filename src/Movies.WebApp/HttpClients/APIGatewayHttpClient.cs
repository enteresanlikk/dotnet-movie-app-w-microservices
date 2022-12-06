using Microsoft.Net.Http.Headers;

namespace Movies.WebApp.HttpClients;

public class APIGatewayHttpClient
{
    public HttpClient Client { get; private set; }

    public APIGatewayHttpClient(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("https://localhost:5010");
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

        Client = httpClient;
    }
}
