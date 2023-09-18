using FluentValidation;
using Services.Dtos;

namespace Services.Validators;

public class EmailDtoValidator : AbstractValidator<EmailDto>
{
    public EmailDtoValidator()
    {
        RuleFor(_ => _.EmailReceiverFromDb).NotNull().NotEmpty().WithMessage("EmailReceiverFromDb can not be null");
        RuleFor(_ => _.FromTemplate).NotNull().NotEmpty().WithMessage("FromTemplate can not be null");
    }
}
