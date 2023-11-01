using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.DTOs.Issues;
using BugTracker.Application.DTOs.Projects;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Features.Issues.Queries.GetIssueById;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Projects;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProjectByIdQueryHandler> _logger;

        public GetProjectByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetProjectByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProjectViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdWithIssuesAndUsersAsync(request.Id);

            if(project == null) 
            {
                _logger.LogError($"Project with Id {request.Id} was not found");

                throw new NotFoundException(nameof(Project), request.Id);
            } 

            return _mapper.Map<ProjectViewModel>(project);
        }
    }
}
