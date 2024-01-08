namespace TodoService.Infrastructure.Settings;

public class DatabaseSettings
{
    public const string ConfigurationSectionName = "DatabaseSettings";
    public string? ConnectionString { get; set; }
}