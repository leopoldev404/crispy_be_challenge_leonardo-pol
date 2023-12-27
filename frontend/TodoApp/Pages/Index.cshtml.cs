using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoApp.Models;

namespace TodoApp.Pages;

public class IndexModel(IHttpClientFactory httpClientFactory) : PageModel
{
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;
    public List<TodoItem> TodoItems { get; set; } = [];

    public async Task OnGetAsync()
    {
        var todoApiClient = httpClientFactory.CreateClient("todoApiClient");
        TodoItems = await todoApiClient.GetFromJsonAsync<List<TodoItem>>("") ?? [];
    }

    // public async Task<IActionResult> OnPostAsync()
    // {
    //     var todoApiClient = httpClientFactory.CreateClient("todoApiClient");
    //     await todoApiClient.PostAsJsonAsync($"?todo={Request.Form["todoText"]}", "");
    //     return Page();
    // }

    // public async Task DeleteItemAsync(string todoItemId)
    // {
    //     var todoApiClient = httpClientFactory.CreateClient("todoApiClient");
    //     await todoApiClient.DeleteAsync(todoItemId);
    //     var toRemoveItem = TodoItems.Single(item => item.Id == todoItemId);
    //     TodoItems.Remove(toRemoveItem);
    // }
}
