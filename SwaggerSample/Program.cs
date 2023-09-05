using Microsoft.OpenApi.Models;
using Riolabs.PageDescriptor.Swashbuckle;
using SwaggerSample.Core;
using SwaggerSample.Data;
using SwaggerSample.Services;
using Microsoft.EntityFrameworkCore;
using SwaggerSample.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseInMemoryDatabase("database");
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddFrontendDescriptor();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
