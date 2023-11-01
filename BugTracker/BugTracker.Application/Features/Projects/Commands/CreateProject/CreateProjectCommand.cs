using MediatR;

namespace BugTracker.Application.Features.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(string Name) : IRequest<Guid>;
}
