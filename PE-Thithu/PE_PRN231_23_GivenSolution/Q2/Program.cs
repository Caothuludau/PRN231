var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapRazorPages();
app.Run();