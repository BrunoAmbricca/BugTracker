using BugTracker.Application.DTOs.Issues;
using BugTracker.Domain.Entities.Issues;
using Mapster;

namespace BugTracker.Application.Mappings
{
    public class IssueMappingConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Issue, IssueViewModel>()
                .Map(dest => dest.ProjectName, src => src.Project.Name);
        }
    }
}
