namespace TodoApp.Settings;

public class TodoApiSettings
{
    public const string TodoApiSettingsSectionName = "TodoApi";

    public string? Url { get; set; }
    public string? ApiKey { get; set; }
}