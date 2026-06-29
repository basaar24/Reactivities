using Application.Activities.Commands;
using FluentValidation;

namespace Application.Activities.Validators;

public class CreateActivityValidator : AbstractValidator<CreateActivity.Command>
{
    public CreateActivityValidator()
    {
        RuleFor(x => x.ActivityRequest.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.ActivityRequest.Description).NotEmpty().WithMessage("Description is required");
    }
}
