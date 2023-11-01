using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain.Entities.Projects;
using BugTracker.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence.Repositories
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {

        public ProjectRepository(BugTrackerDbContext context) 
            : base(context)
        {
        }

        public async Task<List<Project>> GetAllWithIssuesAndUsersAsync()
        {
            return await _context.Set<Project>().Include(x => x.Issues).Include(x => x.Users).ToListAsync();
        }

        public async Task<Project?> GetByIdWithIssuesAndUsersAsync(Guid id)
        {
            return await _context.Set<Project>().Include(x => x.Issues).Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Project?> GetByIdWithIssuesAsync(Guid id)
        {
            return await _context.Set<Project>().Include(x => x.Issues).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
