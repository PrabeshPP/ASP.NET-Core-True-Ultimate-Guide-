using System.Buffers;
using System.Net;
using Microsoft.Extensions.Primitives;

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
// this is a raw way to read the request in ASP.NET core

int processNumber(int firstNumber, int secondNumber, string operation)
{
    if (operation.Equals("add"))
    {
        return firstNumber + secondNumber;
    }
    else if (operation.Equals("subtract"))
    {
        return firstNumber - secondNumber;
    }
    else if (operation.Equals("multiply"))
    {
        return firstNumber * secondNumber;
    }
    else if (operation.Equals("division"))
    {
        return firstNumber / secondNumber;
    }
    else
    {
        return firstNumber % secondNumber;
    }
}


string[] operations = { "Add", "Subtract", "Multiply", "Division", "IntegerDivision" };

app.Run(async (HttpContext context) =>
{
    //this actually reads the body streams

    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    //converting raw text into dictionary
    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    string? firstNumber = queryDict["firstNumber"];
    string? secondNumber = queryDict["secondNumber"];
    string? operation = queryDict["operation"];
    if (firstNumber == null || secondNumber == null)
    {
        await context.Response.WriteAsync("Invalid firstNumber");
        await context.Response.WriteAsync("Invalid secondNumber");
        if (operation == null)
        {
            await context.Response.WriteAsync("Invalid Opertations");
        }
    }
    else
    {
        if (operations.Contains(operation))
        {
            int result = processNumber(int.Parse(firstNumber), int.Parse(secondNumber), operation);
            await context.Response.WriteAsync(result.ToString());
        }
        else
        {
            await context.Response.WriteAsync("Invalid Input for 'operation' ");
        }
    }




});

app.Run();