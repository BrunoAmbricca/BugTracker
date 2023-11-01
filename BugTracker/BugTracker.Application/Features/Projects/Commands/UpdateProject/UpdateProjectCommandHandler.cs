using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Features.Issues.Commands.UpdateIssue;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Projects;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProjectCommandHandler> _logger;

        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateProjectCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectToUpdate = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);

            if (projectToUpdate == null)
            {
                _logger.LogError($"Project with Id {request.Id} was not found");

                throw new NotFoundException(nameof(Project), request.Id);
            }

            projectToUpdate = _mapper.Map<Project>(request);

            _unitOfWork.ProjectRepository.UpdateEntity(projectToUpdate);

            await _unitOfWork.Complete(cancellationToken);

            _logger.LogInformation($"Success updating Project {request.Id}");

            return projectToUpdate.Id;
        }
    }
}
