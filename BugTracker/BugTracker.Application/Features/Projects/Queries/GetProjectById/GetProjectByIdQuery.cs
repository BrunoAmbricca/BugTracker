using BugTracker.Application.DTOs.Projects;
using MediatR;

namespace BugTracker.Application.Features.Projects.Queries.GetProjectById
{
    public record GetProjectByIdQuery(Guid Id) : IRequest<ProjectViewModel>;
}
