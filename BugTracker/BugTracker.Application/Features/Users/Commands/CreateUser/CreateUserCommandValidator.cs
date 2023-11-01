using FluentValidation;

namespace BugTracker.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} cannot be null");
            
            RuleFor(p => p.Email)
                .NotNull().WithMessage("{Email} cannot be null");
        }
    }
}
