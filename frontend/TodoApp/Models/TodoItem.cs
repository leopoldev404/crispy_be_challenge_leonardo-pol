namespace TodoApp.Models;

public class TodoItem
{
    public string? Id { get; set; }
    public string? Text { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}