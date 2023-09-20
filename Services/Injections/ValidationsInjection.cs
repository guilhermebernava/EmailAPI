using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Services.Dtos;
using Services.Validators;

namespace Services.Injections;

public static class ValidatorsInjection
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
        services.AddScoped<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();
        services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();

        services.AddScoped<IValidator<EmailDto>, EmailDtoValidator>();
        services.AddScoped<IValidator<AutomaticEmailDto>, AutomaticEmailDtoValidator>();

        services.AddScoped<IValidator<EmailHtmlTemplateDto>, EmailHtmlTemplateDtoValidator>();
        services.AddScoped<IValidator<EmailHtmlTemplateUpdateDto>, EmailHtmlTemplateUpdateDtoValidator>();

        services.AddScoped<IValidator<EmailReceiverDto>, EmailReceiverDtoValidator>();
        services.AddScoped<IValidator<EmailReceiverUpdateDto>, EmailReceiverUpdateDtoValidator>();
    }
}