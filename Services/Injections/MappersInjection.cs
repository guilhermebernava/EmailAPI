using Microsoft.Extensions.DependencyInjection;
using Services.Mappers;
using Services.Mappers.Users;

namespace Infra.Injections;

public static class MappersInjection
{
    public static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMappers));
        services.AddAutoMapper(typeof(EmailHtmlTemplateMappers));
    }
}
