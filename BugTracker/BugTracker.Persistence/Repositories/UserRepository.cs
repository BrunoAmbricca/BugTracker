using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain.Entities.Users;
using BugTracker.Persistence.Persistence;

namespace BugTracker.Persistence.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(BugTrackerDbContext context) : base(context)
        {
        }
    }
}
