using DotNet8.WebApi.Data;
using DotNet8.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Scalar.AspNetCore;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var connectionString = $"Host={Environment.GetEnvironmentVariable("PGHOST")};" +
                      $"Port={Environment.GetEnvironmentVariable("PGPORT")};" +
                      $"Database={Environment.GetEnvironmentVariable("PGDATABASE")};" +
                      $"Username={Environment.GetEnvironmentVariable("PGUSER")};" +
                      $"Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")};" +
                      $"Trust Server Certificate=true";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

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

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IGreenAreaService, GreenAreaService>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<IInspectionService, InspectionService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

WebApplication app = builder.Build();

app.UseSwagger(opt => opt.RouteTemplate = "openapi/{documentName}.json");
app.MapScalarApiReference(
    opt => {
        opt.Title = "WebApi with Scalar Example";
        opt.Theme = ScalarTheme.BluePlanet;
        opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    }
);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowFrontend");
app.MapControllers();
app.Run();
