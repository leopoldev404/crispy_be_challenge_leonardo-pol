using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoService.Api.Apis.Requests;

namespace TodoService.Api.Apis.Validators;

public class UpdateTodoItemRequestValidator : AbstractValidator<UpdateTodoItemRequest>
{
    public UpdateTodoItemRequestValidator()
    {
        RuleFor(updateTodoItemRequest => updateTodoItemRequest.Id)
            .NotEmpty().NotNull().WithMessage("Id Missing");

        RuleFor(updateTodoItemRequest => updateTodoItemRequest.Text)
            .NotEmpty().NotNull().WithMessage("Text Missing");

        RuleFor(updateTodoItemRequest => updateTodoItemRequest.Completed)
            .NotNull().WithMessage("Completed Missing")
           .Must(value => value == true || value == false).WithMessage("Invalid Value for Completed");
    }
}