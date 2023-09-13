using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Utils;
using FluentValidation;
using Infra.Repositories;
using Microsoft.Extensions.Logging;
using Services.Dtos.Users;

namespace Services.Services;

public class UserUpdateServices : IUserUpdateServices
{
    private readonly IValidator<UserDto> _validator;
    private readonly IUserRepository _repository;
    private readonly ILogger<UserRepository> _logger;

    public UserUpdateServices(IValidator<UserDto> validator, IUserRepository repository,  ILogger<UserRepository> logger)
    {
        _validator = validator;
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(UserDto paramter)
    {

        if(paramter.Id == null)
        {
            _logger.LogError($"ID NULL - \nEMAIL {paramter.Email}");
            throw new ValidationException("Id is null");
        }

        var validations = _validator.Validate(paramter);
        if (!validations.IsValid)
        {
            _logger.LogError($"Errors in validation in UPDATE USER or ID NULL - \nEMAIL {paramter.Email}");
            throw new ValidationException(validations.Errors);
        }
        Guid id = paramter.Id.Value;
        var entity = await _repository.GetById(id);

        entity.Email = paramter.Email;
        var (hash, salt) = PasswordUtils.GeneratePassword(paramter.Password);
        entity.Salt = salt;
        entity.HashedPassword = hash;

        return await _repository.UpdateAsync(entity);
    }
}
