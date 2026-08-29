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


app.MapGet("/", () => "Hello World!");

app.MapGet("/error", () => "An error occurred in production");
app.MapGet("/error-local-development", () => "An error occurred in development");

app.MapGet("/person", () => new Person("Andrew", "Lock")); 
app.MapGet("/person/{name}", (string name) => People().Where(p => p.FirstName.StartsWith(name))); 
    
app.Run();
return;

List<Person> People()=>
[
    new Person("Andrew", "Lock"),
    new Person("chouaib", "aifour"),
    new Person("Sew", "Lock"),
    new Person("patrick", "Dom")
];

public record Person(string FirstName, string LastName);