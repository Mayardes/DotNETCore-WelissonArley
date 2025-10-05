using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using CommonTestUtilities.Requests.User;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using MyBookOfRecipes.API;

namespace WebApi.Teste.User.Register;

public class RegisterUserServiceValidator : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _factory;
    
    public RegisterUserServiceValidator(WebApplicationFactory<Program> factory)
    {
        _factory = factory.CreateClient();
    }
    
    [Fact]
    public async Task Success()
    {
        //Arrange
        var request = RegisterUserRequestBuilder.Build();
        
        //Act
        var response = await _factory.PostAsJsonAsync("v1/User", request);
        
        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);
        
        responseData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(request.Name);
    }
}