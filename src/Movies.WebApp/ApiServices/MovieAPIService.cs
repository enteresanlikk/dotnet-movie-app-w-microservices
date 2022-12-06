using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movies.WebApp.HttpClients;
using Movies.WebApp.Models;
using Movies.WebApp.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Movies.WebApp.ApiServices;

public class MovieAPIService : IMovieAPIService
{
    private readonly APIGatewayHttpClient _httpClient;

    public MovieAPIService(APIGatewayHttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Movie> CreateMovie(Movie movie)
    {
        var data = JsonConvert.SerializeObject(movie);
        var request = new HttpRequestMessage(HttpMethod.Post, $"/movies");
        request.Content = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await _httpClient.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Movie>(content);
    }

    public async Task DeleteMovie(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/movies/{id}");
        var response = await _httpClient.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
    }

    public async Task<Movie> GetMovie(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/movies/{id}");
        var response = await _httpClient.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Movie>(content);
    }

    public async Task<IEnumerable<Movie>> GetMovies()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/movies");
        var response = await _httpClient.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<Movie>>(content);
    }

    public async Task<Movie> UpdateMovie(Movie movie)
    {
        var data = JsonConvert.SerializeObject(movie);
        var request = new HttpRequestMessage(HttpMethod.Put, $"/movies/{movie.Id}");
        request.Content = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await _httpClient.Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Movie>(content);
    }
}
