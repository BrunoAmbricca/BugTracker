using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.DTOs.Projects;
using Mapster;
using Mapster.Adapters;
using MapsterMapper;
using MediatR;

namespace BugTracker.Application.Features.Projects.Queries.GetAllProjectsList
{
    public class GetAllProjectsListQueryHandler : IRequestHandler<GetAllProjectsListQuery, List<ProjectViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProjectsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsListQuery request, CancellationToken cancellationToken)
        {
            var projectsList = await _unitOfWork.ProjectRepository.GetAllWithIssuesAndUsersAsync();

            return _mapper.Map<List<ProjectViewModel>>(projectsList);
        }
    }
}
