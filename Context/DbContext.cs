using Microsoft.EntityFrameworkCore;

namespace csharp_todolist_api.Context
{
  public class TodoListContext(DbContextOptions<TodoListContext> options) : DbContext(options)
  {
    public DbSet<Task> Tasks { get; set; }
  } 
}