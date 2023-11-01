using MediatR;

namespace BugTracker.Application.Features.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand(Guid Id) : IRequest;
}
