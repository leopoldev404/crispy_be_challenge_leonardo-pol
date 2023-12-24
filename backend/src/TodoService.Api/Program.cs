using FluentValidation;
using TodoService.Api;
using TodoService.Api.Apis;
using TodoService.Api.Apis.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.AddLogger();
builder.Services.AddMediator();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddRepositories();
builder.Services.AddDefaultCors();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseCors();

app.MapGroup("/api/v1/todos")
    .MapTodosApi()
    .AddEndpointFilter<ApiKeyAuthEndpointFilter>()
    .WithTags("Todos Api V1");

app.MapHealthChecks();

await app.InitDbAsync();
await app.RunAsync();