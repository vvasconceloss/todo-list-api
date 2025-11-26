using Microsoft.AspNetCore.Mvc;
using csharp_todolist_api.Exceptions;

namespace csharp_todolist_api.Middlewares
{
  internal sealed class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
  {
    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await next(context);
      }
      catch (Exception exception)
      {
        logger.LogError(exception, "Unhandled exception occurred");

        context.Response.StatusCode = exception switch
        {
          NotFoundException => StatusCodes.Status404NotFound,
          _ => StatusCodes.Status500InternalServerError
        };

        await context.Response.WriteAsJsonAsync(
        new ProblemDetails
        {
          Type = exception.GetType().Name,
          Title = "An error has occurred",
          Detail = exception.Message
        });
      }
    }
  }
}