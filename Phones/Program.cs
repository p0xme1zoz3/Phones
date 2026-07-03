using Microsoft.EntityFrameworkCore;
using Phones.Model;
using Phones.Repository;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "All phones");

app.MapGet("/api/phones", async (IRepository repo) =>
{
    return await repo.AllPhones();
});

app.MapGet("api/phones/{id}", async (IRepository repo, int id) =>
{
    var res = await repo.GetPhone(id);
    if (res == null) return Results.NotFound(new { message = "Phone not found" });
    return Results.Json(res);
});

app.MapPut("api/phones/update", async (IRepository repo, Phone phone) =>
{
    var res = await repo.UpdatePhone(phone);
    if (res == null) return Results.NotFound(new { message = "Phone not found" });
    return Results.Json(res);
});

app.MapPost("api/phones/create", async (IRepository repo, PhoneDto phoneDto) =>
{
    var res = await repo.AddPhone(phoneDto);
    return Results.Json(res);
});

app.MapDelete("api/phones/delete/{id}", async (IRepository repo, int id) =>
{
    var res = await repo.DeletePhone(id); 
    if (res == null) return Results.NotFound(new {message = "Phone not found"});
    return Results.Json(res);
});

app.Run();

