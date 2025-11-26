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

    public void DeleteTask(int id)
    {
      TaskItem taskItem = _context.Tasks.Where(task => task.Id == id).First();
      
      _context.Tasks.Remove(taskItem);
      _context.SaveChanges();
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