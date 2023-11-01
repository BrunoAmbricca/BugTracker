namespace BugTracker.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        IProjectRepository ProjectRepository { get; }

        IIssueRepository IssueRepository { get; }

        Task<int> Complete(CancellationToken cancellationToken);
    }
}
