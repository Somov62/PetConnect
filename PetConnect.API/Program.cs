using PetConnect.API.AutoFluentValidation;
using PetConnect.API.Middlewares;
using PetConnect.Application;
using PetConnect.Infrastructure;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services
    .AddSwaggerGen()
    .AddHttpLogging(options => { })
    .AddControllers();

// ���� ��������� ��� ���, ���������� � ���������� � ���� �������.
builder.Services.AddFluentValidationAutoValidation(configuration =>
{
    configuration.DisableBuiltInModelValidation = true;
    configuration.OverrideDefaultResultFactoryWith<CustomResultFactory>();
});

var app = builder.Build();

// ���������� ���������� ����������.
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpLogging();

app.UseSwagger();

app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();  

app.Run();
