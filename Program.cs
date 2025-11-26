using csharp_todolist_api.Context;
using Microsoft.EntityFrameworkCore;
using csharp_todolist_api.Interfaces;
using csharp_todolist_api.Middlewares;
using csharp_todolist_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();

builder.Services.AddDbContext<TodoListContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
