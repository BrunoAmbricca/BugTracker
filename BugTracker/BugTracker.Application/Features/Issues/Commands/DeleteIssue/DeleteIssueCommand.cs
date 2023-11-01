﻿using MediatR;

namespace BugTracker.Application.Features.Issues.Commands.DeleteIssue
{
    public record DeleteIssueCommand(Guid Id) : IRequest;
}
