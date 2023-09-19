using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Services.Dtos;

namespace Services.Services;

public class EmailHtmlTemplateCreateServices : IEmailHtmlTemplateCreateServices
{
    private readonly IEmailHtmlTemplateRepository _repository;
    private readonly IValidator<EmailHtmlTemplateDto> _validator;
    private readonly IMapper _mapper;
    private readonly ILogger<EmailHtmlTemplateCreateServices> _logger;

    public EmailHtmlTemplateCreateServices(IEmailHtmlTemplateRepository repository, IValidator<EmailHtmlTemplateDto> validator, IMapper mapper, ILogger<EmailHtmlTemplateCreateServices> logger)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(EmailHtmlTemplateDto paramter)
    {
        var validate = _validator.Validate(paramter);
        if (!validate.IsValid)
        {
            _logger.LogError("Validation error in EmailHtmlTemplateDto");
            throw new ValidationException(validate.Errors);
        }

        var entity = _mapper.Map<EmailHtmlTemplate>(paramter);
        return await _repository.CreateAsync(entity);
    }
}
