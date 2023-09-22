using Infra.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Tests;

public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(AppDbContext));

            if (dbContextDescriptor == null) throw new Exception("dbContextDescriptor was NULL");

            services.Remove(dbContextDescriptor);
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });
        });

        builder.UseEnvironment("Development");
    }
}