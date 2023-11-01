using BugTracker.Domain.Entities.Issues.Enums;
using MediatR;

namespace BugTracker.Application.Features.Issues.Commands.CreateIssue
{
    public record CreateIssueCommand(string Summary,
                                     string Description,
                                     IssuePriority Priority,
                                     IssueStatus Status,
                                     IssueType Type,
                                     Guid ProjectId ) : IRequest<Guid>;
}
