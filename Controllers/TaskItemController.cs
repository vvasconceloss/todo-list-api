using Microsoft.AspNetCore.Mvc;
using csharp_todolist_api.DTOS;
using csharp_todolist_api.Models;
using csharp_todolist_api.Interfaces;
using csharp_todolist_api.Exceptions;

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

      var task = _taskItemRepository.CreateTask(taskItem);
      
      return StatusCode(201, task);
    }

    [HttpGet]
    [Route("task/all")]
    public IActionResult GetAll()
    {
      return StatusCode(200, _taskItemRepository.GetTasks());
    }

    [HttpPut]
    [Route("task/update/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] TaskItemDTO taskItemDTO)
    {
      if (_taskItemRepository.GetTaskById(id) == null)
        throw new NotFoundException($"The task with ID {id} was not found");
        
      TaskItem taskItem = new()
      {
        Title = taskItemDTO.Title,
        UpdatedAt = DateTime.UtcNow
      };

      _taskItemRepository.UpdateTask(id, taskItem);
      return StatusCode(204);
    }

    [HttpDelete]
    [Route("task/delete/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
      if (_taskItemRepository.GetTaskById(id) == null)
        throw new NotFoundException($"The task with ID {id} was not found");

      _taskItemRepository.DeleteTask(id);
      return StatusCode(200);
    }
  }
}