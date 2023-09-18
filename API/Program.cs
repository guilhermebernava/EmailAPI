using API.Injections;
using API.Middlewares;
using Hangfire;
using Infra.Injections;
using Services.Injections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguredSwagger();
builder.Services.AddSerilog();
builder.Services.AddLogging();

builder.Services.AddJwt(builder);
builder.Services.AddHangfireConfigured(builder.Configuration.GetConnectionString("hangfireDb"));
builder.Services.AddRepositories();
builder.Services.AddDb(builder.Configuration.GetConnectionString("emailDb"));
builder.Services.AddMappers();
builder.Services.AddServices();
builder.Services.AddValidators();

var app = builder.Build();

app.UseHangfireDashboard();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.UseHttpsRedirection();
app.MapControllers();
app.UseMiddleware<GlobalErrorMiddleware>();
app.Run();
