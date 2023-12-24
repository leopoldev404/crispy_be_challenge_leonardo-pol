using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using TodoService.Api.Apis.Requests;
using TodoService.Api.Apis.Validators;
using TodoService.Biz.Commands;
using TodoService.Biz.Models;
using TodoService.Biz.Queries;

namespace TodoService.Api.Apis;

public static class TodoApi
{
    public static RouteGroupBuilder MapTodosApi(this RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapGet("", GetAllAsync);

        routeGroupBuilder.MapPost("", PostAsync);

        routeGroupBuilder.MapDelete("/{id}", DeleteAsync);

        routeGroupBuilder.MapPatch("", PatchAsync)
            .AddEndpointFilter<RequestsValidatorEndpointFilter<UpdateTodoItemRequest>>();

        return routeGroupBuilder;
    }

    public static async ValueTask<List<TodoItem>> GetAllAsync(ISender sender) =>
        await sender.Send(new GetTodoItemsQuery());

    public static async ValueTask<IResult> PostAsync(
        ISender sender,
        [FromQuery] string todo)
    {
        if (string.IsNullOrEmpty(todo))
        {
            return Results.BadRequest("Invalid new todo item text");
        }

        TodoItem todoItem = await sender.Send(new CreateTodoItemCommand(todo));
        return Results.Created("", todoItem);
    }

    public static async ValueTask<IResult> DeleteAsync(
        ISender sender,
        [FromRoute] string id)
    {
        bool succeeded = await sender.Send(new DeleteTodoItemCommand(id));

        return succeeded
                ? Results.NoContent()
                : Results.NotFound("Id not found");
    }

    public static async ValueTask<IResult> PatchAsync(
        ISender sender,
        [FromBody] UpdateTodoItemRequest request)
    {
        var todoItem = new TodoItem(
            request.Id,
            request.Text,
            request.Completed,
            null,
            DateTime.UtcNow);

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