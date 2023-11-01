using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.Exceptions;
using BugTracker.Domain.Entities.Projects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteProjectCommandHandler> _logger;

        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, ILogger<DeleteProjectCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var projectToDelete = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Id);

            if (projectToDelete == null)
            {
                _logger.LogError($"Project with Id {request.Id} was not found");

                throw new NotFoundException(nameof(Project), request.Id);
            }

            _unitOfWork.ProjectRepository.DeleteEntity(projectToDelete);

            await _unitOfWork.Complete(cancellationToken);

            _logger.LogInformation($"Success deleting Project {request.Id}");
        }
    }
}
