using BugTracker.Domain.Common;
using BugTracker.Domain.Entities.Issues;
using BugTracker.Domain.Entities.Projects;

namespace BugTracker.Domain.Entities.Users
{
    public class ApplicationUser : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Issue> Issues { get; } = new List<Issue>();

        public virtual ICollection<Project> Projects { get; } = new List<Project>();

        public ApplicationUser(Guid id, string name, string email) 
            : base(id)
        {
            Name = name;
            Email = email;
        }
    }
}
