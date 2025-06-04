using aspnetcore_basics.Interface;
using aspnetcore_basics.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// 🔹 Configuração do OpenAPI (Documentação)
builder.Services.AddOpenApi();

// 🔹 Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ASP.NET BASICS",
        Version = "v1",
        Description = "Exemplo de documentação com OpenAPI"
    });
});

// 🔹 Injeção de dependência
builder.Services.AddScoped<ISaudacaoService, SaudacaoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// 🔹 Middleware customizado
app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 1 - Antes");
    await next.Invoke();
    Console.WriteLine("Middleware 1 - Depois");
});

// 🔹 Swagger disponível em qualquer ambiente (ou apenas dev se preferir)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 🔹 Minimal API
app.MapGet("/ping", () => Results.Ok("pong"));

app.Run();