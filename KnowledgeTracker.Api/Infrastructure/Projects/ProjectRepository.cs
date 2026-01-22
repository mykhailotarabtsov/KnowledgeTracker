using System;
using KnowledgeTracker.Api.Domain.Projects;
using MongoDB.Driver;

namespace KnowledgeTracker.Api.Infrastructure.Projects;

public class ProjectRepository
{
    private readonly IMongoCollection<Project> _collection;

    public ProjectRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Project>("projects");
    }

    public async Task<List<Project>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<Project?> GetByIdAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Project project) =>
        await _collection.InsertOneAsync(project);

    public async Task<bool> UpdateAsync(string id, Project project)
    {
        var result = await _collection.ReplaceOneAsync(
            x => x.Id == id,
            project
        );

        return result.MatchedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var result = await _collection.DeleteOneAsync(x => x.Id == id);
        return result.DeletedCount > 0;
    }
}
