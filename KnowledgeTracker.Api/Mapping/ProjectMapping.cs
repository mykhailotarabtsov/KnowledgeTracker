using System;
using KnowledgeTracker.Api.Application.Projects;
using KnowledgeTracker.Api.Domain.Projects;

namespace KnowledgeTracker.Api.Mapping;

public static class ProjectMapping
{
  public static ProjectDto ToDto(this Project project)
  {
    return new ProjectDto
    {
      Id = project.Id,
      Name = project.Name,
      Description = project.Description,
      CreatedAt = project.CreatedAt,
      Tasks = project.Tasks
    };
  }

  public static Project ToDomain(this CreateProjectRequest request)
  {
    return new Project
    {
      Name = request.Name,
      Description = request.Description
    };
  }
}
