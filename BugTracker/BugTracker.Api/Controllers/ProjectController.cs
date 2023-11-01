using BugTracker.Application.DTOs.Issues;
using BugTracker.Application.DTOs.Projects;
using BugTracker.Application.Features.Issues.Queries.GetIssueById;
using BugTracker.Application.Features.Projects.Commands.CreateProject;
using BugTracker.Application.Features.Projects.Commands.DeleteProject;
using BugTracker.Application.Features.Projects.Commands.UpdateProject;
using BugTracker.Application.Features.Projects.Queries.GetAllProjectsList;
using BugTracker.Application.Features.Projects.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BugTracker.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllProjects")]
        [ProducesResponseType(typeof(IEnumerable<ProjectViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProjectViewModel>>> GetAllProjects()
        {
            var query = new GetAllProjectsListQuery();
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }

        [HttpPost(Name = "CreateProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> CreateProject([FromBody] CreateProjectCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> UpdateProject([FromBody] UpdateProjectCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}", Name = "DeleteProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("GetProjectById/{Id}")]
        [ProducesResponseType(typeof(ProjectViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectViewModel>> GetProjectById(Guid Id)
        {
            var query = new GetProjectByIdQuery(Id);
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }
    }
}
