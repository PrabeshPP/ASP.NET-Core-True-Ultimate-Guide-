using MiddlewareExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

//lambda expression that can be used as a middleware
//this is asynchronous lambda expression
//Having two app.Run would make a no difference


int result = 1;

//chaining the middleware in .NET Core
app.Use(async(HttpContext context,RequestDelegate next)=>{
    result +=10;
    await context.Response.WriteAsync("Learning middleware\n");
    // while chaining the middleware, we have to pass the context to the subsequent middleware
    await next(context);
});


app.UseMiddleware<MyCustomMiddleware>();

app.Run(async(HttpContext context)=>{
    await context.Response.WriteAsync($"{result}\n");
});



app.Run();
