using FluentValidation;
using TodoService.Api.Requests;

namespace TodoService.Api.Validators;

public class UpdateTodoItemRequestValidator : AbstractValidator<UpdateTodoItemRequest>
{
    public UpdateTodoItemRequestValidator()
    {
        RuleFor(updateTodoItemRequest => updateTodoItemRequest.Id).NotEmpty().NotNull().WithMessage("Id Missing");
        RuleFor(updateTodoItemRequest => updateTodoItemRequest.Text).NotEmpty().NotNull().WithMessage("Text Missing");
        RuleFor(updateTodoItemRequest => updateTodoItemRequest.Completed).NotEmpty().NotNull().WithMessage("Completed Missing");
    }
}