using KnowledgeTracker.Api.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace KnowledgeTracker.Api.Domain.Projects;

public record class Project : BaseEntity
{

  [BsonElement("name")]
  public string Name { get; set; } = null!;

  [BsonElement("description")]
  public string? Description { get; set; }

  [BsonElement("createdAt")]
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
