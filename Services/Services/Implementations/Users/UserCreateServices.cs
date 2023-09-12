using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using FluentValidation;
using Infra.Repositories;
using Microsoft.Extensions.Logging;
using Services.Dtos.Users;

namespace Services.Services;

public class UserCreateServices : IUserCreateServices
{
    private readonly IValidator<UserDto> _validator;
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<UserRepository> _logger;

    public UserCreateServices(IValidator<UserDto> validator, IUserRepository repository, IMapper mapper, ILogger<UserRepository> logger)
    {
        _validator = validator;
        _repository = repository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(UserDto paramter)
    {
        var validations = _validator.Validate(paramter);
        if (!validations.IsValid)
        {
            _logger.LogError($"Errors in validation in CREATE USER - \nEMAIL {paramter.Email}");
            throw new ValidationException(validations.Errors);
        }

        var entity = _mapper.Map<User>(paramter);
        return await _repository.CreateAsync(entity);
    }
}
