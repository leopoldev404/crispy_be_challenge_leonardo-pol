using MediatR;
using TodoService.Biz.Models;

namespace TodoService.Biz.Commands;

public record CreateTodoItemCommand(string Text) : IRequest<TodoItem>;