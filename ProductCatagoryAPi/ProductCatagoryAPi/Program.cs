using Microsoft.EntityFrameworkCore;
using ProductCatagoryAPi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("con") ?? throw new InvalidOperationException("connnection string not matched"));
});
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
{
    policy.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
