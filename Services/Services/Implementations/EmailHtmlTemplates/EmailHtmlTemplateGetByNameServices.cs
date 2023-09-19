using Domain.Entities;
using Domain.Repositories;

namespace Services.Services;

public class EmailHtmlTemplateGetByNameServices : IEmailHtmlTemplateGetByNameServices
{
    private readonly IEmailHtmlTemplateRepository _repository;

    public EmailHtmlTemplateGetByNameServices(IEmailHtmlTemplateRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmailHtmlTemplate> ExecuteAsync(string name)
    {
        return await _repository.GetByNameAsync(name);
    }
}
