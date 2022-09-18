

public class EventHandlerMiddleware
{
    private readonly RequestDelegate _next;
    ILogger<EventHandlerMiddleware> _logger;
    public EventHandlerMiddleware(RequestDelegate next, ILogger<EventHandlerMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {

        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            _logger.LogError($"Error: {ex.Message} Stack trace:{ex.StackTrace}");
            throw;
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class EventHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseEventHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<EventHandlerMiddleware>();
    }
}

