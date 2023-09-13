using AWSApi.Injections;
using AWSApi.Middlewares;
using Infra.Injections;
using Services.Injections;

namespace AWSApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddAwsServices(Configuration);
        services.AddSwaggerGen();
        services.AddConfiguredSwagger();
        services.AddEndpointsApiExplorer();
        services.AddSerilog();
        services.AddLogging();
        services.AddJwt(Configuration);
        services.AddRepositories();
        services.AddDb(Configuration.GetConnectionString("emailDb"));
        services.AddMappers();
        services.AddServices();
        services.AddValidators();



    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<GlobalErrorMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseRouting();
        app.UseAuthorization();
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
        });
    }
}