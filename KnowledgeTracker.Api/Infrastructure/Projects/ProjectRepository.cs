using System;
using KnowledgeTracker.Api.Application.Projects;
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

    public async Task<bool> AddTaskAsync(string projectId, TaskItem task)
    {
        var update = Builders<Project>.Update.Push(p => p.Tasks, task);
        var result = await _collection.UpdateOneAsync(p => p.Id == projectId, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> UpdateTaskAsync(string projectId, string taskId, UpdateTaskRequest request)
    {
        var filter = Builders<Project>.Filter.And(
            Builders<Project>.Filter.Eq(p => p.Id, projectId),
            Builders<Project>.Filter.ElemMatch(p => p.Tasks, t => t.Id == taskId)
        );

        // $ - positional operator
        var update = Builders<Project>.Update
            .Set("Tasks.$.Title", request.Title)
            .Set("Tasks.$.IsCompleted", request.IsCompleted);

        var result = await _collection.UpdateOneAsync(filter, update);
        return result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteTaskAsync(string projectId, string taskId)
    {
        var update = Builders<Project>.Update.PullFilter(p => p.Tasks, t => t.Id == taskId);
        var result = await _collection.UpdateOneAsync(p => p.Id == projectId, update);
        return result.ModifiedCount > 0;
    }
}
