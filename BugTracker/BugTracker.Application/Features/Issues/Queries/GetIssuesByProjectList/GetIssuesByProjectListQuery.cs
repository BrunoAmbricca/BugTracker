using BugTracker.Application.DTOs.Issues;
using MediatR;

namespace BugTracker.Application.Features.Issues.Queries.GetIssuesByProjectList
{
    public record GetIssuesByProjectListQuery(Guid ProjectId) : IRequest<List<IssueViewModel>>;
}
