using API.Injections;
using Infra.Injections;
using Services.Injections;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSerilog();
builder.Services.AddLogging();

builder.Services.AddJwt(builder);
builder.Services.AddConfiguredSwagger();
builder.Services.AddRepositories();
builder.Services.AddDb(builder.Configuration.GetConnectionString("emailDb"));
builder.Services.AddMappers();
builder.Services.AddServices();
builder.Services.AddValidators();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
