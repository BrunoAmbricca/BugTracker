using BugTracker.Application.DTOs.Projects;
using MediatR;

namespace BugTracker.Application.Features.Projects.Queries.GetAllProjectsList
{
    public record GetAllProjectsListQuery() : IRequest<List<ProjectViewModel>>;
}
