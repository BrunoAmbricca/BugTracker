using BugTracker.Domain.Entities.Projects;

namespace BugTracker.Application.Contracts.Persistence
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<List<Project>> GetAllWithIssuesAndUsersAsync();

        Task<Project?> GetByIdWithIssuesAsync(Guid id);

        Task<Project?> GetByIdWithIssuesAndUsersAsync(Guid id);
    }
}
