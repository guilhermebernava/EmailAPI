using FluentValidation;
using Services.Dtos;

namespace Services.Validators;

public class EmailReceiverDtoValidator : AbstractValidator<EmailReceiverDto>
{
    public EmailReceiverDtoValidator()
    {
        RuleFor(_ => _.Email).NotNull().WithMessage("Email can not be null");
        RuleFor(_ => _.Name).NotNull().NotEmpty().WithMessage("Name can not be null");
        RuleFor(_ => _.ClientType).NotNull().WithMessage("ClientType can not be null");
        RuleFor(_ => _.Recurring).NotNull().WithMessage("Recurring can not be null");
    }
}