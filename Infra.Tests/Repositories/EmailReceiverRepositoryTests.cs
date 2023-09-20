using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Infra.Data;
using Infra.Exceptions;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra.Tests.Repositories;

public class EmailReceiverRepositoryTests
{
    private readonly IEmailReceiverRepository _repository;

    public EmailReceiverRepositoryTests()
    {
        var _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "EmailReceiverRepository").Options;
        _repository = new EmailReceiverRepository(new AppDbContext(_dbContextOptions), CreateLogger<Repository<EmailReceiver>>());
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
    public async Task GetByEmailAsync_WhenCalled_ShouldReturnAnEmailReceiver()
    {
        var emailReceiver = new EmailReceiver("name", "a@a.com", EClientType.Client, false);
        var result = await _repository.CreateAsync(emailReceiver);
        Assert.True(result);

        var existentEmailReceiver = await _repository.GetByEmailAsync(emailReceiver.Email);
        Assert.NotNull(existentEmailReceiver);
    }

    [Fact]
    public async Task GetByEmailAsync_WhenCalled_ShouldReturnError()
    {
        await Assert.ThrowsAsync<RepositoryException>(async () => await _repository.GetByEmailAsync("asdasd@asdasd.com"));
    }

    [Fact]
    public async Task GetByNameAsync_WhenCalled_ShouldReturnAnEmailReceiver()
    {
        var emailReceiver = new EmailReceiver("name", "a@a.com", EClientType.Client, false);
        var result = await _repository.CreateAsync(emailReceiver);
        Assert.True(result);

        var existentEmailReceiver = await _repository.GetByNameAsync(emailReceiver.Name);
        Assert.NotNull(existentEmailReceiver);
    }

    [Fact]
    public async Task GetByNameAsync_WhenCalled_ShouldReturnError()
    {
        await Assert.ThrowsAsync<RepositoryException>(async () => await _repository.GetByNameAsync("asdasdasd"));
    }

    [Fact]
    public async Task GetByClientTypeAsync_WhenCalled_ShouldReturnAnListOfEmailReceiver()
    {
        var emailReceiver = new EmailReceiver("name", "a@a.com", EClientType.Client, false);
        var result = await _repository.CreateAsync(emailReceiver);
        Assert.True(result);

        var existentEmailReceiver = await _repository.GetByClientTypeAsync(EClientType.Client);
        Assert.NotNull(existentEmailReceiver);
    }

    [Fact]
    public async Task GetByRecurringAsync_WhenCalled_ShouldReturnAnListOfEmailReceiver()
    {
        var emailReceiver = new EmailReceiver("name", "a@a.com", EClientType.Client, true);
        var result = await _repository.CreateAsync(emailReceiver);
        Assert.True(result);

        var existentEmailReceiver = await _repository.GetByRecurringAsync();
        Assert.NotNull(existentEmailReceiver);
        Assert.NotEmpty(existentEmailReceiver);
    }
}
