using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Mitre_attack.Models;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MitreMappingContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Server=comp6002.mysql.database.azure.com;Database=mitre_mapping;User ID=comp6002;Password=MITREMapping6002;"),
    new MySqlServerVersion(new Version(8, 0, 32))));


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
