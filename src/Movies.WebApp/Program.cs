using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Movies.WebApp.ApiServices;
using Movies.WebApp.HttpClients;
using Movies.WebApp.HttpHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.Authority = "https://localhost:5005";

        options.ClientId = "moviesMVCWebAppClient";
        options.ClientSecret = "movies_mvc_web_app_secret_key";
        options.ResponseType = "code id_token";
        
        options.Scope.Add("address");
        options.Scope.Add("email");
        options.Scope.Add("roles");
        options.Scope.Add("moviesAPI");

        options.ClaimActions.MapUniqueJsonKey("role", "role");

        options.SaveTokens = true;

        options.GetClaimsFromUserInfoEndpoint = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = JwtClaimTypes.GivenName,
            RoleClaimType = JwtClaimTypes.Role
        };
    });


builder.Services.AddTransient<AuthenticationDelegetingHandler>();
builder.Services.AddHttpClient<APIGatewayHttpClient>()
                .AddHttpMessageHandler<AuthenticationDelegetingHandler>();

builder.Services.AddHttpClient<IdentityServerHttpClient>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IMovieAPIService, MovieAPIService>();
builder.Services.AddScoped<IIdentityAPIService, IdentityAPIService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
