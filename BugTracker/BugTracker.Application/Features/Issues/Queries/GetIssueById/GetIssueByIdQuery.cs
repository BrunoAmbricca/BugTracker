using BugTracker.Application.DTOs.Issues;
using MediatR;

namespace BugTracker.Application.Features.Issues.Queries.GetIssueById
{
    public record GetIssueByIdQuery(Guid Id) : IRequest<IssueViewModel>;
}
