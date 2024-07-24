using PetConnect.API.AutoFluentValidation;
using PetConnect.API.Middlewares;
using PetConnect.Application;
using PetConnect.Application.Abstractions;
using PetConnect.Infrastructure;
using PetConnect.Infrastructure.Repositories;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddApplication();
builder.Services.AddScoped<PetConnectDbContext>();

builder.Services.AddScoped<IPetsRepository, PetsRepository>();

builder.Services.AddHttpLogging(options => { });

// Авто валидация для ДТО, попадающих в контроллер в теле запроса.
builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpLogging();

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();  

app.Run();
