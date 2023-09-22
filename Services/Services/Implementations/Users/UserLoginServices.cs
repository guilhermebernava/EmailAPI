using Domain.Repositories;
using FluentValidation;
using Hangfire.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Services.Dtos;
using Services.JWT;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Services.Services;

public class UserLoginServices : IUserLoginServices
{
    private readonly IValidator<LoginDto> _validator;
    private readonly IUserRepository _repository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserLoginServices> _logger;

    public UserLoginServices(IValidator<LoginDto> validator, IUserRepository repository, IConfiguration configuration, ILogger<UserLoginServices> logger)
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
            _logger.LogError($"[UserLoginServices] - Errors in validation of LoginDto", validations.Errors);
            throw new ValidationException(validations.Errors);
        }

        var validUser = await _repository.LoginAsync(paramter.Email, paramter.Password);

        if (validUser == null)
        {
            _logger.LogError($"[UserLoginServices] - Not found any user with this email - {paramter.Email}");
            throw new UnauthorizedAccessException("Invalid EMAIL or PASSWORD");
        }
        return JwtGenerator.GenerateToken(_configuration, validUser);
    }
}
