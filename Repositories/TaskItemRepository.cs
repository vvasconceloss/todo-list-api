using csharp_todolist_api.Interfaces;
using csharp_todolist_api.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_todolist_api.Repositories
{
  public class TaskItemRepository(DbContext context) : ITaskItemRepository
  {
    private readonly DbContext _context = context;

    public TaskItem CreateTask(TaskItem task)
    {
      _context.Add(task);
      _context.SaveChanges();

      return task;
    }

    public bool DeleteTask(int id)
    {
      throw new NotImplementedException();
    }

    public ICollection<TaskItem?> GetTasks()
    {
      throw new NotImplementedException();
    }

    public TaskItem UpdateTask(int id, TaskItem task)
    {
      throw new NotImplementedException();
    }
  }
}