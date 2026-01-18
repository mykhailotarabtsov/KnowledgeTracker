using KnowledgeTracker.Api.Application.Projects;
using KnowledgeTracker.Api.Domain.Projects;
using KnowledgeTracker.Api.Infrastructure.Projects;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTracker.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectRepository _repository;

        public ProjectsController(ProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _repository.GetAllAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repository.CreateAsync(project);
            return CreatedAtAction(nameof(GetAll), new { id = project.Id }, project);
        }
    }
}
