using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Smarika loves prabesh");
/*
In the get Request, there is no request body
*/

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

    context.Response.Headers["Content-type"] = "text/html";
    context.Response.Headers["MyKey"] = "MyValue";

    string path = context.Request.Path;
    string method = context.Request.Method;
    if (method == "GET")
    {
        HttpRequest request = context.Request;
        if (request.Query.ContainsKey("id"))
        {

            string? id = request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
    }

});

app.Run();