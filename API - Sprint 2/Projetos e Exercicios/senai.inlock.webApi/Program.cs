using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o de controllers
builder.Services.AddControllers();

// Adiciona o gerador do Swagger � cole��o de Servi�os
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Tarde",
        Description = "API para gerenciamento de filmes - Introdu��o a sprint 2 - Backend API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Lucas Bianchezzi Oliveira",
            Url = new Uri("https://github.com/LucasBO7")
        }
    });

    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Habilite o middleware para atender ao documento JSON gerado e � interface do usu�rio do Swagger, tamb�m em Program.cs
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Para atender � interface do usu�rio do Swagger na raiz do aplicativo (https://localhost:<port>/), definir a propriedade RoutePrefix como uma cadeia de caracteres vazia:
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Mapear os controllers
app.MapControllers();

app.Run();