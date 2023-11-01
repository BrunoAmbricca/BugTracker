using BugTracker.Application.DTOs.Issues;
using BugTracker.Application.DTOs.Projects;
using BugTracker.Application.Features.Issues.Commands.CreateIssue;
using BugTracker.Application.Features.Issues.Commands.DeleteIssue;
using BugTracker.Application.Features.Issues.Commands.UpdateIssue;
using BugTracker.Application.Features.Issues.Queries.GetAllIssuesList;
using BugTracker.Application.Features.Issues.Queries.GetIssueById;
using BugTracker.Application.Features.Issues.Queries.GetIssuesByProjectList;
using BugTracker.Application.Features.Projects.Commands.CreateProject;
using BugTracker.Application.Features.Projects.Commands.DeleteProject;
using BugTracker.Application.Features.Projects.Commands.UpdateProject;
using BugTracker.Application.Features.Projects.Queries.GetAllProjectsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BugTracker.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class IssueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllIssues")]
        [ProducesResponseType(typeof(IEnumerable<IssueViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<IssueViewModel>>> GetAllIssues()
        {
            var query = new GetAllIssuesListQuery();
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }     

        [HttpPost(Name = "CreateIssue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Guid>> CreateIssue([FromBody] CreateIssueCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateIssue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> UpdateIssue([FromBody] UpdateIssueCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}", Name = "DeleteIssue")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteIssue(Guid id)
        {
            var command = new DeleteIssueCommand(id);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        [Route("GetIssueById/{Id}")]
        [ProducesResponseType(typeof(IssueViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<IssueViewModel>> GetIssueById(Guid Id)
        {
            var query = new GetIssueByIdQuery(Id);
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }

        [HttpGet]
        [Route("GetIssuesByProject/{ProjectId}")]
        [ProducesResponseType(typeof(IEnumerable<IssueViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<IssueViewModel>>> GetIssuesByProject(Guid ProjectId)
        {
            var query = new GetIssuesByProjectListQuery(ProjectId);
            var projects = await _mediator.Send(query);

            return Ok(projects);
        }
    }
}
