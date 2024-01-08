using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoService.Api.Requests;
using TodoService.Api.Validators;
using TodoService.Biz.Commands;
using TodoService.Biz.Models;
using TodoService.Biz.Queries;

namespace TodoService.Api;

public static class TodoApi
{
    public static RouteGroupBuilder MapTodoApiEndpoints(this RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapGet("", Get);

        routeGroupBuilder.MapPost("", Create);

        routeGroupBuilder.MapDelete("/{id}", Delete);

        routeGroupBuilder.MapPatch("", Update)
            .AddEndpointFilter<RequestsValidatorEndpointFilter<UpdateTodoItemRequest>>();

        return routeGroupBuilder;
    }

    public static async ValueTask<List<TodoItem>> Get(ISender sender) =>
        await sender.Send(new GetTodoItemsQuery());

    public static async ValueTask<IResult> Create(
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

    public static async ValueTask<IResult> Delete(
        ISender sender,
        [FromRoute] string id)
    {
        bool succeeded = await sender.Send(new DeleteTodoItemCommand(id));

        return succeeded
                ? Results.NoContent()
                : Results.NotFound("Id not found");
    }

    public static async ValueTask<IResult> Update(
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
}