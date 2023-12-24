namespace TodoService.Api.Apis.Authentication;

public class ApiKeyAuthEndpointFilter(IConfiguration configuration)
    : IEndpointFilter
{
    private readonly IConfiguration configuration = configuration;

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(
                AuthConstants.ApiKeyHeaderName, out var receivedApiKey))
        {
            return Results.Unauthorized();
        }

        string apiKey = configuration
            .GetValue<string>(AuthConstants.ApiKeySectionName) ??
            throw new ArgumentNullException("Missing ApiKey Configuration!");

        if (!apiKey.Equals(receivedApiKey))
        {
            return Results.Unauthorized();
        }

        return await next(context);
    }
}