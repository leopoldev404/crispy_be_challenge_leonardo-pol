using MediatR;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Models;

namespace TodoService.Biz.Commands;

public sealed class CreateTodoItemCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<CreateTodoItemCommand, TodoItem>
{
    private readonly ITodoRepository todoRepository = todoRepository;

    public async Task<TodoItem> Handle(
        CreateTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        DateTime utcNow = DateTime.UtcNow;

        var todoItem = new TodoItem(
            Guid.NewGuid().ToString(),
            request.Text,
            false,
            utcNow,
            utcNow);

        await todoRepository.AddAsync(todoItem);
        return todoItem;
    }
}
