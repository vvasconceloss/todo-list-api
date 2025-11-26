using csharp_todolist_api.Models;

namespace csharp_todolist_api.Interfaces
{
  public interface ITaskItemRepository
  {
    public ICollection<TaskItem?> GetTasks();
    public TaskItem? GetTaskById(int id);
    public TaskItem CreateTask(TaskItem task);
    public void UpdateTask(int id, TaskItem task);
    public void DeleteTask(int id);
  }
}