using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using api_rest.Persistence;
using api_rest.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using api_rest.Domain.Services;


var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddSingleton<UserActionLogServices>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "api_rest", Version = "v1" });
});

// Configurar o banco de dados (ajuste conforme necessário)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("APIREST"));

var app = builder.Build();

// Middleware de pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
