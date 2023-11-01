using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.DTOs.Issues;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Features.Projects.Commands.CreateProject;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Projects;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BugTracker.Application.Features.Issues.Queries.GetIssueById
{
    public class GetIssueByIdQueryHandler : IRequestHandler<GetIssueByIdQuery, IssueViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetIssueByIdQueryHandler> _logger;

        public GetIssueByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetIssueByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IssueViewModel> Handle(GetIssueByIdQuery request, CancellationToken cancellationToken)
        {
            var issue = await _unitOfWork.IssueRepository.GetByIdWithProjectAndUsersAsync(request.Id);

            if(issue == null) 
            {
                _logger.LogError($"Issue with Id {request.Id} was not found");

                throw new NotFoundException(nameof(Issue), request.Id);
            } 

            return _mapper.Map<IssueViewModel>(issue);
        }
    }
}
