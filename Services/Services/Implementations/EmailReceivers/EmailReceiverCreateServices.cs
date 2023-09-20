using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Services.Dtos;

namespace Services.Services;

public class EmailReceiverCreateServices : IEmailReceiverCreateServices
{
    private readonly IEmailReceiverRepository _repository;
    private readonly IValidator<EmailReceiverDto> _validator;
    private readonly IMapper _mapper;
    private readonly ILogger<EmailReceiverCreateServices> _logger;

    public EmailReceiverCreateServices(IEmailReceiverRepository repository, IValidator<EmailReceiverDto> validator, IMapper mapper, ILogger<EmailReceiverCreateServices> logger)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(EmailReceiverDto paramter)
    {
        var validate = _validator.Validate(paramter);
        if (!validate.IsValid)
        {
            _logger.LogError("Validation error in EmailReceiverDto");
            throw new ValidationException(validate.Errors);
        }

        var entity = _mapper.Map<EmailReceiver>(paramter);
        return await _repository.CreateAsync(entity);
    }
}
