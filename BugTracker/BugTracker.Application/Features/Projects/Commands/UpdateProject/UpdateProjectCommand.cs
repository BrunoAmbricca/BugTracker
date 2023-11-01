using MediatR;

namespace BugTracker.Application.Features.Projects.Commands.UpdateProject
{
    public record UpdateProjectCommand(Guid Id, string Name) : IRequest<Guid>;
}
