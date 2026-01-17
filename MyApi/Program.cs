using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApi.Data;
using Microsoft.EntityFrameworkCore;
using MyApi.Repositories.Auth;
using MyApi.Repositories.Products;
using MyApi.Repositories.Admin;
using MyApi.Services.Auth;
using MyApi.Services.Products;
using MyApi.Services.Admin;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// InMemory DB for demo
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseInMemoryDatabase("MyApiDb"));

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAdminRepository, UserAdminRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserAdminService, UserAdminService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
