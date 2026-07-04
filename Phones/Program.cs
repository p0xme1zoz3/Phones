using Microsoft.EntityFrameworkCore;
using Phones.Dto;
using Phones.Repository;
using Phones.Services;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            message = "An internal server error has occurred",
        });
    });
});

app.MapGet("/", () => "All phones");

app.MapGet("/api/phones", async (IPhoneService phoneService) => await phoneService.AllPhones());

app.MapGet("api/phones/{id}", async (IPhoneService phoneService, int id) =>
{
    var res = await phoneService.GetPhone(id);
    return res == null ? Results.NotFound(new { message = "Phone not found" }) : Results.Json(res);
});

app.MapPut("api/phones/update", async (IPhoneService phoneService, PhoneUpdateDto phoneUpdateDto) =>
{       
    var validationError = ValidationHelper.Validate(phoneUpdateDto);

    if (validationError != null)
        return validationError;
    
    var res = await phoneService.UpdatePhone(phoneUpdateDto);
    return res == null ? Results.NotFound(new { message = "Phone not found" }) : Results.Json(res);
});

app.MapPost("api/phones/create", async (IPhoneService phoneService, PhoneAddDto phoneAddDto) =>
{
    var validationError = ValidationHelper.Validate(phoneAddDto);

    if (validationError != null)
        return validationError;
    
    var res = await phoneService.AddPhone(phoneAddDto);
    return Results.Json(res);
});

app.MapDelete("api/phones/delete/{id}", async (IPhoneService phoneService, int id) =>
{
    var res = await phoneService.DeletePhone(id); 
    return res == null ? Results.NotFound(new {message = "Phone not found"}) : Results.Json(res);
});

app.Run();

