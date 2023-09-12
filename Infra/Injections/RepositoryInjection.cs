using Domain.Repositories;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Injections;

public static class RepositoryInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository,UserRepository>();
    }
}
