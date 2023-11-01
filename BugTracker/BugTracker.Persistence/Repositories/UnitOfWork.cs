using BugTracker.Application.Contracts.Persistence;
using BugTracker.Persistence.Persistence;

namespace BugTracker.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BugTrackerDbContext _context;

        public IUserRepository UserRepository {  get; }

        public IProjectRepository ProjectRepository {  get; }

        public IIssueRepository IssueRepository {  get; }

        public UnitOfWork(BugTrackerDbContext context, IUserRepository userRepository, IProjectRepository projectRepository, IIssueRepository issueRepository)
        {
            _context = context;
            UserRepository = userRepository;
            ProjectRepository = projectRepository;
            IssueRepository = issueRepository;
        }

        public Task<int> Complete(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
