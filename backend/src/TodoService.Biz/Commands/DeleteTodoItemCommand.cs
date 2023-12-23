using MediatR;

namespace TodoService.Biz.Commands;

public record DeleteTodoItemCommand(string Id) : IRequest<bool>;