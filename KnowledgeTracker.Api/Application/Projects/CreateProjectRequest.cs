namespace KnowledgeTracker.Api.Application.Projects;

public record class CreateProjectRequest
{
  public string Name { get; set; } = null!;
  public string? Description { get; set; }
}
