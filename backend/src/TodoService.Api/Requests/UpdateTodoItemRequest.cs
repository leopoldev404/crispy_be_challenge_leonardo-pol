using System.Text.Json.Serialization;

namespace TodoService.Api.Requests;

public record UpdateTodoItemRequest(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("Completed")] bool Completed);