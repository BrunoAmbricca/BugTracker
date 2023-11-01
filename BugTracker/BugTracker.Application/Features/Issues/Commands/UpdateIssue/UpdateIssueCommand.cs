using BugTracker.Domain.Entities.Issues.Enums;
using MediatR;

namespace BugTracker.Application.Features.Issues.Commands.UpdateIssue
{
    public record UpdateIssueCommand(Guid Id,
                                     string Summary,
                                     string Description,
                                     IssuePriority Priority,
                                     IssueStatus Status,
                                     IssueType Type,
                                     Guid ProjectId) : IRequest<Guid>;

}
