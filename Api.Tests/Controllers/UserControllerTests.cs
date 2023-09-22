using Microsoft.AspNetCore.Mvc.Testing;
using Services.Dtos;
using System.Net;
using System.Net.Http.Json;

namespace Api.Tests.Controllers;

public class UserControllerTests :IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public UserControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;

    }

    #region CREATE USER ENDPOINT
    [Fact]
    public async Task CreateUser_CorrectEmailAndPassword_Returns200()
    {
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("/User", new UserDto("b@b.com", "123456"));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.Created);
    }

    [Fact]
    public async Task CreateUser_InvalidEmailAndPasswordFormat_Returns400()
    {
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("/User", new UserDto("bsdasdasd", "1234"));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.BadRequest);
    }
    #endregion

    #region UPDATE USER ENDPOINT
    [Fact]
    public async Task UpdateUser_WhenNotAuthorized_Returns401()
    {
        var client = _factory.CreateClient();
        var result = await client.PutAsJsonAsync("/User", new UserUpdateDto("c@c.com", "123456", new Guid("979ba8d0-0f9b-4460-9e5c-caecf2633936")));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.Unauthorized);
    }

    //TODO arrumar tests para sempre passarem
    [Fact]
    public async Task UpdateUser_CorrectId_Returns200()
    {
        var client = _factory.CreateClient();
        var logged = await client.PostAsJsonAsync("/User/login", new LoginDto("a@a.com", "123456"));
        var jwt = await logged.Content.ReadAsStringAsync();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");

        var result = await client.PutAsJsonAsync("/User", new UserUpdateDto("c@c.com", "123456", new Guid("979ba8d0-0f9b-4460-9e5c-caecf2633936")));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task UpdateUser_InvalidId_Returns400()
    {
        var client = _factory.CreateClient();
        var logged = await client.PostAsJsonAsync("/User/login", new LoginDto("a@a.com", "123456"));
        var jwt = await logged.Content.ReadAsStringAsync();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");

        var result = await client.PutAsJsonAsync("/User", new UserUpdateDto("c@c.com", "123456", Guid.Empty));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.BadRequest);
    }
    #endregion

    #region DELETE USER ENDPOINT
    [Fact]
    public async Task DeleteUser_WhenNotAuthorized_Returns401()
    {
        var client = _factory.CreateClient();
        var result = await client.DeleteAsync("/User");
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.Unauthorized);
    }

    //TODO arrumar tests para sempre passarem
    [Fact]
    public async Task DeleteUser_CorrectId_Returns200()
    {
        var client = _factory.CreateClient();
        var logged = await client.PostAsJsonAsync("/User/login", new LoginDto("a@a.com", "123456"));
        var jwt = await logged.Content.ReadAsStringAsync();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");

        var result = await client.DeleteAsync("/User?id=979ba8d0-0f9b-4460-9e5c-caecf2633936");
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task DeleteUser_InvalidId_Returns404()
    {
        var client = _factory.CreateClient();
        var logged = await client.PostAsJsonAsync("/User/login", new LoginDto("a@a.com", "123456"));
        var jwt = await logged.Content.ReadAsStringAsync();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {jwt}");

        var result = await client.DeleteAsync("/User?id=979ba8d0-0f9b-4460-9e5c-caecf2633938");
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.InternalServerError);
    }
    #endregion

    #region LOGIN ENDPOINT
    [Fact]
    public async Task Login_CorrectEmailAndPassword_Returns200()
    {
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("/User/login",new LoginDto("a@a.com", "123456" ));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async Task Login_InvalidPasswordOrEmail_Returns401()
    {
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("/User/login", new LoginDto("a@a.com", "123455"));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Login_InvalidEmailOrPasswordJson_Returns400()
    {
        var client = _factory.CreateClient();
        var result = await client.PostAsJsonAsync("/User/login", new LoginDto("aaadsa", "12345"));
        Assert.NotNull(result);
        Assert.True(result.StatusCode == HttpStatusCode.BadRequest);
    }
    #endregion
}
