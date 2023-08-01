using System.Reflection;
using System.Text;
using DashboardApi.Repositories;
using DashboardApi.Repositories.Interfaces;
using DashboardApi.Services;
using DashboardApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MongoDB");
var databaseName = "dashboard";
builder.Services.AddSingleton<IJwtService, JwtService>();
builder.Services.AddSingleton<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton(new UserContext(connectionString, databaseName));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        authenticationScheme: JwtBearerDefaults.AuthenticationScheme,
        configureOptions: options =>
        {
            options.IncludeErrorDetails = true;
            options.TokenValidationParameters =
                new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF32.GetBytes(builder.Configuration["Jwt:PrivateKey"])
                    ),
                    ValidAudience = "identity",
                    ValidIssuer = "identity",
                    RequireExpirationTime = true,
                    RequireAudience = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                };
        });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DashobardApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();