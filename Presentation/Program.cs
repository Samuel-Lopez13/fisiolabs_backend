using Core.Domain.Entities;
using Core.Domain.Services;
using Core.Features.Usuario.Command;
using Core.Infraestructure;
using Core.Infraestructure.Persistance;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("https://fisiolabs.netlify.app", "http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
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
builder.Services.AddDbContext<FisioContext>(options => options.UseMySQL(connectionString));

var app = builder.Build();


app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

    // Incluir hoja de estilos personalizada
    c.InjectStylesheet("/swagger-ui/custom.css");
});

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

// Servir tu archivo CSS desde wwwroot
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "swagger-ui")),
    RequestPath = "/swagger-ui"
});

app.UseAuthentication();

app.MapControllers();

app.Run();