using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios para las API de Swagger/OpenAPI.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // Habilita el middleware para servir el documento JSON de Swagger generado.
    app.UseSwagger();
    // Habilita el middleware para servir la interfaz de usuario de Swagger.
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
