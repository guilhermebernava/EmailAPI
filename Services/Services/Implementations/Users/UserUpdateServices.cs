using Domain.Repositories;
using Domain.Utils;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Services.Dtos;

namespace Services.Services;

public class UserUpdateServices : IUserUpdateServices
{
    private readonly IValidator<UserUpdateDto> _validator;
    private readonly IUserRepository _repository;
    private readonly ILogger<UserUpdateServices> _logger;

    public UserUpdateServices(IValidator<UserUpdateDto> validator, IUserRepository repository, ILogger<UserUpdateServices> logger)
    {
        _validator = validator;
        _repository = repository;
        _logger = logger;
    }

    public async Task<bool> ExecuteAsync(UserUpdateDto paramter)
    {

        var validations = _validator.Validate(paramter);
        if (!validations.IsValid)
        {
            _logger.LogError($"[UserLoginServices] - Errors in validation in UpdateUserDto - {paramter.Email}", validations.Errors);
            throw new ValidationException(validations.Errors);
        }

        var entity = await _repository.GetByIdAsync(paramter.Id);
        entity.Email = paramter.Email;
        var (hash, salt) = PasswordUtils.GeneratePassword(paramter.Password);
        entity.Salt = salt;
        entity.HashedPassword = hash;

        return await _repository.UpdateAsync(entity);
    }
}
