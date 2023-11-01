using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Projects;
using BugTracker.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence.Repositories
{
    public class IssueRepository : RepositoryBase<Issue>, IIssueRepository
    {
        public IssueRepository(BugTrackerDbContext context) 
            : base(context)
        {
        }

        public Task<List<Issue>> GetAllWithProjectAndUsersAsync()
        {
            return _context.Set<Issue>().Include(x => x.Project).Include(x => x.Users).ToListAsync();
        }

        public Task<List<Issue>> GetAllByProjectIdWithProjectAndUsersAsync(Guid projectId)
        {
            return _context.Set<Issue>().Include(x => x.Project).Include(x => x.Users).Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public async Task<Issue?> GetByIdWithProjectAndUsersAsync(Guid Id)
        {
            return await _context.Set<Issue>().Include(x => x.Project).Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
