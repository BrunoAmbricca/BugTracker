using MediatR;

namespace BugTracker.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(string Name, string Email) : IRequest<Guid>;
}
