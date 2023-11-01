using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain.Entities.Projects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly ILogger<CreateProjectCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProjectCommandHandler(ILogger<CreateProjectCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var projectEntity = new Project(Guid.NewGuid(), request.Name);

            _unitOfWork.ProjectRepository.AddEntity(projectEntity);

            var result = await _unitOfWork.Complete(cancellationToken);

            if (result <= 0)
            {
                _logger.LogError("Could not insert the project");
                throw new Exception("Could not insert the project");
            }

            return projectEntity.Id;
        }
    }
}
