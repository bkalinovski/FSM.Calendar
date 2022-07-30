using FluentValidation;

namespace FSM.Calendar.Application.Slots.Commands.CreateSlot;

public class CreateSlotCommandValidator : AbstractValidator<CreateSlotCommand>
{
    public CreateSlotCommandValidator()
    {
        RuleFor(t => t.Date)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.Date))
            .WithMessage("Cannot create a slot with a past date");
        
        RuleFor(t => t.FromTime)
            .NotEmpty()
            .GreaterThanOrEqualTo(TimeOnly.FromDateTime(DateTime.Now.Date))
            .WithMessage("Cannot create a slot with a past from time");

        RuleFor(t => t.ToTime)
            .NotEmpty();
    }
}