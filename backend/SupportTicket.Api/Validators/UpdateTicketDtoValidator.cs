using FluentValidation;
using SupportTicket.Api.DTOs;

namespace SupportTicket.Api.Validators;

public class UpdateTicketDtoValidator : AbstractValidator<UpdateTicketDto>
{
    public UpdateTicketDtoValidator()
    {
        RuleFor(x => x.CustomerEmail)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(150);

        RuleFor(x => x.Subject)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Message)
            .NotEmpty()
            .MaximumLength(2000);

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status must be one of: New, InProgress, Resolved, Closed.");

        RuleFor(x => x.Priority)
            .IsInEnum()
            .WithMessage("Priority must be one of: Low, Medium, High, Critical.");
    }
}