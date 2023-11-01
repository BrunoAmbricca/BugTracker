using BugTracker.Domain.Entities.Issues;

namespace BugTracker.Application.Contracts.Persistence
{
    public interface IIssueRepository : IAsyncRepository<Issue>
    {
        Task<List<Issue>> GetAllWithProjectAndUsersAsync();

        Task<List<Issue>> GetAllByProjectIdWithProjectAndUsersAsync(Guid projectId);

        Task<Issue?> GetByIdWithProjectAndUsersAsync(Guid Id);
        
    }
}
