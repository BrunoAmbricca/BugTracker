using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.DTOs.Issues;
using MapsterMapper;
using MediatR;

namespace BugTracker.Application.Features.Issues.Queries.GetIssuesByProjectList
{
    public class GetIssuesByProjectListQueryHandler : IRequestHandler<GetIssuesByProjectListQuery, List<IssueViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetIssuesByProjectListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<IssueViewModel>> Handle(GetIssuesByProjectListQuery request, CancellationToken cancellationToken)
        {
            var issuesList = await _unitOfWork.IssueRepository.GetAllByProjectIdWithProjectAndUsersAsync(request.ProjectId);

            return _mapper.Map<List<IssueViewModel>>(issuesList);
        }
    }
}
