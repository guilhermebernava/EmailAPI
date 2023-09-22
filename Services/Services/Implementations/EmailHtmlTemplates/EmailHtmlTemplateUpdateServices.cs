using AutoMapper;
using Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Services.Dtos;

namespace Services.Services;

public class EmailHtmlTemplateUpdateServices : IEmailHtmlTemplateUpdateServices
{
    private readonly IEmailHtmlTemplateRepository _repository;
    private readonly IValidator<EmailHtmlTemplateUpdateDto> _validator;
    private readonly IMapper _mapper;
    private readonly ILogger<EmailHtmlTemplateUpdateServices> _logger;

    public EmailHtmlTemplateUpdateServices(IEmailHtmlTemplateRepository repository, IValidator<EmailHtmlTemplateUpdateDto> validator, IMapper mapper, ILogger<EmailHtmlTemplateUpdateServices> logger)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(EmailHtmlTemplateUpdateDto paramter)
    {
        var validate = _validator.Validate(paramter);
        if (!validate.IsValid)
        {
            _logger.LogError("[EmailHtmlTemplateCreateServices] - Validation error in EmailHtmlTemplateDto", validate.Errors);
            throw new ValidationException(validate.Errors);
        }

        var entity = await _repository.GetByIdAsync(paramter.Id);
        entity.HtmlContent = paramter.HtmlContent;
        entity.Subject = paramter.Subject;
        entity.EmailType = paramter.EmailType;
        entity.Name = paramter.Name;

        return await _repository.UpdateAsync(entity);
    }
}
