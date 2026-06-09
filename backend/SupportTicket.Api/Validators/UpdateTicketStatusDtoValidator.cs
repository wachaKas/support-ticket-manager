using FluentValidation;
using SupportTicket.Api.DTOs;

namespace SupportTicket.Api.Validators;

public class UpdateTicketStatusDtoValidator : AbstractValidator<UpdateTicketStatusDto>
{
    public UpdateTicketStatusDtoValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status must be one of: New, InProgress, Resolved, Closed.");
    }
}