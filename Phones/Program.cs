using Phones.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

List<Phone> phones = new List<Phone>()
{
    new Phone(1,"Nokia","3410",new DateOnly(2005,10,1),0),
    new Phone(2,"Nokia","1600",new DateOnly(2007,6,1),0),
    new Phone(3,"Nokia","E-71",new DateOnly(2011,5,1),0)
};

app.UseHttpsRedirection();

app.MapGet("/", () => "My phones");
app.MapGet("/api/phones", () => phones);
app.MapGet("api/phones/{Id}", (int Id) =>
{
    Phone phone = phones.FirstOrDefault(u => u.Id == Id);
    if (phone == null) return Results.NotFound(new {message = "Phone not found"});
    return Results.Json(phone);
});

app.MapPut("/phones/{Id}", (int Id) => phones.FirstOrDefault(u => u.Id == Id));
app.Run();

