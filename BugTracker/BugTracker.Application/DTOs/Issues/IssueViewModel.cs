using BugTracker.Domain.Entities.Issues.Enums;

namespace BugTracker.Application.DTOs.Issues
{
    public class IssueViewModel
    {
        public string Code { get; set; } = string.Empty;

        public string Summary { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Priority { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public Guid ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;
    }
}
