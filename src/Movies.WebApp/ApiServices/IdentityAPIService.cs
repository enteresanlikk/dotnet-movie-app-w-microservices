using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Movies.WebApp.HttpClients;
using Movies.WebApp.ViewModels;
using System.Net.Http;

namespace Movies.WebApp.ApiServices;

public class IdentityAPIService : IIdentityAPIService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IdentityServerHttpClient _httpClient;

    public IdentityAPIService(IdentityServerHttpClient httpClient, IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        _httpClient = httpClient;
    }

    public async Task<UserInfoViewModel> GetUserInfo()
    {
        var discoveryDocumentResponse = await _httpClient.Client.GetDiscoveryDocumentAsync();
        if (discoveryDocumentResponse.IsError)
        {
            throw new Exception("get user info error.");
        }
        var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        var userInfoResponse = await _httpClient.Client.GetUserInfoAsync(new UserInfoRequest
        {
            Address = discoveryDocumentResponse.UserInfoEndpoint,
            Token = accessToken
        });
        if (userInfoResponse.IsError)
        {
            throw new Exception("get user detail data error.");
        }

        var userInfoDictionary = new Dictionary<string, string>();

        foreach (var claim in userInfoResponse.Claims)
        {
            userInfoDictionary.Add(claim.Type, claim.Value);
        }

        return new UserInfoViewModel(userInfoDictionary);
    }
}
