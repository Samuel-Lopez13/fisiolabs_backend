using Core.Domain.Entities;
using Core.Domain.Services;
using Core.Features.Usuario.Command;
using Core.Infraestructure;
using Core.Infraestructure.Persistance;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithExposedHeaders("Content-Disposition")
                .AllowCredentials();
        });
});
builder.Services.AddControllers();
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

//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();