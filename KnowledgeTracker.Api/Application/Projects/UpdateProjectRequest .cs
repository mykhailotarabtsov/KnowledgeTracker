using System.ComponentModel.DataAnnotations;

namespace KnowledgeTracker.Api.Application.Projects;

public record class UpdateProjectRequest
{
  [Required(ErrorMessage = "Project name is required.", AllowEmptyStrings = false)]
  [StringLength(100, MinimumLength = 2, ErrorMessage = "Project name must be between 2 and 100 characters.")]
  public string Name { get; set; } = null!;
  [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
  public string? Description { get; set; }
}
