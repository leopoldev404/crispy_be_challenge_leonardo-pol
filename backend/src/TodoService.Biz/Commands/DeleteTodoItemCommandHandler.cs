using MediatR;
using TodoService.Biz.Abastractions;

namespace TodoService.Biz.Commands;

public class DeleteTodoItemCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<DeleteTodoItemCommand, bool>
{
    private readonly ITodoRepository todoRepository = todoRepository;

    public async Task<bool> Handle(
        DeleteTodoItemCommand request,
        CancellationToken cancellationToken)
    {
        int affectedRows = await todoRepository.DeleteAsync(request.Id);
        return affectedRows > 0;
    }
}
