using Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Injections;

public static class DbInjection
{
    public static void AddDb(this IServiceCollection services,string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Singleton);
    }
}
