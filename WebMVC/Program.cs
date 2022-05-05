using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebMVC.Extensions;
using WebMVC.IServices;
using WebMVC.Services;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "https://localhost:7036";// identiy server

                    options.ClientId = "eshops_mvc_client";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code id_token";

                    //options.Scope.Add("openid");
                    //options.Scope.Add("profile");
                    options.Scope.Add("address");
                    options.Scope.Add("email");
                    options.Scope.Add("roles");

                    options.ClaimActions.DeleteClaim("sid");
                    options.ClaimActions.DeleteClaim("idp");
                    options.ClaimActions.DeleteClaim("s_hash");
                    options.ClaimActions.DeleteClaim("auth_time");
                    options.ClaimActions.MapUniqueJsonKey("role", "role");

                    options.Scope.Add("eshopAPI");

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.GivenName,
                        RoleClaimType = JwtClaimTypes.Role
                    };
                });
builder.Services.AddTransient<LoggingDelegatingHandler>();
builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
               c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>().AddPolicyHandler(PolicyExtensions.GetRetryPolicy())
                .AddPolicyHandler(PolicyExtensions.GetCircuitBreakerPolicy());
builder.Services.AddHttpClient<IBasketService, BasketService>(c =>
               c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>().AddPolicyHandler(PolicyExtensions.GetRetryPolicy())
                .AddPolicyHandler(PolicyExtensions.GetCircuitBreakerPolicy());
builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
               c.BaseAddress = new Uri(configuration["ApiSettings:GatewayAddress"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>().AddPolicyHandler(PolicyExtensions.GetRetryPolicy())
                .AddPolicyHandler(PolicyExtensions.GetCircuitBreakerPolicy());
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
