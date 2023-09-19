using FluentValidation;
using Services.Dtos;

namespace Services.Validators;

public class EmailHtmlTemplateDtoValidator : AbstractValidator<EmailHtmlTemplateDto>
{
    public EmailHtmlTemplateDtoValidator()
    {
        RuleFor(_ => _.EmailType).NotNull().WithMessage("EmailType can not be null");
        RuleFor(_ => _.Name).NotNull().NotEmpty().WithMessage("Name can not be null");
        RuleFor(_ => _.Subject).NotNull().NotEmpty().WithMessage("Subject can not be null");
        RuleFor(_ => _.HtmlContent).NotNull().NotEmpty().WithMessage("HtmlContent can not be null");
    }
}