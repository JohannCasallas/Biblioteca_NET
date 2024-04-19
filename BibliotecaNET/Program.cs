using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using BibliotecaNET.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar Servicio al Contenedor.
builder.Services.AddControllers();

// Configurar DbContext para la base de datos
builder.Services.AddDbContext<DB_BIBLIOTECAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar Servicios de autenticacion JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BibliotecaNet")),
            ValidateAudience = true,
            ValidAudience = "BibliotecaNet",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Cors policies permission
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Agregar Swagger para la documentación de la API (opcional)
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el canal de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NewPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
