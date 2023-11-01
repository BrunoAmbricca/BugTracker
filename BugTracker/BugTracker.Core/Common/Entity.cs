namespace BugTracker.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }

        protected Entity() { }

        protected Entity(Guid id) => Id = id;
    }
}
