using FluentValidation;

namespace TodoService.Api.Apis.Validators;

public class RequestsValidatorEndpointFilter<T>(IValidator<T> validator)
    : IEndpointFilter
{
    private readonly IValidator<T> validator = validator;

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        T? entity = context.Arguments.OfType<T>()
            .FirstOrDefault(req => req?.GetType() == typeof(T));

        var validationResult = await validator.ValidateAsync(entity!);
        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        return await next(context);
    }
}