using System.Net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Smarika loves prabesh");
/*
1. In the get Request, there is no request body
2. Reuest headers are sent by the browser and it is a way how browser talks with the server
*/

/*
Request Headers Format
1. Accept: Represents MIME Type of response that is text/html just an example
2. Accept-Language: natural language of response en-US
3. Content-Type: Type of request body,  for example, text/html, multipart/form-data
4. Content-Length: Length of the request body, for example, 100 or 200
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