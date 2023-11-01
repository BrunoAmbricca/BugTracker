using BugTracker.Application.DTOs.Issues;
using MediatR;

namespace BugTracker.Application.Features.Issues.Queries.GetAllIssuesList
{
    public record GetAllIssuesListQuery() : IRequest<List<IssueViewModel>>;
}
