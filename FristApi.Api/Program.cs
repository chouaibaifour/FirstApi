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
    app.UseDeveloperExceptionPage();
}



app.UseStaticFiles();
app.UseWelcomePage();
app.UseRouting();
app.MapGet("/", () => "Hello World!");

app.MapGet("/person", () => new Person("Andrew", "Lock")); 
app.Run();
public record Person(string FirstName, string LastName);