using FluentValidation;

namespace BugTracker.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} cannot be null")
                .NotEmpty().WithMessage("{Name} cannot be empty");
        }
    }
}
