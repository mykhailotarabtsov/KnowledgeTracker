using KnowledgeTracker.Api.Application.Projects;
using KnowledgeTracker.Api.Domain.Projects;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTracker.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _service;

        public ProjectsController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _service.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var project = await _service.GetByIdAsync(id);
            if (project is null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            Project project = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateProjectRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{projectId}/tasks")]
        public async Task<IActionResult> AddTask(string projectId, CreateTaskRequest request)
        {
            var result = await _service.AddTaskAsync(projectId, request);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{projectId}/tasks/{taskId}")]
        public async Task<IActionResult> UpdateTask(string projectId, string taskId, UpdateTaskRequest request)
        {
            var result = await _service.UpdateTaskAsync(projectId, taskId, request);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{projectId}/tasks/{taskId}")]
        public async Task<IActionResult> DeleteTask(string projectId, string taskId)
        {
            var result = await _service.DeleteTaskAsync(projectId, taskId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
