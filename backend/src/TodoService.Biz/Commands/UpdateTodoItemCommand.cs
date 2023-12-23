using MediatR;
using TodoService.Biz.Models;

namespace TodoService.Biz.Commands;

public record UpdateTodoItemCommand(TodoItem TodoItem) : IRequest<bool>;