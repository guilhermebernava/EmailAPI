using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Infra.Exceptions;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra.Tests.Repositories;

public class UserRepositoryTests
{
    private readonly IUserRepository _repository;

    public UserRepositoryTests()
    {
        var _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "UserRepository").Options;
        _repository = new UserRepository(new AppDbContext(_dbContextOptions), CreateLogger<Repository<User>>());
    }
    private ILogger<T> CreateLogger<T>()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

        var factory = serviceProvider.GetService<ILoggerFactory>();
        return factory!.CreateLogger<T>();
    }

    [Fact]
    public async Task GetByEmailAsync_WhenCalled_ShouldReturnAnUser()
    {
        var user = new User("a@a.com", "123456");
        var result = await _repository.CreateAsync(user);
        Assert.True(result);

        var existentUser = await _repository.GetByEmailAsync(user.Email);
        Assert.NotNull(existentUser);
    }

    [Fact]
    public async Task GetByEmailAsync_WhenCalled_ShouldReturnError()
    {
        await Assert.ThrowsAsync<RepositoryException>(async () => await _repository.GetByEmailAsync("asdasd@asdasd.com"));
    }

    [Fact]
    public async Task LoginAsync_WhenCalled_ShouldReturnAnUser()
    {
        var user = new User("a@a.com", "123456");
        var result = await _repository.CreateAsync(user);
        Assert.True(result);

        var existentUser = await _repository.LoginAsync(user.Email, "123456");
        Assert.NotNull(existentUser);
    }

    [Fact]
    public async Task LoginAsync_WhenCalled_ShouldReturnError()
    {
        await Assert.ThrowsAsync<RepositoryException>(async () => await _repository.LoginAsync("asdasd@asdasd.com", "123456"));
    }
}
