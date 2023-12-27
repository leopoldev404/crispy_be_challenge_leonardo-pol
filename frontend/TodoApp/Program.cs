using TodoApp.Settings;

var builder = WebApplication.CreateBuilder(args);

var todoApiSettings = builder.Configuration
    .GetSection(TodoApiSettings.TodoApiSettingsSectionName).Get<TodoApiSettings>()
        ?? throw new ArgumentNullException("Missing Todo API Configuration!");

builder.Services.AddHttpClient("todoApiClient", client =>
{
    client.BaseAddress = new Uri(todoApiSettings.Url
        ?? throw new ArgumentNullException("Missing Todo API Service URL!"));

    client.DefaultRequestHeaders.Add("ApiKey", todoApiSettings.ApiKey
        ?? throw new ArgumentNullException("Missing Todo API Service URL!"));
});

builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
