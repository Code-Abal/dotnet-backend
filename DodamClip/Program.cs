using DodamClip.Data;
using DodamClip.Repositories.Admin;
using DodamClip.Repositories.Auth;
using DodamClip.Repositories.Products;
using DodamClip.Services.Admin;
using DodamClip.Services.Auth;
using DodamClip.Services.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In-memory EF Core
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("DodamClipDb"));

// mysql connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAdminRepository, UserAdminRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<UserAdminService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Seed demo data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (!db.Users.Any())
    {
        db.Users.Add(new DodamClip.Models.Entities.User { Username = "admin", Email = "admin@example.com", Password = "password", Role = "Admin" });
        db.Users.Add(new DodamClip.Models.Entities.User { Username = "user1", Email = "user1@example.com", Password = "password", Role = "User" });
    }
    if (!db.Products.Any())
    {
        db.Products.Add(new DodamClip.Models.Entities.Product { Name = "Sample", Description = "Sample product", Price = 9.99M });
    }
    db.SaveChanges();
}

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
