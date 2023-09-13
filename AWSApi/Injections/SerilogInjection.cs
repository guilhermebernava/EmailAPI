using Serilog;

namespace AWSApi.Injections;

public static class SerilogInjector
{
    public static void AddSerilog(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("../../Logs/logs.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}