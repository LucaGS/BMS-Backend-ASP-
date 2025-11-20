using System.Net;
using System.Net.Http.Json;
using DotNet8.WebApi.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace DotNet8.ScalarWebApi.Tests;

public class AuthEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AuthEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    private WebApplicationFactory<Program> CreateDevelopmentFactory()
    {
        return _factory.WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment(Environments.Development);
        });
    }

    [Fact]
    public async Task LoginEndpoint_AllowsPostRequests()
    {
        using var factory = CreateDevelopmentFactory();
        using var client = factory.CreateClient();

        var uniqueSuffix = Guid.NewGuid().ToString("N");
        var registrationPayload = new UserDto
        {
            Username = $"integration-user-{uniqueSuffix}",
            Password = "P@ssword123!",
            Email = $"integration-user-{uniqueSuffix}@example.com"
        };

        var registerResponse = await client.PostAsJsonAsync("/api/Auth/Register", registrationPayload);
        registerResponse.EnsureSuccessStatusCode();

        var loginPayload = new UserDto
        {
            Username = registrationPayload.Username,
            Password = registrationPayload.Password,
            Email = registrationPayload.Email
        };

        var loginResponse = await client.PostAsJsonAsync("/api/Auth/Login", loginPayload);

        Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);
    }

    [Fact]
    public async Task LoginEndpoint_Returns405ForGetRequests()
    {
        using var factory = CreateDevelopmentFactory();
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/api/Auth/Login");

        Assert.Equal(HttpStatusCode.MethodNotAllowed, response.StatusCode);
        if (response.Headers.TryGetValues("Allow", out var allowedMethods))
        {
            Assert.Contains("POST", allowedMethods);
        }
    }
}
