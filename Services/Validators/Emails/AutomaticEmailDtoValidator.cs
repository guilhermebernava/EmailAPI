using FluentValidation;
using Services.Dtos;

namespace Services.Validators;

internal class AutomaticEmailDtoValidator : AbstractValidator<AutomaticEmailDto>
{
    public AutomaticEmailDtoValidator()
    {
        RuleFor(_ => _.EmailDto).NotNull().NotEmpty().WithMessage("EmailDto can not be null");
        RuleFor(_ => _.Name).NotNull().NotEmpty().WithMessage("Name can not be null");
        RuleFor(_ => _.Cron).NotNull().NotEmpty().WithMessage("Cron can not be null");
    }
}
