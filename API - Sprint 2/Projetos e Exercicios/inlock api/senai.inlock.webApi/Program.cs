using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de controllers
builder.Services.AddControllers();

#region JwtBearer Builder Configs
// Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options => // Define os parâmetros de validação do token
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        // Valida quem está solicitando
        ValidateIssuer = true,

        // Valida quem está recebendo
        ValidateAudience = true,

        // Define se o tempo de exibição do token será validado
        ValidateLifetime = true,

        // Forma de criptografia e ainda validação da chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuario-chave-autenticacao-webapi-inlock-app")),

        // Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        // De onde está vindo (issuer)
        ValidIssuer = "webapi.inlock.app",

        // Para onde está indo (audience)
        ValidAudience = "webapi.inlock.app",
    };
});
#endregion


#region Swagger Builder Configs
// Adiciona o gerador do Swagger à coleção de Serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Inlock Games",
        Description = "API para gerenciamento de Jogos - Introdução a sprint 2 - Backend API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Lucas Bianchezzi Oliveira",
            Url = new Uri("https://github.com/LucasBO7")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Usando a autenticação do Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
            new string[]{}
        }
    });
});
#endregion

var app = builder.Build();

#region Swagger App Configs
// Habilite o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger, também em Program.cs
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Para atender à interface do usuário do Swagger na raiz do aplicativo (https://localhost:<port>/), definir a propriedade RoutePrefix como uma cadeia de caracteres vazia:
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
#endregion


#region JwtBearer App Configs
// Usar autenticação
app.UseAuthentication();
// Usar autorização
app.UseAuthorization();
#endregion

// Mapear os controllers
app.MapControllers();

app.Run();