using KnowledgeTracker.Api.Domain.Projects;

namespace KnowledgeTracker.Api.Application.Projects;

public record class ProjectDto
{
  public required string Name { get; set; }

  public string? Description { get; set; }

  public required DateTime CreatedAt { get; set; }

  public required List<TaskItem> Tasks { get; set; }
}
