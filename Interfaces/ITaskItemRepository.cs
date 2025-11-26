using csharp_todolist_api.Models;

namespace csharp_todolist_api.Interfaces
{
  public interface ITaskItemRepository
  {
    public ICollection<TaskItem?> GetTasks();
    public TaskItem CreateTask(TaskItem task);
    public TaskItem UpdateTask(int id, TaskItem task);
    public void DeleteTask(int id);
  }
}