using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Agregar Servicio al Contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

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

// Agregar Swagger para la documentación de la API (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el canal de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
