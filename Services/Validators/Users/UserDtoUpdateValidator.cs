using FluentValidation;
using Services.Dtos;

namespace Services.Validators;

public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
{
    public UserUpdateDtoValidator()
    {
        RuleFor(_ => _.Email).NotNull().NotEmpty().WithMessage("Email can not be null").EmailAddress().WithMessage("Must to be a valid email address");
        RuleFor(_ => _.Id).NotNull().NotEmpty().WithMessage("Id can not be null");
        RuleFor(_ => _.Password).NotNull().NotEmpty().WithMessage("Password can not be null").MinimumLength(6).WithMessage("Password has to be minimum 6 charcteres");
    }
}