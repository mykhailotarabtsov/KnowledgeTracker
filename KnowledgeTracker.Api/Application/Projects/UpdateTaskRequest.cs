using System.ComponentModel.DataAnnotations;

namespace KnowledgeTracker.Api.Application.Projects;

public record class UpdateTaskRequest
{
  [StringLength(100, MinimumLength = 2, ErrorMessage = "Task title must be between 2 and 100 characters.")]
  public string Title { get; set; } = string.Empty;
  public bool IsCompleted { get; set; }
}
