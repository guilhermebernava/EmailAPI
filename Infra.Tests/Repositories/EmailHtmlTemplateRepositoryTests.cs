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

public class EmailHtmlTemplateRepositoryTests
{
    private readonly IEmailHtmlTemplateRepository _repository;

    public EmailHtmlTemplateRepositoryTests()
    {
        var _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "EmailHtmlTemplateRepository").Options;
        _repository = new EmailHtmlTemplateRepository(new AppDbContext(_dbContextOptions), CreateLogger<Repository<EmailHtmlTemplate>>());
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
    public async Task GetByEmailTypeAsync_WhenCalled_ShouldReturnAnListOfEmailHtmlTemplate()
    {
        var emailHtmlTemplate = new EmailHtmlTemplate("name", "<h1>Hello</h1>","Subject", EEmailType.Welcome);
        var result = await _repository.CreateAsync(emailHtmlTemplate);
        Assert.True(result);

        var existentEmailHtmlTemplate = await _repository.GetByEmailTypeAsync(EEmailType.Welcome);
        Assert.NotNull(existentEmailHtmlTemplate);
    }

    [Fact]
    public async Task GetByNameAsync_WhenCalled_ShouldReturnAnEmailHtmlTemplate()
    {
        var emailHtmlTemplate = new EmailHtmlTemplate("name", "<h1>Hello</h1>", "Subject", EEmailType.Welcome);
        var result = await _repository.CreateAsync(emailHtmlTemplate);
        Assert.True(result);

        var existentEmailHtmlTemplate = await _repository.GetByNameAsync(emailHtmlTemplate.Name);
        Assert.NotNull(existentEmailHtmlTemplate);
    }

    [Fact]
    public async Task GetByNameAsync_WhenCalled_ShouldReturnError()
    {
        await Assert.ThrowsAsync<RepositoryException>(async () => await _repository.GetByNameAsync("asdasdasd"));
    }
    
}
