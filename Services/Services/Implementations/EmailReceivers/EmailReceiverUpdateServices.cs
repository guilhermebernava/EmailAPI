using AutoMapper;
using Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Services.Dtos;

namespace Services.Services;

public class EmailReceiverUpdateServices : IEmailReceiverUpdateServices
{
    private readonly IEmailReceiverRepository _repository;
    private readonly IValidator<EmailReceiverUpdateDto> _validator;
    private readonly IMapper _mapper;
    private readonly ILogger<EmailReceiverUpdateServices> _logger;

    public EmailReceiverUpdateServices(IEmailReceiverRepository repository, IValidator<EmailReceiverUpdateDto> validator, IMapper mapper, ILogger<EmailReceiverUpdateServices> logger)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(EmailReceiverUpdateDto paramter)
    {
        var validate = _validator.Validate(paramter);
        if (!validate.IsValid)
        {
            _logger.LogError("Validation error in EmailReceiverDto");
            throw new ValidationException(validate.Errors);
        }

        var entity = await _repository.GetByIdAsync(paramter.Id);
        entity.ClientType = paramter.ClientType;
        entity.Email = paramter.Email;
        entity.Recurring = paramter.Recurring;
        entity.Name = paramter.Name;

        return await _repository.UpdateAsync(entity);
    }
}
