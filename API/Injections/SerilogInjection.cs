using Serilog;

namespace API.Injections;

public static class SerilogInjector
{
    public static void AddSerilog(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.File("error.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
}