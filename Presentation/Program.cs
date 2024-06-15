using Core.Domain.Entities;
using Core.Domain.Services;
using Core.Features.Usuario.Command;
using Core.Infraestructure;
using Core.Infraestructure.Persistance;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Usuario).Assembly));
builder.Services.AddPresentationServices(builder.Configuration);
builder.Services.AddSecurity(builder.Configuration);
builder.Services.AddScoped<IAuthService, AuthService>();

// Cargar variables de entorno desde el archivo .env
DotEnv.Load();

//Database
const string connectionName = "ConexionMaestra";
var connectionString = builder.Configuration.GetConnectionString(connectionName);
builder.Services.AddDbContext<FisiolabsSofwaredbContext>(options => options.UseMySQL(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.MapControllers();

app.Run();