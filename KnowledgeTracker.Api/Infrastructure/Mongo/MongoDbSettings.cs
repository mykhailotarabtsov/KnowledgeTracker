using System;

namespace KnowledgeTracker.Api.Infrastructure.Mongo;

public class MongoDbSettings
{
  public string ConnectionString { get; set; } = null!;
  public string DatabaseName { get; set; } = null!;
}
