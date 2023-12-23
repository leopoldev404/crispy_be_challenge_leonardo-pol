namespace TodoService.Api;

public class AuthorizationMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        if ((!context.Request.Headers.ContainsKey("apikey")) ||
            (context.Request.Headers["apikey"] != Environment.GetEnvironmentVariable("ServiceApiKey")))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }

        await next(context);
    }
}
