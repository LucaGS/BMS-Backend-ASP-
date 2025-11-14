using DotNet8.WebApi.Data;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// MVC / Swagger / Tools
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// ---------------------------------------------------------
// Datenbank
// ---------------------------------------------------------
var connectionString =
    $"Host={Environment.GetEnvironmentVariable("PGHOST")};" +
    $"Port={Environment.GetEnvironmentVariable("PGPORT")};" +
    $"Database={Environment.GetEnvironmentVariable("PGDATABASE")};" +
    $"Username={Environment.GetEnvironmentVariable("PGUSER")};" +
    $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")};" +
    $"Trust Server Certificate=true";

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("BmsDevelopmentDb"));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));
}

// ---------------------------------------------------------
// Authentifizierung / Autorisierung 
// ---------------------------------------------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!)),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddAuthorization();

// ---------------------------------------------------------
// DI-Services
// ---------------------------------------------------------
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGreenAreaService, GreenAreaService>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<IInspectionService, InspectionService>();

var app = builder.Build();

// ---------------------------------------------------------
// DB-Migrationen automatisch anwenden
// ---------------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// ---------------------------------------------------------
// Pipeline
// ---------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opt => opt.RouteTemplate = "openapi/{documentName}.json");
    app.MapScalarApiReference(opt =>
    {
        opt.Title = "WebApi with Scalar Example";
        opt.Theme = ScalarTheme.BluePlanet;
        opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });
}

// Middleware order is important for auth
app.UseRouting();
app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
    {
        var allowedMethods = context.Response.Headers.Allow;
        var allowedDescription = allowedMethods.Count > 0
            ? string.Join(", ", allowedMethods.ToArray())
            : "(no Allow header was set)";

        app.Logger.LogWarning(
            "Request {Method} {Path} was rejected with 405. Allowed methods: {AllowedMethods}",
            context.Request.Method,
            context.Request.Path,
            allowedDescription);
    }
});
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// Map endpoints
app.MapControllers();
app.MapGet("/", () => "BMS Backend API is running!");

app.Run();

public partial class Program;
