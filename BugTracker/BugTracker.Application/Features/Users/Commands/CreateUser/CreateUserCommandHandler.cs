using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.Features.Projects.Commands.CreateProject;
using BugTracker.Domain.Entities.Projects;
using BugTracker.Domain.Entities.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = new ApplicationUser(Guid.NewGuid(), request.Name, request.Email);

            _unitOfWork.UserRepository.AddEntity(userEntity);

            var result = await _unitOfWork.Complete(cancellationToken);

            if (result <= 0)
            {
                _logger.LogError("Could not insert the project");
                throw new Exception("Could not insert the project");
            }

            return userEntity.Id;
        }
    }
}
