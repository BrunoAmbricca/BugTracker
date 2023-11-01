using BugTracker.Domain.Entities.Users;

namespace BugTracker.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<ApplicationUser>
    {
    }
}
