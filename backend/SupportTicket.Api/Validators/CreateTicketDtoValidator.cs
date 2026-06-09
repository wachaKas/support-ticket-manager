using FluentValidation;
using SupportTicket.Api.DTOs;
using SupportTicket.Api.Enums;

namespace SupportTicket.Api.Validators;

public class CreateTicketDtoValidator : AbstractValidator<CreateTicketDto>
{
    public CreateTicketDtoValidator()
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

        RuleFor(x => x.Priority)
            .IsInEnum()
            .WithMessage("Priority must be one of: Low, Medium, High, Critical.");
    }
}