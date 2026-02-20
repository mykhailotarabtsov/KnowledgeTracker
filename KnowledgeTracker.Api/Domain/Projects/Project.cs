using System.ComponentModel.DataAnnotations;
using KnowledgeTracker.Api.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace KnowledgeTracker.Api.Domain.Projects;

public class Project : BaseEntity
{

  [BsonElement("name")]
  [Required(ErrorMessage = "Project name is required.", AllowEmptyStrings = false)]
  [StringLength(100, MinimumLength = 2, ErrorMessage = "Project name must be between 2 and 100 characters.")]
  public string Name { get; set; } = null!;

  [BsonElement("description")]
  [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
  public string? Description { get; set; }

  [BsonElement("createdAt")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public List<TaskItem> Tasks { get; set; } = new();
}
