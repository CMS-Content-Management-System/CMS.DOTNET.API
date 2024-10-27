using ApiBlog.Dominio.Categorias;
using ApiBlog.Repositorio.Categorias;
using ApiBlog.Repositorio;
using Microsoft.EntityFrameworkCore;
using ApiBlog.Repositorio.Usuarios;
using ApiBlog.Dominio.Usuarios;
using ApiBlog.Repositorio.Noticias;
using ApiBlog.Dominio.Noticias;
using ApiBlog.Dominio.Categorias.Validadores;
using ApiBlog.Dominio.Usuarios.Validadores;
using ApiBlog.Dominio.Noticias.Validadores;
using ApiBlog.Dominio.Geral;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using ApiBlog.Repositorio.Parametrizacoes.Geral;
using ApiBlog.Dominio.Parametrizacoes.Geral;
using ApiBlog.Dominio.Propagandas;
using ApiBlog.Repositorio.Propagandas;

namespace ApiBlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var corsPolicy = "AllowAllOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretsConfiguration:JwtKey"]))
                };
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { 
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                //var connectionString = builder.Configuration.GetConnectionString("ConexaoLocal");

                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            builder.Services.AddScoped<IRepCategoria, RepCategoria>();
            builder.Services.AddScoped<IRepUsuario, RepUsuario>();
            builder.Services.AddScoped<IRepNoticia, RepNoticia>();
            builder.Services.AddScoped<IRepPropaganda, RepPropaganda>();
            builder.Services.AddScoped<IRepConfigGeral, RepConfigGeral>();
            builder.Services.AddScoped<IValidadorCategoria, ValidadorCategoria>();
            builder.Services.AddScoped<IValidadorUsuario, ValidadorUsuario>();
            builder.Services.AddScoped<IValidadorNoticia, ValidadorNoticia>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            var app = builder.Build();

            app.UseCors(corsPolicy);

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
