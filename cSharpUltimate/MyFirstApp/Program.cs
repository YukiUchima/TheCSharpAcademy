var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 500; // bad response
    await context.Response.WriteAsync("Hello, this is the response body\n");
    await context.Response.WriteAsync("Previously message has finished...");
});

app.Run();
