using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Services;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;
using Diplomski.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsRules",
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.WithMethods("*");
                      });
});

//TODO: Move DI to separate file

//Services
builder.Services.AddScoped<IUserService, UserService>();

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

app.MapControllers();

app.Run();
