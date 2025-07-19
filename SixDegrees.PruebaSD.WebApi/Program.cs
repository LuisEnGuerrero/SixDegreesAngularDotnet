using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SixDegrees.PruebaSD.Negocio;
using SixDegrees.PruebaSD.AccesoDatos;
using SixDegrees.PruebaSD.Entidades;
using System;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Cargar .env
DotNetEnv.Env.Load();

// Obtener cadena de conexión desde entorno
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")
    ?? throw new InvalidOperationException("La cadena de conexión no está configurada.");

// Registrar servicios
// var connectionString = builder.Configuration.GetConnectionString("CONNECTION_STRING");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'CONNECTION_STRING' is not configured.");
}


// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Agregar controladores y OpenAPI (Swagger)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

// Inyección de dependencias

builder.Services.AddScoped<IUsuarioRepository>(sp => new UsuarioRepository(connectionString));
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Mapear controladores
app.MapControllers();

app.Run();