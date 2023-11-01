using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Features.Projects.Commands.UpdateProject;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Projects;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateIssueCommandHandler> _logger;

        public UpdateIssueCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateIssueCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdWithIssuesAsync(request.ProjectId);

            if(project == null) 
            {
                _logger.LogError($"Project with Id {request.ProjectId} was not found. Issue NOT updated");

                throw new NotFoundException(nameof(Project), request.ProjectId);
            }

            var issueToUpdate = await _unitOfWork.IssueRepository.GetByIdAsync(request.Id);

            if (issueToUpdate == null)
            {
                _logger.LogError($"Issue with Id {request.Id} was not found");

                throw new NotFoundException(nameof(Issue), request.Id);
            }

            issueToUpdate = _mapper.Map<Issue>(request);

            _unitOfWork.IssueRepository.UpdateEntity(issueToUpdate);

            await _unitOfWork.Complete(cancellationToken);

            _logger.LogInformation($"Success updating Issue {request.Id}");

            return issueToUpdate.Id;
        }
    }
}
