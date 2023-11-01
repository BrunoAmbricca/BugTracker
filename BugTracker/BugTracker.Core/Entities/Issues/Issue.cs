using BugTracker.Domain.Common;
using BugTracker.Domain.Entities.Issues.Enums;
using BugTracker.Domain.Entities.Projects;
using BugTracker.Domain.Entities.Users;

namespace BugTracker.Domain.Entities.Issues
{
    public class Issue : Entity
    {
        public string Code { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public IssuePriority Priority { get; set; }

        public IssueStatus Status { get; set; }

        public IssueType Type { get; set; }

        public Guid ProjectId { get; set; }

        public virtual Project Project { get; }

        public virtual ICollection<ApplicationUser> Users { get; } = new List<ApplicationUser>();

        public Issue(Guid id, string code, string summary, string description, IssuePriority priority, IssueStatus status, IssueType type, Guid projectId)
            : base(id)
        {
            Code = code;
            Summary = summary;
            Description = description;
            Priority = priority;
            Status = status;
            Type = type;
            ProjectId = projectId;
        }
    }
}
