using no_sql.Data;
using no_sql.Data.Configuration;
using no_sql.Data.Repository;
using no_sql.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoConfiguration>(builder.Configuration.GetSection("MongoConfiguration"));

builder.Services.AddSingleton<IMongoContext, MongoContext>();
builder.Services.AddSingleton<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

app.MapPessoaEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
