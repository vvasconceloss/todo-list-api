using System.Net;

namespace csharp_todolist_api.Exceptions
{
  public class NotFoundException : Exception
  {
    private readonly HttpStatusCode statusCode;

    public NotFoundException (string message) : base(message) {}

    public NotFoundException (HttpStatusCode statusCode, string message, Exception exception) : base(message, exception)
    {
      this.statusCode = statusCode;
    }
  }
}