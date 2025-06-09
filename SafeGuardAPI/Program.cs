using Microsoft.EntityFrameworkCore;
using SafeGuardAPI.Connection;
using SafeGuardAPI.Repository;
using SafeGuardAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext com a string de conexão para o Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Registra os repositórios
builder.Services.AddScoped<RiscoRepository>();
builder.Services.AddScoped<SensorRepository>();
builder.Services.AddScoped<LeituraRepository>();
builder.Services.AddScoped<EstacaoRepository>();
builder.Services.AddScoped<AlertaRepository>();

// Registra os serviços
builder.Services.AddScoped<RiscoService>();
builder.Services.AddScoped<SensorService>();
builder.Services.AddScoped<LeituraService>();
builder.Services.AddScoped<EstacaoService>();
builder.Services.AddScoped<AlertaService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Isso faz com que o Swagger abra diretamente na raiz, sem precisar de /swagger
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SafeGuardAPI v1");
    });
}

app.UseAuthorization();
app.MapControllers();

app.Run();
