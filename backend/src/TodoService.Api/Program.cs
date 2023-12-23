using FluentValidation;
using TodoService.Api;
using TodoService.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.Services.AddMediator();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTodoItemRequestValidator>();
builder.Services.AddRepositories();
builder.Services.AddDefaultCors();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapGroup("/api/v1/todos")
    .MapTodosApiEndpoints()
    .WithTags("Todos Api V1");

app.MapHealthChecks();


await app.InitDbAsync();
await app.RunAsync();