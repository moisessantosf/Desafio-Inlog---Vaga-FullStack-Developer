using Inlog.Desafio.Backend.Application.Interfaces;
using Inlog.Desafio.Backend.Application.Services;
using Inlog.Desafio.Backend.Domain.Interfaces;
using Inlog.Desafio.Backend.Infra.Database.Context;
using Inlog.Desafio.Backend.Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<DbInlogContext>(options => 
    options
    .UseNpgsql(builder.Configuration["DbContextSettings:ConnectionString:InLogDb"], 
        b => b.MigrationsAssembly("Inlog.Desafio.Backend.Domain"))
);

builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
