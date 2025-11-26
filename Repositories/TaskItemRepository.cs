using csharp_todolist_api.Models;
using csharp_todolist_api.Context;
using csharp_todolist_api.Interfaces;

namespace csharp_todolist_api.Repositories
{
  public class TaskItemRepository(TodoListContext context) : ITaskItemRepository
  {
    private readonly TodoListContext _context = context;

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
      return [.. _context.Tasks];
    }

    public TaskItem UpdateTask(int id, TaskItem task)
    {
      throw new NotImplementedException();
    }
  }
}