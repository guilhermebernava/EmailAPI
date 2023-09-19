using Domain.Entities;
using Domain.Repositories;

namespace Services.Services;

public class EmailHtmlTemplateGetAllServices : IEmailHtmlTemplateGetAllServices
{
    private readonly IEmailHtmlTemplateRepository _repository;

    public EmailHtmlTemplateGetAllServices(IEmailHtmlTemplateRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmailHtmlTemplate>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
