using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestTaskJS.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/users", async (ApplicationContext app) => await app.Users.ToListAsync());

app.MapPost("/api/user/add", async (User newUser, ApplicationContext app) =>
{
    await app.Users.AddAsync(newUser);
    await app.SaveChangesAsync();
    return newUser;
});
app.MapPost("/api/item/add", async (Event newEvent, ApplicationContext app) =>
{
    await app.Events.AddAsync(newEvent);
    await app.SaveChangesAsync();
    return newEvent;
});

app.MapGet("/api/users/{id:int}", async (int id, ApplicationContext app, HttpContext context) =>
{    
    User user = await app.Users.Include(u => u.UserEvents).FirstOrDefaultAsync(u => u.Id == id);

    return user!.UserEvents;
});

app.Run();