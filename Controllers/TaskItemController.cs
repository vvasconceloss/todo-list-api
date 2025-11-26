using Microsoft.AspNetCore.Mvc;
using csharp_todolist_api.DTOS;
using csharp_todolist_api.Models;
using csharp_todolist_api.Interfaces;

namespace csharp_todolist_api.Controllers
{
  [ApiController]
  public class TaskItemController(ITaskItemRepository taskItemRepository) : ControllerBase
  {
    private readonly ITaskItemRepository _taskItemRepository = taskItemRepository;

    [HttpPost]
    [Route("task/create")]
    public IActionResult Add([FromBody] TaskItemDTO taskItemDTO)
    {
      TaskItem taskItem = new()
      {
        Title = taskItemDTO.Title,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
      };

      _taskItemRepository.CreateTask(taskItem);
      
      return Ok();
    }

    [HttpGet]
    [Route("task/all")]
    public IActionResult GetAll()
    {
      return Ok(_taskItemRepository.GetTasks());
    }

    [HttpDelete]
    [Route("task/delete/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      _taskItemRepository.DeleteTask(id);
      return Ok();
    }
  }
}