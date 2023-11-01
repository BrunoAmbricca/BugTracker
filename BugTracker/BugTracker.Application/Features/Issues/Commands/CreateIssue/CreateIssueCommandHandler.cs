using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Features.Projects.Commands.CreateProject;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Issues.ValueObjects;
using BugTracker.Domain.Entities.Projects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, Guid>
    {
        private readonly ILogger<CreateProjectCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateIssueCommandHandler(ILogger<CreateProjectCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdWithIssuesAsync(request.ProjectId);

            if(project == null) 
            {
                _logger.LogError($"Project with Id {request.ProjectId} was not found. Issue NOT created");

                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            var issueEntity = new Issue(Guid.NewGuid(),
                                        $"{project.Name.ToUpper().Substring(0, 3)}-{(project.Issues.Count + 1).ToString("000")}", 
                                        request.Summary,
                                        request.Description,
                                        request.Priority,
                                        request.Status,
                                        request.Type,
                                        request.ProjectId);

            _unitOfWork.IssueRepository.AddEntity(issueEntity);

            var result = await _unitOfWork.Complete(cancellationToken);

            if (result <= 0)
            {
                _logger.LogError("Could not insert the Issue");
                throw new Exception("Could not insert the Issue");
            }

            return issueEntity.Id;
        }
    }
}
