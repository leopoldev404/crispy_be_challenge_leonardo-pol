using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Models;

namespace TodoApp.Pages;

public class IndexModel(IHttpClientFactory httpClientFactory) : PageModel
{
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;
    public List<TodoItem> Todos { get; set; } = [];

    public async Task OnGetAsync()
    {
        using var todoApiClient = httpClientFactory.CreateClient("todoApiClient");
        Todos = await todoApiClient.GetFromJsonAsync<List<TodoItem>>("") ?? [];
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            using var todoApiClient = httpClientFactory.CreateClient("todoApiClient");
            var response = await todoApiClient.DeleteAsync($"/api/v1/todos/{id}");
            response.EnsureSuccessStatusCode();
        }

        if (!string.IsNullOrEmpty(Request.Form["Text"]))
        {
            var todoApiClient = httpClientFactory.CreateClient("todoApiClient");
            await todoApiClient.PostAsJsonAsync($"?todo={Request.Form["Text"]}", "");
        }
        return RedirectToPage();
    }
}
