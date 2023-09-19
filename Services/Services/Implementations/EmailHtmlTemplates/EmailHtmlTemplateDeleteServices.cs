using Domain.Repositories;

namespace Services.Services;

public class EmailHtmlTemplateDeleteServices : IEmailHtmlTemplateDeleteServices
{
    private readonly IEmailHtmlTemplateRepository _repository;

    public EmailHtmlTemplateDeleteServices(IEmailHtmlTemplateRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(Guid paramter)
    {
        return await _repository.DeleteAsync(paramter);
    }
}
