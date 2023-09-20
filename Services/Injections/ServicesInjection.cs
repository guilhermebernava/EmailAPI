using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services.Injections;

public static class ServicesInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserCreateServices, UserCreateServices>();
        services.AddScoped<IUserDeleteServices, UserDeleteServices>();
        services.AddScoped<IUserUpdateServices, UserUpdateServices>();
        services.AddScoped<IUserLoginServices, UserLoginServices>();

        services.AddScoped<IEmailHtmlTemplateCreateServices, EmailHtmlTemplateCreateServices>();
        services.AddScoped<IEmailHtmlTemplateDeleteServices, EmailHtmlTemplateDeleteServices>();
        services.AddScoped<IEmailHtmlTemplateUpdateServices, EmailHtmlTemplateUpdateServices>();
        services.AddScoped<IEmailHtmlTemplateGetAllServices, EmailHtmlTemplateGetAllServices>();
        services.AddScoped<IEmailHtmlTemplateGetByNameServices, EmailHtmlTemplateGetByNameServices>();

        services.AddScoped<IEmailReceiverCreateServices, EmailReceiverCreateServices>();
        services.AddScoped<IEmailReceiverDeleteServices, EmailReceiverDeleteServices>();
        services.AddScoped<IEmailReceiverUpdateServices, EmailReceiverUpdateServices>();
        services.AddScoped<IEmailReceiverGetAllServices, EmailReceiverGetAllServices>();
        services.AddScoped<IEmailReceiverGetByNameServices, EmailReceiverGetByNameServices>();

        services.AddScoped<ISendEmailServices, SendEmailServices>();
        services.AddScoped<IGetJobsServices, GetJobsServices>();
    }
}