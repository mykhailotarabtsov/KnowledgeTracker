using KnowledgeTracker.Api.Domain.Projects;
using KnowledgeTracker.Api.Infrastructure.Projects;

namespace KnowledgeTracker.Api.Application.Projects;

public class ProjectService
{
  private readonly ProjectRepository _repository;

  public ProjectService(ProjectRepository repository)
  {
    _repository = repository;
  }

  public async Task<List<Project>> GetAllAsync()
  {
    var projects = await _repository.GetAllAsync();
    return projects;
  }

  public async Task<Project?> GetByIdAsync(string id)
  {
    var project = await _repository.GetByIdAsync(id);
    return project;
  }

  public async Task<Project> CreateAsync(CreateProjectRequest request)
  {
    var project = new Project
    {
      Name = request.Name,
      Description = request.Description
    };

    await _repository.CreateAsync(project);
    return project;
  }

  public async Task<bool> UpdateAsync(string id, UpdateProjectRequest request)
  {
    var existing = await _repository.GetByIdAsync(id);
    if (existing is null)
      return false;

    existing.Name = request.Name;
    existing.Description = request.Description;

    return await _repository.UpdateAsync(id, existing);
  }

  public async Task<bool> DeleteAsync(string id)
  {
    return await _repository.DeleteAsync(id);
  }
}
