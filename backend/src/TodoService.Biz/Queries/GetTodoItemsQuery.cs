using MediatR;
using TodoService.Biz.Models;

namespace TodoService.Biz.Queries;

public record GetTodoItemsQuery() : IRequest<List<TodoItem>>;