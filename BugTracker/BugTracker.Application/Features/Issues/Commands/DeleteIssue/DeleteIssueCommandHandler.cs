using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Features.Projects.Commands.DeleteProject;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Projects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Issues.Commands.DeleteIssue
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteIssueCommandHandler> _logger;

        public DeleteIssueCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteIssueCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var issueToDelete = await _unitOfWork.IssueRepository.GetByIdAsync(request.Id);

            if (issueToDelete == null)
            {
                _logger.LogError($"Issue with Id {request.Id} was not found");

                throw new NotFoundException(nameof(Issue), request.Id);
            }

            _unitOfWork.IssueRepository.DeleteEntity(issueToDelete);

            await _unitOfWork.Complete(cancellationToken);

            _logger.LogInformation($"Success deleting Issue {request.Id}");
        }
    }
}
