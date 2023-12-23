using MediatR;
using TodoService.Biz.Abastractions;
using TodoService.Biz.Models;

namespace TodoService.Biz.Queries;

public class GetTodoItemsQueryHandler(ITodoRepository todoRepository)
    : IRequestHandler<GetTodoItemsQuery, List<TodoItem>>
{
    private readonly ITodoRepository todoRepository = todoRepository;

    public async Task<List<TodoItem>> Handle(
        GetTodoItemsQuery request,
        CancellationToken cancellationToken)
    {
        return await todoRepository.GetAsync();
    }
}
