namespace TodoService.Biz.Models;

public record TodoItem(
    string Id,
    string Text,
    bool Completed,
    DateTime? CreatedAt,
    DateTime? UpdatedAt);