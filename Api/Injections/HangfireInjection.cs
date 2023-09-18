using Hangfire;
using Hangfire.PostgreSql;

namespace API.Injections;

public static class HangfireInjection
{
    public static void AddHangfireConfigured(this IServiceCollection services, string connectionString)
    {
        services.AddHangfire(config => config.UseStorage(new PostgreSqlStorage(connectionString)));
        services.AddHangfireServer();
    }
}