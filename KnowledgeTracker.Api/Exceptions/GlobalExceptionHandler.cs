
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTracker.Api.Middleware.Error;

internal sealed class GlobalExceptionHandler(
  IProblemDetailsService problemDetailsService,
  ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
  Exception exception,
  CancellationToken cancellationToken)
  {
    logger.LogError(exception, "An unhandled exception occurred while processing the request.");

    httpContext.Response.StatusCode = exception switch
    {
      ApplicationException => StatusCodes.Status400BadRequest,
      _ => StatusCodes.Status500InternalServerError
    };

    return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
    {
      HttpContext = httpContext,
      Exception = exception,
      ProblemDetails = new ProblemDetails
      {
        Type = exception.GetType().Name,
        Title = "An error occurred while processing your request.",
        Detail = exception.Message,
        Status = httpContext.Response.StatusCode
      }
    });
  }

}
