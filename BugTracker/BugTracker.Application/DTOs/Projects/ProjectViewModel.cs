using BugTracker.Application.DTOs.Issues;

namespace BugTracker.Application.DTOs.Projects
{
    public class ProjectViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<IssueViewModel> Issues { get; set; } = new();
    }
}
