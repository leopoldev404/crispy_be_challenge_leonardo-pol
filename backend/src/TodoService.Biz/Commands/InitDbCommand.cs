using MediatR;

namespace TodoService.Biz.Commands;

public record InitDbCommand() : IRequest;