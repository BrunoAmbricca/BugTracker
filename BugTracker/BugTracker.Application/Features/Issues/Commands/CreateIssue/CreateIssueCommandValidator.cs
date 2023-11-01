using FluentValidation;

namespace BugTracker.Application.Features.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandValidator : AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueCommandValidator()
        {
            RuleFor(x => x.Summary)
                .NotEmpty().WithMessage("{Summary} cannot be empty")
                .NotNull().WithMessage("{Summary} cannot be null");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("{Description} cannot be null");

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("{Priority} invalid value");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("{Status} invalid value");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("{Type} invalid value");

            RuleFor(x => x.ProjectId)
                .NotNull().WithMessage("The Issue must be assigned to a Project");
        }
    }
}
