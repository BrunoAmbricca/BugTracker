namespace BugTracker.Domain.Entities.Issues.ValueObjects
{
    public record IssueCode
    {
        public string Value { get; init; }

        private IssueCode(string value) => Value = value;

        public static string? Create(string projectName, int issueNumber)
        {
            if (projectName == null) return null;

            string value = projectName.ToUpper().Take(3) + "-" + issueNumber;

            return value;
        }
    }
}
