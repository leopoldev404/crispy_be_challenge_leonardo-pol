namespace Todo.Application;

public record TodoItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Text { get; set; }
    public bool Done { get; set; } = false;

    public TodoItem(string text)
    {
        Text = text;
    }
}