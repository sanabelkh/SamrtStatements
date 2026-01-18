using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using SmartStatements.Core.Common.Behaviors;
using SmartStatements.Core.IRepositories;
using SmartStatements.Core.IService;
using SmartStatements.Core.Statements.Commands;
using SmartStatements.Core.Statements.Validators;
using SmartStatements.Infra.Repositories;
using SmartStatements.Infra.Services;
using SmartStatements.Infra.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(typeof(GenerateStatementCommand).Assembly));
builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(GenerateStatementValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddScoped<IStatementRepository, StatementRepository>();
builder.Services.AddScoped<IEmailService, SmtpEmailService>();

builder.Services.Configure<SmtpSettings>(
    builder.Configuration.GetSection("SmtpSettings"));

builder.Services.AddTransient<IEmailService, SmtpEmailService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
