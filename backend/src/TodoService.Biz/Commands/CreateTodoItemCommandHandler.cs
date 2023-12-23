using MediatR;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Models;

namespace TodoService.Biz.Commands;

public class CreateTodoItemCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<CreateTodoItemCommand, TodoItem>
{
    private readonly ITodoRepository todoRepository = todoRepository;

    public async Task<TodoItem> Handle(
        CreateTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        TodoItem todoItem = new(
            Guid.NewGuid().ToString(),
            request.Text,
            false);

        await todoRepository.AddAsync(todoItem);
        return todoItem;
    }
}
