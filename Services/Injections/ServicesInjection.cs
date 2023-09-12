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
    }
}