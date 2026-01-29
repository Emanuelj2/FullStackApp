var builder = WebApplication.CreateBuilder(args);

//add CORS
/*
    What is CORS?
    -CORS stands for Cross-Origin Resource Scharring
    -CORS lets your front end safely talk to your back end when they run on different ports or domains.
    -protects users from cross-site attacks

    -in a real application we would NOT use AllowAnyOrgin() insted we would use WithOrgins("https://myfrontend.com") 
*/
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
    policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseCors("AllowBlazor");

app.MapGet("/api/productslist", () =>
{

    return new[]

    {

        new { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25 },

        new { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100 }

    };

});

app.Run();