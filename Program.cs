using Microsoft.EntityFrameworkCore;
using CategoriaApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CategoriaContext>(options =>
    options.UseInMemoryDatabase("CategoriaDb"));

/*
builder.Services.AddDbContext<CategoriaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("default")));*/
builder.Services.AddControllers();

builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.SetMinimumLevel(LogLevel.Debug); // Para capturar mais detalhes
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();
app.Run();



