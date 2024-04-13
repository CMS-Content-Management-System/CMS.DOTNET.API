using Blog.Dominio.Categorias;
using Blog.Dominio.Categorias.Validadores;
using Blog.Dominio.Noticias;
using Blog.Dominio.Noticias.Validadores;
using Blog.Dominio.Usuarios;
using Blog.Dominio.Usuarios.Validadores;
using Blog.Repositorio;
using Blog.Repositorio.Categorias;
using Blog.Repositorio.Noticias;
using Blog.Repositorio.Usuarios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //var connetionString = builder.Configuration.GetConnectionString("ConnectionNuvem");

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IRepCategoria, RepCategoria>();
builder.Services.AddScoped<IRepUsuario, RepUsuario>();
builder.Services.AddScoped<IRepNoticia, RepNoticia>();
builder.Services.AddScoped<IValidadorCategoria, ValidadorCategoria>();
builder.Services.AddScoped<IValidadorUsuario, ValidadorUsuario>();
builder.Services.AddScoped<IValidadorNoticia, ValidadorNoticia>();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
