using BugTracker.Domain.Common;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Users;

namespace BugTracker.Domain.Entities.Projects
{
    public class Project : Entity
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Issue> Issues { get; } = new List<Issue>();

        public virtual ICollection<ApplicationUser> Users { get; } = new List<ApplicationUser>();

        public Project(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
    }
}
