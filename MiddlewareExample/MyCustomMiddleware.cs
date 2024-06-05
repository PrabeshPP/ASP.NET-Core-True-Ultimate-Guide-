
namespace MiddlewareExample;

public class MyCustomMiddleware : IMiddleware
{
    //this is a overriding method
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("This will be executed first in the middleware\n");
        await next(context);
        await context.Response.WriteAsync("This will be executed after the consecutive context is resolved");
    }
}

public static class CustomMiddlewareExtension{
    
}
