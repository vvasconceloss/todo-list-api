using csharp_todolist_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_todolist_api.Context
{
  public class TodoListContext(DbContextOptions<TodoListContext> options) : DbContext(options)
  {
    public DbSet<TaskItem> Tasks { get; set; }

    protected void OModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<TaskItem>(entity =>
      {
        entity.ToTable("Tasks");
        entity.HasKey(task => task.Id);
      });
    }
  }
}