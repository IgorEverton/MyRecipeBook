using CommonTestUtilities.Request;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.IdentityModel.Tokens;
using MyRecipeBook.Exceptions;
using Shouldly;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Tests.User.Register;

public class RegisterUserTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public RegisterUserTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuild.build();

        var response = await _client.PostAsJsonAsync("/user/", request);

        response.StatusCode.ShouldBe(HttpStatusCode.Created);

        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        responseData.RootElement.GetProperty("name").GetString().ShouldBe(request.Name);
        responseData.RootElement.GetProperty("token").GetProperty("accessToken").GetString().ShouldNotBeNullOrEmpty();
    }

    [Fact]
    public async Task Validate_ShouldBeAnErrorResponse_WhenNameIsEmpty()
    {
        var request = RequestRegisterUserJsonBuild.build();
        request.Name = string.Empty;

        var response = await _client.PostAsJsonAsync("/user/", request);

        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        var errors = responseData.RootElement.GetProperty("errors").EnumerateArray();

        errors.ShouldSatisfyAllConditions(errorsList =>
        {
            errorsList.Count().ShouldBe(1);
            errorsList.ShouldContain(error => error.GetString().IsNullOrEmpty() && error.GetString()!.Equals(ResourceMessagensException.NAME_EMPTY));
        }
            
        );
    }
}
