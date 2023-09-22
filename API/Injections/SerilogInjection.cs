using Serilog;

namespace API.Injections;

public static class SerilogInjector
{
    public static void AddSerilog(this IServiceCollection services)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .Enrich.WithProperty("SourceContext", null)
            .WriteTo.Console()
            .WriteTo.File("Logs/errors.txt", flushToDiskInterval: TimeSpan.FromSeconds(1))
            .CreateBootstrapLogger();
    }
}