namespace TodoService.Api.Requests;

public record UpdateTodoItemRequest(string Id, string Text, bool Completed);