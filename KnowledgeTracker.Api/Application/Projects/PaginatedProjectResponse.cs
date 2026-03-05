using KnowledgeTracker.Api.Domain.Projects;

namespace KnowledgeTracker.Api.Application.Projects;

public record class PaginatedProjectResponse
{
  public required List<ProjectDto> Projects { get; set; }
  public required int TotalCount { get; set; }
  public required int CurrentPage { get; set; }
  public required int TotalPages { get; set; }
}
