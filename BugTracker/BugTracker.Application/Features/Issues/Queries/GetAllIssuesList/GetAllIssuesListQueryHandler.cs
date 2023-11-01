using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.DTOs.Issues;
using BugTracker.Application.DTOs.Projects;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issues.Queries.GetAllIssuesList
{
    public class GetAllIssuesListQueryHandler : IRequestHandler<GetAllIssuesListQuery, List<IssueViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllIssuesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<IssueViewModel>> Handle(GetAllIssuesListQuery request, CancellationToken cancellationToken)
        {
            var issuesList = await _unitOfWork.IssueRepository.GetAllWithProjectAndUsersAsync();

            return _mapper.Map<List<IssueViewModel>>(issuesList);
        }
    }
}
