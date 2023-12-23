using TodoService.Biz.Models;

namespace TodoService.Biz.Abastractions;

public interface ITodoRepository
{
    ValueTask InitDbAsync();
    ValueTask<List<TodoItem>> GetAsync();
    ValueTask AddAsync(TodoItem todoItem);
    ValueTask<int> UpdateAsync(TodoItem todoItem);
    ValueTask<int> DeleteAsync(string id);
}