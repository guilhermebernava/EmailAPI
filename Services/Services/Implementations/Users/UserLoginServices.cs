using Domain.Repositories;
using FluentValidation;
using Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Dtos;
using Services.JWT;

namespace Services.Services;

public class UserLoginServices : IUserLoginServices
{
    private readonly IValidator<LoginDto> _validator;
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserRepository> _logger;

    public UserLoginServices(IValidator<LoginDto> validator, IUserRepository repository, IConfiguration configuration, ILogger<UserRepository> logger)
    {
        _validator = validator;
        _repository = repository;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<string> ExecuteAsync(LoginDto paramter)
    {
        var validations = _validator.Validate(paramter);
        if (!validations.IsValid)
        {
            _logger.LogError($"Errors in validation in LOGIN USER - \nEMAIL {paramter.Email}");
            throw new ValidationException(validations.Errors);
        }

        var validUser = await _repository.LoginAsync(paramter.Email, paramter.Password);

        if (validUser == null)
        {
            _logger.LogError($"NOT FOUND ANY USER with this EMAIL - {paramter.Email}");
            throw new UnauthorizedAccessException("Invalid EMAIL or PASSWORD");
        }
        return JwtGenerator.GenerateToken(_configuration, validUser);
    }
}
