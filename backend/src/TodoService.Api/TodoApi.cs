using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using TodoService.Api.Requests;
using TodoService.Biz.Commands;
using TodoService.Biz.Models;
using TodoService.Biz.Queries;

namespace TodoService.Api;

public static class TodoApi
{
    public static RouteGroupBuilder MapTodosApiEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapGet("", GetAllAsync);
        routeGroupBuilder.MapPost("", PostAsync);
        routeGroupBuilder.MapDelete("/{id}", DeleteAsync);
        routeGroupBuilder.MapPatch("", PatchAsync);
        return routeGroupBuilder;
    }

    public static async ValueTask<List<TodoItem>> GetAllAsync(ISender sender) =>
        await sender.Send(new GetTodoItemsQuery());

    public static async ValueTask<IResult> PostAsync(
        ISender sender,
        [FromQuery] string todoText)
    {
        if (string.IsNullOrEmpty(todoText))
        {
            return Results.BadRequest("Invalid new todo item text");
        }

        TodoItem todoItem = await sender.Send(new CreateTodoItemCommand(todoText));
        return Results.Created("", todoItem);
    }

    public static async ValueTask<IResult> DeleteAsync(
        ISender sender,
        string id)
    {
        bool succeeded = await sender.Send(new DeleteTodoItemCommand(id));

        return succeeded
                ? Results.NoContent()
                : Results.NotFound("Id not found");
    }

    public static async ValueTask<IResult> PatchAsync(
        ISender sender,
        IValidator<UpdateTodoItemRequest> validator,
        [FromBody] UpdateTodoItemRequest request)
    {
        var validationResult =
            await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var todoItem = new TodoItem(
            request.Id,
            request.Text,
            request.Completed);

        bool succeeded = await sender.Send(new UpdateTodoItemCommand(todoItem));

        return succeeded
            ? Results.NoContent()
            : Results.NotFound("Id not found");
    }

    public static WebApplication MapHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");
        app.MapHealthChecks("/liveness", new HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains("live")
        });
        return app;
    }
}