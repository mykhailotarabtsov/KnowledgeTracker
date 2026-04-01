using KnowledgeTracker.Api.Application.Projects;
using KnowledgeTracker.Api.Domain.Projects;
using KnowledgeTracker.Api.Mapping;
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
        public async Task<IActionResult> GetAll(string name = "")
        {
            var projects = await _service.GetAllAsync(name);
            return Ok(projects.Select(p => p.ToDto()));
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetAllPaginated(int page = 1, int pageSize = 10, string name = "")
        {
            if (page < 1 || pageSize < 1)
            {
                return BadRequest("Page and pageSize must be greater than 0.");
            }

            Console.WriteLine($"Getting paginated projects for page {page} and page size {pageSize}");
            var paginatedProjects = await _service.GetAllPaginatedAsync(page, pageSize, name);
            return Ok(paginatedProjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var project = await _service.GetByIdAsync(id);
            if (project is null)
                return NotFound();

            return Ok(project.ToDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            Project project = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project.ToDto());
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
