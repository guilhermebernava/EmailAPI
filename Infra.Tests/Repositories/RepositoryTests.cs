using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Infra.Exceptions;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra.Tests.Repositories;

public class RepositoryTests
{
    private readonly IRepository<User> _repository;

    public RepositoryTests()
    {
        var _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "Repository").Options;
        _repository = new Repository<User>(new AppDbContext(_dbContextOptions), CreateLogger<Repository<User>>());
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
    public async Task CreateAsync_WhenCalled_ShouldAddEntityToDatabase()
    {
        var user = new User("a@a.com", "123456");
        var result = await _repository.CreateAsync(user);
        Assert.True(result);
    }

    [Fact]
    public async Task CreateAsync_WhenCalled_ShouldHaveError()
    {
        var user = new User();
        await Assert.ThrowsAsync<RepositoryException>(async () => await _repository.CreateAsync(user));
    }

    [Fact]
    public async Task DeleteAsync_WhenEntityExists_ShouldMarkAsDeleted()
    {
        var user = new User("a@a.com", "123456");
        await _repository.CreateAsync(user);
        var result = await _repository.DeleteAsync(user.Id);
        Assert.True(result);
        Assert.NotNull(user.DeletedAt);
    }

    [Fact]
    public async Task DeleteAsync_WhenEntityDoesNotExist_ShouldThrowException()
    {
        var invalidId = Guid.NewGuid();
        await Assert.ThrowsAsync<RepositoryException>(() => _repository.DeleteAsync(invalidId));
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        await _repository.CreateAsync(new User("a@a.com", "123456"));
        var result = await _repository.GetAllAsync();
        Assert.True(result.Count() > 0);
    }

    [Fact]
    public async Task GetByIdAsync_WhenEntityExists_ShouldReturnEntity()
    {
        var user = new User("c@c.com", "123456");
        var created = await _repository.CreateAsync(user);
        Assert.True(created);

        var result = await _repository.GetByIdAsync(user.Id);
        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
    }

    [Fact]
    public async Task GetByIdAsync_WhenEntityDoesNotExist_ShouldThrowException()
    {
        var invalidId = Guid.NewGuid();
        await Assert.ThrowsAsync<RepositoryException>(() => _repository.GetByIdAsync(invalidId));
    }

    [Fact]
    public async Task UpdateAsync_WhenEntityExists_ShouldUpdateEntity()
    {
        var user = new User("c@c.com", "123456");
        await _repository.CreateAsync(user);

        user.Email = "a@b.com";
        var result = await _repository.UpdateAsync(user);

        Assert.True(result);
    }
}
