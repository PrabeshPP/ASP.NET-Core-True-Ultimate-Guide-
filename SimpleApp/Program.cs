using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Smarika loves prabesh");

app.Run(async (HttpContext context) =>
{
    if (1 == 1)
    {
        context.Response.StatusCode = 201;

    }
    else
    {
        context.Response.StatusCode = 404;
    }
     
    context.Response.Headers["MyKey"] = "MyValue";
    context.Response.Headers["Server"] = "AWS S3";
    await context.Response.WriteAsync("This is the new instance of the HttpContext");
    await context.Response.WriteAsync("This is another response");

});

app.Run();