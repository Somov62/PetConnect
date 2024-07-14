using Microsoft.EntityFrameworkCore;
using PetConnect.API.Helpers;
using PetConnect.Application;
using PetConnect.Application.Abstractions;
using PetConnect.Infrastructure;
using PetConnect.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<PetConnectDbContext>();

builder.Services.AddScoped<PetsService>();
builder.Services.AddScoped<IPetsRepository, PetsRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PetConnectDbContext>();
    db.Database.Migrate();
}

app.UseExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
