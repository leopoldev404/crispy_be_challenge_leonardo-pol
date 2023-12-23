using MediatR;
using TodoService.Biz.Abastractions;

namespace TodoService.Biz.Commands;

public class UpdateTodoItemCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<UpdateTodoItemCommand, bool>
{
    private readonly ITodoRepository todoRepository = todoRepository;

    public async Task<bool> Handle(
        UpdateTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        int affectedRows = await todoRepository.UpdateAsync(request.TodoItem);
        return affectedRows > 0;
    }
}
