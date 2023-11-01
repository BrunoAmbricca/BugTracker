using FluentValidation;

namespace BugTracker.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} cannot be null")
                .NotEmpty().WithMessage("{Name} cannot be empty");
        }
    }
}
