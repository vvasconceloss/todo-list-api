namespace csharp_todolist_api.DTOS
{
  public class TaskItemDTO
  {
    public int Id { get; set; }
    public required string Title { get; set; }
  }
}