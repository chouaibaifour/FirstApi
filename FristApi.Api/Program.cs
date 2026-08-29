using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(opts =>    
    opts.LoggingFields = HttpLoggingFields.All); 
builder.Logging.AddFilter(     
    "Microsoft.AspNetCore.HttpLogging", LogLevel.Information);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHttpLogging();
   app.UseExceptionHandler("/error-local-development");
}
else
    app.UseExceptionHandler("/error");




app.UseStaticFiles();
app.UseRouting();
app.UseWelcomePage();

app.MapGet("/", () => "Hello World!");

app.MapGet("/error", () => "An error occurred in production");
app.MapGet("/error-local-development", () => "An error occurred in development");

app.MapGet("/person", () => new Person("Andrew", "Lock")); 

app.Run();
public record Person(string FirstName, string LastName);