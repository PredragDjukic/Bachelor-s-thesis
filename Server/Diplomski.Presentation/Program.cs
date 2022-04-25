using System.Security.Claims;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Services;
using Diplomski.BLL.Services.External;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;
using Diplomski.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Diplomski.BLL.Utils.AppSettingsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConcurrencyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FitConDev"));
});

builder.Services.Configure<JwtModel>(builder.Configuration)
    .AddSingleton(sp => sp.GetRequiredService<IOptions<JwtModel>>().Value);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsRules",
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.WithMethods("*");
                      });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Issuer"],
        ValidAudience = builder.Configuration["Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(builder.Configuration["Key"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireClaim("Id")
        .RequireClaim("IsEmailVerified", "True")
        .Build();

    options.AddPolicy("UnverifiedEmail", policy =>
    {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireClaim("Id");
        policy.RequireClaim("IsEmailVerified", "False");
        policy.Build();
    });
});

//TODO: Move DI to separate file

//Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//ExternalServices
builder.Services.AddScoped<ISendGridService, SendGridService>();

//DbContext
builder.Services.AddScoped<ConcurrencyDbContext>();

//Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
