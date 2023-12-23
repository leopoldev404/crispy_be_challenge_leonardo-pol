using MediatR;
using TodoService.Biz.Abastractions;

namespace TodoService.Biz.Commands;

public class InitDbCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<InitDbCommand>
{
    private readonly ITodoRepository todoRepository = todoRepository;

    public async Task Handle(
        InitDbCommand request,
        CancellationToken cancellationToken)
    {
        await todoRepository.InitDbAsync();
    }
}
